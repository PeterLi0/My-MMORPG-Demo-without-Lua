//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: proto/task.proto
// Note: requires additional types generated from: common.proto
namespace task
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReqTaskInfo")]
  public partial class ReqTaskInfo : global::ProtoBuf.IExtensible
  {
    public ReqTaskInfo() {}
    
    private int _task_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"task_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int task_id
    {
      get { return _task_id; }
      set { _task_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RespTaskInfo")]
  public partial class RespTaskInfo : global::ProtoBuf.IExtensible
  {
    public RespTaskInfo() {}
    
    private readonly global::System.Collections.Generic.List<common.TaskDTO> _task = new global::System.Collections.Generic.List<common.TaskDTO>();
    [global::ProtoBuf.ProtoMember(1, Name=@"task", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<common.TaskDTO> task
    {
      get { return _task; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReqAddTask")]
  public partial class ReqAddTask : global::ProtoBuf.IExtensible
  {
    public ReqAddTask() {}
    
    private int _task_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"task_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int task_id
    {
      get { return _task_id; }
      set { _task_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RespAddTask")]
  public partial class RespAddTask : global::ProtoBuf.IExtensible
  {
    public RespAddTask() {}
    
    private bool _isSuccess;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"isSuccess", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isSuccess
    {
      get { return _isSuccess; }
      set { _isSuccess = value; }
    }
    private common.TaskDTO _task;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"task", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public common.TaskDTO task
    {
      get { return _task; }
      set { _task = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReqDeleteTask")]
  public partial class ReqDeleteTask : global::ProtoBuf.IExtensible
  {
    public ReqDeleteTask() {}
    
    private int _task_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"task_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int task_id
    {
      get { return _task_id; }
      set { _task_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RespDeleteTask")]
  public partial class RespDeleteTask : global::ProtoBuf.IExtensible
  {
    public RespDeleteTask() {}
    
    private bool _isSuccess;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"isSuccess", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isSuccess
    {
      get { return _isSuccess; }
      set { _isSuccess = value; }
    }
    private int _task_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"task_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int task_id
    {
      get { return _task_id; }
      set { _task_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReqCompleteTask")]
  public partial class ReqCompleteTask : global::ProtoBuf.IExtensible
  {
    public ReqCompleteTask() {}
    
    private common.TaskDTO _task;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"task", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public common.TaskDTO task
    {
      get { return _task; }
      set { _task = value; }
    }
    private int _task_gold_award;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"task_gold_award", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int task_gold_award
    {
      get { return _task_gold_award; }
      set { _task_gold_award = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RespCompleteTask")]
  public partial class RespCompleteTask : global::ProtoBuf.IExtensible
  {
    public RespCompleteTask() {}
    
    private bool _isSuccess;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"isSuccess", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool isSuccess
    {
      get { return _isSuccess; }
      set { _isSuccess = value; }
    }
    private int _task_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"task_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int task_id
    {
      get { return _task_id; }
      set { _task_id = value; }
    }
    private int _task_gold_award;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"task_gold_award", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int task_gold_award
    {
      get { return _task_gold_award; }
      set { _task_gold_award = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ReqUpdateTask")]
  public partial class ReqUpdateTask : global::ProtoBuf.IExtensible
  {
    public ReqUpdateTask() {}
    
    private int _count;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int count
    {
      get { return _count; }
      set { _count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}