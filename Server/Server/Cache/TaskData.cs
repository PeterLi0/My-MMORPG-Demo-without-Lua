using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;


/// <summary>
/// 任务数据
/// </summary>
public class TaskData
{
    public int id;
    public int character_id;
    public int task_id;
    public int kill_monster_count;
    public TaskData()
    {

    }
    public TaskData(int id, int character_id, int task_id, int kill_monster_count)
    {
        this.id = id;
        this.character_id = character_id;
        this.task_id = task_id;
        this.kill_monster_count = kill_monster_count;
    }

    public static TaskDTO GetTaskDTO(TaskData d)
    {
        TaskDTO dto = new TaskDTO();
        dto.id = d.id;
        dto.character_id = d.character_id;
        dto.task_id = d.task_id;
        dto.kill_monster_count = d.kill_monster_count;

        return dto;
    }
}
partial class CacheManager
{
    // 任务数据
    private Dictionary<int, List<TaskData>> _tasks = new Dictionary<int, List<TaskData>>();

    /// <summary>
    /// 载入任务数据
    /// </summary>
    /// <param name="characterid"></param>
    public void LoadTaskData(int characterid)
    {
        string sql = string.Format("SELECT * from t_task WHERE character_id = {0}", characterid);
        List<TaskData> tasks = MysqlManager.instance.ExecQuery<TaskData>(sql);

        _tasks.Add(characterid, tasks);
    }

    // 删除任务
    public void DeleteTask(int character_id, int task_id)
    {
        List<TaskData> tasks = _tasks[character_id];

        TaskData data = null;
        foreach (TaskData task in tasks)
        {
            if (task.character_id == character_id && task.task_id == task_id)
            {
                data = task;
            }
        }
        tasks.Remove(data);
    }

    public void WriteTaskData(int character_id)
    {
        List<TaskData> tasks = _tasks[character_id];

        // 删除数据库中的装备数据
        string sql = string.Format("DELETE FROM t_task WHERE character_id = {0}", character_id);
        MysqlManager.instance.ExecNonQuery(sql);

        // 将缓存中的数据插入到数据库中
        for (int i = 0; i < tasks.Count; i++)
        {
            TaskData task = tasks[i];
            sql = string.Format("INSERT INTO t_task (character_id, task_id, kill_monster_count) VALUES ({0}, {1}, {2})", character_id, task.task_id, task.kill_monster_count);
            MysqlManager.instance.ExecNonQuery(sql);
        }
    }
    // 根据角色id和任务id获取角色任务数据
    public TaskData GetTaskData(int character_id, int task_id)
    {
        List<TaskData> tasks = _tasks[character_id];

        foreach (TaskData data in tasks)
        {
            if (data.task_id == task_id && data.character_id == character_id)
                return data;
        }
        return null;
    }
    public List<TaskData> GetTaskDatas(int character_id)
    {
        return _tasks[character_id];

    }
}

