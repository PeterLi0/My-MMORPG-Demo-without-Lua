using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using common;

public class SelectRoleWnd : BaseWnd
{
    public class ButtonClickListener : MonoBehaviour, IPointerClickHandler
    {
        public CharacterDTO dto;

        public void OnPointerClick(PointerEventData eventData)
        {
            DataCache.instance.currentCharacter = dto;
            SelectRole.instance.Select(dto.id);
        }
    }

    public class DragEventListener : MonoBehaviour, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            SelectRole.instance.RotateRole(eventData.delta.x);
        }
    }

    public void Initialize()
    {

        Button btnReturn = _transform.FindChild("BtnReturn").GetComponent<Button>();
        btnReturn.onClick.AddListener(OnReturn);

        Button btnEnterGame = _transform.FindChild("BtnEnterGame").GetComponent<Button>();
        btnEnterGame.onClick.AddListener(OnEnterGame);

        Transform content = _transform.FindChild("Scroll View/Viewport/Content");
        Button btnClone = _transform.FindChild("Scroll View/Viewport/BtnRole").GetComponent<Button>();

        // 获取该账号下的所有角色
        List<CharacterDTO> chDTOs = DataCache.instance.chDtos;
        foreach (CharacterDTO dto in chDTOs)
        {
            Transform btnRole = (GameObject.Instantiate(btnClone.gameObject) as GameObject).transform;
            btnRole.SetParent(content);
            btnRole.localScale = Vector3.one;
            btnRole.localPosition = Vector3.zero;
            btnRole.gameObject.SetActive(true);

            Text ID = btnRole.FindChild("ID").GetComponent<Text>();
            ID.text = dto.id.ToString();

            Text name = btnRole.FindChild("Name").GetComponent<Text>();
            name.text = dto.name;

            btnRole.gameObject.AddComponent<ButtonClickListener>().dto = dto;
        }

        _transform.FindChild("Image").gameObject.AddComponent<DragEventListener>();
    }

    private void OnReturn()
    {
        WindowManager.instance.Close<SelectRoleWnd>();
        SelectRole.instance.ShowCreateRole();
    }

    private void OnEnterGame()
    {
        SelectRole.instance.Finalise();
        Loading.instance.LoadScene("MainCity");
    }
}