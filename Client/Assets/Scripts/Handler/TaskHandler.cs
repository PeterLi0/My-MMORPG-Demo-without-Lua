using System;
using System.Collections.Generic;
using task;
using common;
using UnityEngine;


class TaskHandler : IMsgHandler
{
    public void RegisterMsg(Dictionary<MsgID, Action<SocketModel>> handlers)
    {
        handlers.Add(MsgID.Info_SRES, OnQueryTask);
        handlers.Add(MsgID.Receive_SRES, OnAccessTask);
        handlers.Add(MsgID.Drop_SRES, OnDeleteTask);
        handlers.Add(MsgID.Finish_SRES, OnCompleteTask);
    }
    public void OnQueryTask(SocketModel model)
    {        
        RespTaskInfo resp = SerializeUtil.Deserialize<RespTaskInfo>(model.message);
        DataCache.instance.taskDtos = resp.task;        
        WindowManager.instance.Open<TaskWnd>().Initialize();

    }
    public void OnAccessTask(SocketModel model)
    {
        RespAddTask resp = SerializeUtil.Deserialize<RespAddTask>(model.message);
        if (resp.isSuccess == true)
        {
            Dictionary<int, TaskCfg> taskCfgs = ConfigManager.instance._taskCfgs;
            foreach (var taskCfg in taskCfgs.Values)
            {
                if (taskCfg.ID == resp.task.task_id)
                {
                    TaskDTO task = new TaskDTO();
                    
                    task.task_id = resp.task.task_id;
                    task.kill_monster_count = 0;
                    DataCache.instance.taskDtos.Add(task);

                    WindowManager.instance.Get<TaskWnd>().AddTask(task);
                }
            }           
        }
        else
        {
            MessageBox.Show("已拥有此任务");
        }
    }

    public void OnDeleteTask(SocketModel model)
    {
        RespDeleteTask resp = SerializeUtil.Deserialize<RespDeleteTask>(model.message);
        if (resp.isSuccess)
        {
            TaskDTO task = new TaskDTO();
            List<TaskDTO> tasks = DataCache.instance.GetTaskDTO();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].task_id == resp.task_id)
                {
                    task = tasks[i];
                }
            }
            tasks.Remove(task);
            WindowManager.instance.Get<TaskWnd>().Delete(resp.task_id);
        }
        else
        {
            MessageBox.Show("删除失败!");
        }
    }

    public void OnCompleteTask(SocketModel model)
    {
        RespCompleteTask resp = SerializeUtil.Deserialize<RespCompleteTask>(model.message);
        if (resp.isSuccess)
        {
            TaskDTO task = new TaskDTO();
            List<TaskDTO> tasks = DataCache.instance.GetTaskDTO();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].task_id == resp.task_id)
                {
                    task = tasks[i];
                }
            }
            tasks.Remove(task);
            DataCache.instance.currentCharacter.gold += resp.task_gold_award;
            WindowManager.instance.Get<TaskWnd>().Delete(resp.task_id);
            //MessageBox.Show("已完成，奖励待发放");
        }
    }
}

