
using System;
using UnityEngine;
using UnityEngine.UI;
public class BattleMenuPanel : MonoBehaviour
{
    private GameObject panel;
    private Button atkBtn;
    private Text menuTipText;
    private Button cancelBtn;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        atkBtn = transform.Find("Panel/AtkBtn").GetComponent<Button>();
        cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();
        menuTipText = transform.Find("MenuTip").GetComponent<Text>();
        EventManager.AddEvent<bool>(EventName.ShowBattleMenuPanel, this.ShowBattleMenuPanel);
        atkBtn.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            cancelBtn.gameObject.SetActive(true);
            menuTipText.text = "请选择需要攻击的敌人";
        });
        cancelBtn.onClick.AddListener(() =>
        {
            cancelBtn.gameObject.SetActive(false);
            panel.SetActive(true);
            menuTipText.text = "";
        });
    }

    private void ShowBattleMenuPanel(bool show)
    {
        panel.SetActive(show);
        cancelBtn.gameObject.SetActive(false);
        menuTipText.gameObject.SetActive(show);
    }

    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowBattleMenuPanel, this.ShowBattleMenuPanel);

    }
}