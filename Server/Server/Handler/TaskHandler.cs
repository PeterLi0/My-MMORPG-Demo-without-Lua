using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task;
using common;

public class TaskHandler : IMsgHandler
{
    public void RegisterMsg(Dictionary<MsgID, Action<UserToken, SocketModel>> handlers)
    {
        handlers.Add(MsgID.Info_CREQ, OnQueryTask);
        handlers.Add(MsgID.Receive_CREQ, OnAccessTask);
        handlers.Add(MsgID.Drop_CREQ, OnGiveUpTask);
        handlers.Add(MsgID.Finish_CREQ, OnCompleteTask);
        handlers.Add(MsgID.UpdateTask_CREQ, OnUpdateTask);
    }
    // 查询任务
    public void OnQueryTask(UserToken token, SocketModel model)
    {
        List<TaskData> tasks = CacheManager.instance.GetTaskDatas(token.characterid);
        RespTaskInfo resp = new RespTaskInfo();
        foreach (TaskData d in tasks)
        {
            TaskDTO dto = TaskData.GetTaskDTO(d);
            resp.task.Add(dto);
        }
        NetworkManager.Send(token, (int)MsgID.Info_SRES, resp);
    }
    // 接受任务
    public void OnAccessTask(UserToken token, SocketModel model)
    {
        ReqAddTask req = SerializeUtil.Deserialize<ReqAddTask>(model.message);
        List<TaskData> tasks = CacheManager.instance.GetTaskDatas(token.characterid);
        RespAddTask resp = new RespAddTask();
        // 是否拥有此任务
        bool isExistTask = false;
        for (int i = 0; i < tasks.Count; i++)
        {
            if (req.task_id == tasks[i].task_id)
            {
                isExistTask = true;
            }
        }
        // 没有此任务，可以添加
        if (!isExistTask)
        {
            resp.isSuccess = true;
            TaskDTO task = new TaskDTO();
            TaskCfg taskCfg = ConfigManager.instance._taskCfgs[req.task_id];
            task.task_id = taskCfg.ID;
            task.character_id = token.characterid;
            task.kill_monster_count = 0;
            resp.task = task;

            TaskData taskData = new TaskData();
            taskData.task_id = taskCfg.ID;
            taskData.character_id = token.characterid;
            taskData.kill_monster_count = 0;
            tasks.Add(taskData);
        }
        else
        {
            resp.isSuccess = false;
        }
        NetworkManager.Send(token, (int)MsgID.Receive_SRES, resp);
        
    }
    // 放弃任务
    public void OnGiveUpTask(UserToken token, SocketModel model)
    {
        ReqDeleteTask req = SerializeUtil.Deserialize<ReqDeleteTask>(model.message);
        List<TaskData> tasks = CacheManager.instance.GetTaskDatas(token.characterid);
        TaskData taskData = new TaskData();
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].task_id == req.task_id)
            {
                taskData = tasks[i];
            }
        }
        tasks.Remove(taskData);
        RespDeleteTask resp = new RespDeleteTask();
        resp.isSuccess = true;
        resp.task_id = req.task_id;
        NetworkManager.Send(token, (int)MsgID.Drop_SRES, resp);
    }
    // 完成任务
    public void OnCompleteTask(UserToken token, SocketModel model)
    {
        ReqCompleteTask req = SerializeUtil.Deserialize<ReqCompleteTask>(model.message);

        // 从个人缓存中移除此任务
        List<TaskData> tasks = CacheManager.instance.GetTaskDatas(token.characterid);
        TaskData task = CacheManager.instance.GetTaskData(token.characterid, req.task.task_id);
        tasks.Remove(task);
        CharacterData ch = CacheManager.instance.GetCharData(token.characterid);
        ch.gold += req.task_gold_award;

        // 编辑回复信息
        RespCompleteTask resp = new RespCompleteTask();
        resp.isSuccess = true;
        resp.task_id = req.task.task_id;
        resp.task_gold_award = req.task_gold_award;
        NetworkManager.Send(token, (int)MsgID.Drop_SRES, resp);

    }
    // 更新任务完成进度
    public void OnUpdateTask(UserToken token, SocketModel model)
    {
        ReqUpdateTask req = SerializeUtil.Deserialize<ReqUpdateTask>(model.message);

        List<TaskData> tasks = CacheManager.instance.GetTaskDatas(token.characterid);
        for (int i = 0; i < tasks.Count; i++)
        {
            tasks[i].kill_monster_count += req.count;
        }
    }
}

