
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UsePanel : MonoBehaviour
{
    private GameObject panel;
    private Button backBtn;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        EventManager.AddEvent<bool>(EventName.ShowUsePanel, this.ShowUsePanel);
        backBtn = transform.Find("BackBtn").GetComponent<Button>();
        backBtn.onClick.AddListener(() =>
        {
            EventManager.DispatchEvent<bool>(EventName.ShowBattleMenuPanel, true);
            ShowUsePanel(false);
        });
    }

    private void ClearUI()
    {
        for (int i = 0; i < transform.Find("Panel").childCount; i++)
        {
            var item = transform.Find("Panel").GetChild(i);
            Destroy(item.gameObject);
        }
    }
    private void ShowUsePanel(bool show)
    {
        if (show)
        {
            ClearUI();
            var prefab = Resources.Load<GameObject>("Prefabs/Arcade/GoodsItem");
            foreach (var item in GameData.Instance.items)
            {
                var goodsItem = ConfigData.goods.Find(ele => ele.GoodsID == item.Key);
                if (goodsItem == null) return;
                if (item.Value <= 0) return;
                if (goodsItem.GoodsTypeId == 3)
                {
                    var go = GameObject.Instantiate(prefab, transform.Find("Panel"));
                    var goodsNameText = go.transform.Find("Name").GetComponent<Text>();
                    var goodsDescText = go.transform.Find("Description").GetComponent<Text>();
                    var goodsCountText = go.transform.Find("Count").GetComponent<Text>();
                    var goodsButton = go.transform.Find("Button").GetComponent<Button>();
                    goodsNameText.text = goodsItem.GoodsName;
                    goodsDescText.text = goodsItem.GoodsDescribed;
                    goodsCountText.text = item.Value.ToString();
                    goodsButton.onClick.AddListener(() =>
                    {
                        if (goodsItem.GoodsID == 1004)
                        {
                            Tools.ShowTip("使用成功,生命值已恢复满");
                            int curLevel = PlayerData.GetInt(PlayerData.Level, 1);
                            int levelHp = ConfigData.levels.Find(ele => ele.id == curLevel).blood;
                            PlayerData.SetInt(PlayerData.Hp, levelHp);
                            GameData.Instance.UseItemByCount(1004, 1);
                            ShowUsePanel(false);
                        }
                        else
                        {
                            Tools.ShowTip("功能制作中");
                        }
                        EventManager.DispatchEvent(EventName.UpdateHpUI);
                        EventManager.DispatchEvent(EventName.SetNextRoundPlayerId);

                    });
                }
            }
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;
            EventManager.DispatchEvent<bool>(EventName.ShowBattleMenuPanel, true);
        }

    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowUsePanel, this.ShowUsePanel);

    }
}