
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BankPanel : MonoBehaviour
{
    private GameObject panel;
    private Button backBtn;
    private Button giveBtn;
    private Text curCoinText;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        curCoinText = transform.Find("Panel/Content/CurCoin/Value").GetComponent<Text>();
        giveBtn = transform.Find("Panel/Content/GiveDev/Button").GetComponent<Button>();
        EventManager.AddEvent<bool>(EventName.ShowBankPanel, this.ShowBankPanel);
        backBtn = transform.Find("Panel/BackBtn").GetComponent<Button>();
        curCoinText.text = PlayerData.GetInt(PlayerData.Coin, 0).ToString();

        backBtn.onClick.AddListener(() =>
        {
            EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, true);
            ShowBankPanel(false);
        });
        giveBtn.onClick.AddListener(() =>
        {
            Tools.ShowTip("赞赏成功,获得金币1000");
            PlayerData.SetInt(PlayerData.Coin, PlayerData.GetInt(PlayerData.Coin, 0) + 1000);
            curCoinText.text = PlayerData.GetInt(PlayerData.Coin, 0).ToString();
        });
    }


    private void ShowBankPanel(bool show)
    {
        panel.SetActive(show);
    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowBankPanel, this.ShowBankPanel);

    }
}