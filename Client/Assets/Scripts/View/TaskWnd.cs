using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using task;


class TaskWnd : MainWnd
{
    public class ButtonEventListener : MonoBehaviour, IPointerClickHandler
    {
        // 我的任务
        public TaskDTO dto;
        // 查看某项任务
        public void OnPointerClick(PointerEventData eventData)
        {
            WindowManager.instance.Open<TaskContentWnd>().Initialize(dto);
        }        
    }

    public class AccessTaskListener : MonoBehaviour, IPointerClickHandler
    {
        // 接收某项任务
        public TaskCfg taskCfg;
        public void OnPointerClick(PointerEventData eventData)
        {
            ReqAddTask req = new ReqAddTask();
            req.task_id = taskCfg.ID;
            NetworkManager.instance.Send((int)MsgID.Receive_CREQ, req);
        }
    }

    // 我的任务
    Transform _contentMyTask;
    // 可选任务
    Transform _contentTask;
    Button myTaskModle;

    
    public new void Initialize()
    {
        Button btnClose = _transform.FindChild("BtnClose").GetComponent<Button>();
        btnClose.onClick.AddListener(OnBtnClose);

        _contentMyTask = _transform.FindChild("Scroll View_MyTasks/Viewport/Content");
        _contentTask = _transform.FindChild("Scroll View/Viewport/Content");

        myTaskModle = _transform.FindChild("Scroll View_MyTasks/Button").GetComponent<Button>();
        Button taskModle = _transform.FindChild("Scroll View/Button").GetComponent<Button>();

        // 获取可选任务
        Dictionary<int, TaskCfg> taskCfgs = ConfigManager.instance._taskCfgs;       
        foreach (TaskCfg cfg in taskCfgs.Values)
        {
            Transform item = (GameObject.Instantiate(taskModle.gameObject) as GameObject).transform;
            item.SetParent(_contentTask.transform);
            item.gameObject.SetActive(true);
            item.localPosition = Vector3.zero;
            item.localScale = Vector3.one;
            item.FindChild("Subject").GetComponent<Text>().text =  cfg.required_kill_monster_count.ToString();
            item.FindChild("ID").GetComponent<Text>().text = cfg.task_name;

            item.gameObject.AddComponent<AccessTaskListener>().taskCfg = cfg;
        }

        // 我的任务
        List<TaskDTO> taskDtos = DataCache.instance.GetTaskDTO();
       
        foreach (TaskDTO myTask in taskDtos)
        {
            Transform item = (GameObject.Instantiate(myTaskModle.gameObject) as GameObject).transform;
            item.SetParent(_contentMyTask.transform);
            item.gameObject.SetActive(true);
            item.localPosition = Vector3.zero;
            item.localScale = Vector3.one;
            // 已击杀怪物数
            item.FindChild("Subject").GetComponent<Text>().text = string.Format("已击杀：{0}", myTask.kill_monster_count.ToString());

            // 获取任务名字
            //Dictionary<int, TaskCfg> taskCfgsA = ConfigManager.instance._taskCfgs;
            foreach (var taskCfg in taskCfgs.Values)
            {
                if (myTask.task_id == taskCfg.ID)
                {
                    item.FindChild("ID").GetComponent<Text>().text = taskCfg.task_name;                    
                }
            }
            //item.FindChild("ID").GetComponent<Text>().text =  myTask.task_id.ToString();

            item.gameObject.AddComponent<ButtonEventListener>().dto = myTask;
        }
    }
    /// <summary>
    /// 放弃任务
    /// </summary>
    /// <param name="taskid"></param>
    public void Delete(int taskid)
    {
        for (int i = 0; i < _contentMyTask.childCount; i++)
        {
            Transform child = _contentMyTask.GetChild(i);
            TaskDTO dto = child.GetComponent<ButtonEventListener>().dto;

            if (dto.task_id == taskid)
            {
                GameObject.Destroy(child.gameObject);
            }                
        }
    }
    // 添加任务
    public void AddTask(TaskDTO myTask)
    {
        Transform item = (GameObject.Instantiate(myTaskModle.gameObject) as GameObject).transform;
        item.SetParent(_contentMyTask.transform);
        item.gameObject.SetActive(true);
        item.localPosition = Vector3.zero;
        item.localScale = Vector3.one;
        // 已击杀怪物数
        item.FindChild("Subject").GetComponent<Text>().text = string.Format("已击杀：{0}", myTask.kill_monster_count.ToString());
        // 获取任务名字
        Dictionary<int, TaskCfg> taskCfgsA = ConfigManager.instance._taskCfgs;
        foreach (var taskCfg in taskCfgsA.Values)
        {
            if (myTask.task_id == taskCfg.ID)
            {
                item.FindChild("ID").GetComponent<Text>().text = taskCfg.task_name;
            }
        }
        //item.FindChild("ID").GetComponent<Text>().text = myTask.task_id.ToString();

        item.gameObject.AddComponent<ButtonEventListener>().dto = myTask;
    }
    private void OnBtnClose()
    {
        WindowManager.instance.Close<TaskWnd>();
    }

    
}

