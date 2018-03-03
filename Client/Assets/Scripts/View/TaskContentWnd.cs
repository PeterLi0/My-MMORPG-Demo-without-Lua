using System;
using System.Collections.Generic;
using task;
using common;
using UnityEngine.UI;
using UnityEngine;


class TaskContentWnd : BaseWnd
{
    private TaskDTO _task;
    private string _taskName;
    private string _taskGlodAward;
    public void Initialize(TaskDTO dto)
    {
        _task = dto;
        // 任务配置文件信息
        Dictionary<int, TaskCfg> taskCfgs = ConfigManager.instance._taskCfgs;
        foreach (var taskCfg in taskCfgs.Values)
        {
            if (_task.task_id == taskCfg.ID)
            {
                _taskName = taskCfg.task_name;
                _taskGlodAward = taskCfg.task_gold_award.ToString();
            }
        }
        Button btnClose = _transform.FindChild("BtnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(OnBtnCloseClick);

        // 任务名
        Text title = _transform.FindChild("Title").GetComponent<Text>();
        title.text = _taskName;

        // 内容
        Text content = _transform.FindChild("Content").GetComponent<Text>();
        content.text = string.Format("任务奖励：{0}\n\n\n已杀死怪物：{1}", _taskGlodAward, dto.kill_monster_count.ToString());


        // 完成任务
        Button btnComplete = _transform.FindChild("BtnComplete").GetComponent<Button>();
        btnComplete.onClick.AddListener(OnBtnComplete);
        // 放弃任务
        Button btnGiveUp = _transform.FindChild("BtnDelete").GetComponent<Button>();
        btnGiveUp.onClick.AddListener(OnBtnGiveUpClick);
    }

    private void OnBtnCloseClick()
    {
        WindowManager.instance.Close<TaskContentWnd>();
    }
    private void OnBtnComplete()
    {
        bool isComplete = false;
        int task_gold_award = 0;
        Dictionary<int, TaskCfg> taskCfgs = ConfigManager.instance._taskCfgs;
        foreach (var taskCfg in taskCfgs.Values)
        {
            if (taskCfg.ID == _task.task_id && _task.kill_monster_count >= taskCfg.required_kill_monster_count)
            {
                isComplete = true;
                task_gold_award = taskCfg.task_gold_award;
            }
        }
        if (isComplete)
        {
            ReqCompleteTask req = new ReqCompleteTask();
            req.task = _task;
            req.task_gold_award = task_gold_award;
            DataCache.instance.currentCharacter.gold += task_gold_award;
            MessageBox.Show(string.Format("任务已完成，奖励金币{0}", _taskGlodAward));
            NetworkManager.instance.Send((int)MsgID.Finish_CREQ, req);
        }
        else
        {
            MessageBox.Show("您还没有完成此任务");
        }        
    }
    private void OnBtnGiveUpClick()
    {
        ReqDeleteTask req = new ReqDeleteTask();
        req.task_id = _task.task_id;
        NetworkManager.instance.Send((int)MsgID.Drop_CREQ, req);
    }
}

