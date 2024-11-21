
using System;
using UnityEngine;
using UnityEngine.UI;
public class BattleMenuPanel : MonoBehaviour
{
    private GameObject panel;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        EventManager.AddEvent<bool>(EventName.ShowBattleMenuPanel, this.ShowBattleMenuPanel);
    }

    private void ShowBattleMenuPanel(bool show)
    {
        panel.SetActive(show);
    }

    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowBattleMenuPanel, this.ShowBattleMenuPanel);

    }
}