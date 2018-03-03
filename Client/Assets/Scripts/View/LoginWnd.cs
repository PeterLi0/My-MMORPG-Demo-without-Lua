﻿
using UnityEngine;
using UnityEngine.UI;
using proto.account;

public class LoginWnd : BaseWnd
{
    private InputField _account;

    private InputField _pwd;


    public void Initialize()
    {
        Button btnLogin = _transform.FindChild("BtnLogin").GetComponent<Button>();
        btnLogin.onClick.AddListener(OnBtnLoginClick);

        Button btnRegister = _transform.FindChild("BtnRegister").GetComponent<Button>();
        btnRegister.onClick.AddListener(OnBtnRegisterClick);

        _account = _transform.FindChild("Acc").GetComponent<InputField>();
        _pwd = _transform.FindChild("Pwd").GetComponent<InputField>();
    }

    private void OnBtnLoginClick()
    {
        ReqLogin req = new ReqLogin();


        req.account = _account.text;
        req.password = _pwd.text;
        Debug.Log(string.Format("{0},{1}", req.account, req.password));
        NetworkManager.instance.Send((int)MsgID.ACC_LOGIN_CREQ, req);
    }

    private void OnBtnRegisterClick()
    {
        if(string.IsNullOrEmpty(_account.text) || string.IsNullOrEmpty(_pwd.text))
        {
            MessageBox.Show("账号或者密码不能为空");
            return;
        }

        if(_account.text.Contains("'\'") || _account.text.Contains("'"))
        {
            MessageBox.Show("账号或者密码包含非法字符");
            return;
        }

        ReqRegister req = new ReqRegister();
        req.account = _account.text;
        req.password = _pwd.text;

        NetworkManager.instance.Send((int)MsgID.ACC_REG_CREQ, req);
    }
}