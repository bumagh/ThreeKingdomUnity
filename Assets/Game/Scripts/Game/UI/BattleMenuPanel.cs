
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BattleMenuPanel : MonoBehaviour
{
    private GameObject panel;
    private Button atkBtn;
    private Button useBtn;
    private Button runBtn;
    private Text menuTipText;
    private Button cancelBtn;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        atkBtn = transform.Find("Panel/AtkBtn").GetComponent<Button>();
        useBtn = transform.Find("Panel/UseBtn").GetComponent<Button>();
        runBtn = transform.Find("Panel/RunBtn").GetComponent<Button>();
        cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();
        menuTipText = transform.Find("MenuTip").GetComponent<Text>();
        EventManager.AddEvent<bool>(EventName.ShowBattleMenuPanel, this.ShowBattleMenuPanel);
        atkBtn.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            cancelBtn.gameObject.SetActive(true);
            menuTipText.text = "请选择需要攻击的敌人";
            EventManager.DispatchEvent<bool>(EventName.SetLocalBattleState, true);
        });
        useBtn.onClick.AddListener(() =>
            {
                panel.SetActive(false);
                menuTipText.text = "请选择要使用的物品";
                EventManager.DispatchEvent<bool>(EventName.ShowUsePanel, true);
            });
        runBtn.onClick.AddListener(() =>
     {
         //TODO:增加逃跑概率
         EventManager.DispatchEvent(EventName.SetGamingState);
         Tools.ShowConfirm("逃跑成功", () =>
            {
                SceneManager.LoadScene("Arcade");
            }, () =>
            {
                SceneManager.LoadScene("Arcade");
            });
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
        if (show)
        {
            menuTipText.text = "";
        }
    }

    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowBattleMenuPanel, this.ShowBattleMenuPanel);

    }
}