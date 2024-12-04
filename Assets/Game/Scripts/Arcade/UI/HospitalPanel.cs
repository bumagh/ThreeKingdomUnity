
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HospitalPanel : MonoBehaviour
{
    private GameObject panel;
    private Button oneKeyCureBtn;
    private Button item1Btn;
    private Button backBtn;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        EventManager.AddEvent<bool>(EventName.ShowHospitalPanel, this.ShowHospitalPanel);
        oneKeyCureBtn = transform.Find("Panel/Content/OneKeyItem/Button").GetComponent<Button>();
        oneKeyCureBtn.onClick.AddListener(() =>
        {
            int curLevel = PlayerData.GetInt(PlayerData.Level, 1);
            int levelHp = ConfigData.levels.Find(ele => ele.id == curLevel).blood;
            PlayerData.SetInt(PlayerData.Hp, levelHp);
            //TODO:MP
        });

        backBtn = transform.Find("Panel/BackBtn").GetComponent<Button>();
        backBtn.onClick.AddListener(() =>
        {
            EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, true);
            ShowHospitalPanel(false);
        });
        item1Btn = transform.Find("Panel/Content/Goods1Item/Button").GetComponent<Button>();
        item1Btn.onClick.AddListener(() =>
        {
            //判断当前金币是否大于一
            if (PlayerData.GetInt(PlayerData.Coin, 0) < 1)
            {
                Tools.ShowTip("金币为0,购买失败");
            }
            else
            {
                GameData.Instance.UseItemByCount(1001, 1);
                PlayerData.SetInt(PlayerData.Coin, PlayerData.GetInt(PlayerData.Coin) - 1);
                Tools.ShowTip("购买回命丹成功,金币-1");
            }
        });
    }

    private void ShowHospitalPanel(bool show)
    {
        panel.SetActive(show);
    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowHospitalPanel, this.ShowHospitalPanel);

    }
}