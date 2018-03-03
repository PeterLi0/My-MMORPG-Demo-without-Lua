using System;
using System.Collections.Generic;

using UnityEngine;

public interface IMsgHandler
{
    void RegisterMsg(Dictionary<MsgID, Action<SocketModel>> handlers);
}


public class HandlerCenter : IHandlerCenter
{
    private Dictionary<MsgID, Action<SocketModel>> _handlers = new Dictionary<MsgID, Action<SocketModel>>();

    private AccountHandler _accountHandler;

    private CharacterHandler _characterHandler;

    private WorldHandler _worldHandler;

    private MailHandler _mailHandler;

    private InventroyHandler _inventroyHandler;

    private TaskHandler _taskHandler;

    private MallHandler _mallHandler;
    public void Initialize()
    {
        _accountHandler = new AccountHandler();
        _accountHandler.RegisterMsg(_handlers);

        _characterHandler = new CharacterHandler();
        _characterHandler.RegisterMsg(_handlers);

        _worldHandler = new WorldHandler();
        _worldHandler.RegisterMsg(_handlers);

        _mailHandler = new MailHandler();
        _mailHandler.RegisterMsg(_handlers);

        _inventroyHandler = new InventroyHandler();
        _inventroyHandler.RegisterMsg(_handlers);

        _taskHandler = new TaskHandler();
        _taskHandler.RegisterMsg(_handlers);

        _mallHandler = new MallHandler();
        _mallHandler.RegisterMsg(_handlers);
    }

    public void MessageReceive(SocketModel model)
    {
        Debug.Log((MsgID)model.command);
        Action<SocketModel> handler = _handlers[(MsgID)model.command];
        handler(model);
    }
}