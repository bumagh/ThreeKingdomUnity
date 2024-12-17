
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BagPanel : MonoBehaviour
{
    private GameObject panel;
    private Button backBtn;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        EventManager.AddEvent<bool>(EventName.ShowBagPanel, this.ShowBagPanel);
        backBtn = transform.Find("Panel/BackBtn").GetComponent<Button>();
        backBtn.onClick.AddListener(() =>
        {
            EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, true);
            ShowBagPanel(false);
        });
    }

    private void ClearUI()
    {
        for (int i = 0; i < transform.Find("Panel/Content").childCount; i++)
        {
            var item = transform.Find("Panel/Content").GetChild(i);
            Destroy(item.gameObject);
        }
    }
    private void ShowBagPanel(bool show)
    {
        panel.SetActive(show);
        if (show)
        {
            ClearUI();
            var prefab = Resources.Load<GameObject>("Prefabs/Arcade/GoodsItem");
            foreach (var item in GameData.Instance.items)
            {
                var goodsItem = ConfigData.goods.Find(ele => ele.GoodsID == item.Key);
                if (goodsItem == null) return;
                if (item.Value <= 0) return;
                if (goodsItem.GoodsTypeId != 1)
                {
                    var go = GameObject.Instantiate(prefab, transform.Find("Panel/Content"));
                    var goodsNameText = go.transform.Find("Name").GetComponent<Text>();
                    var goodsDescText = go.transform.Find("Description").GetComponent<Text>();
                    var goodsCountText = go.transform.Find("Count").GetComponent<Text>();
                    var goodsButton = go.transform.Find("Button").GetComponent<Button>();
                    goodsNameText.text = goodsItem.GoodsName;
                    goodsDescText.text = goodsItem.GoodsDescribed;
                    goodsCountText.text = item.Value.ToString()+"个";
                    goodsButton.onClick.AddListener(() =>
                    {
                        if (goodsItem.GoodsID == 1004)
                        {
                            Tools.ShowTip("使用成功,生命值已恢复满");
                            int curLevel = PlayerData.GetInt(PlayerData.Level, 1);
                            int levelHp = ConfigData.levels.Find(ele => ele.id == curLevel).blood;
                            PlayerData.SetInt(PlayerData.Hp, levelHp);
                            GameData.Instance.UseItemByCount(1004, 1);
                            ShowBagPanel(true);
                        }
                        else
                        {
                            if (goodsItem.GoodsTypeId == (int)GoodsTypeEnums.Equipment)
                            {
                                Tools.ShowTip("装备成功!");
                                GameData.Instance.UseItemByCount(goodsItem.GoodsID, 1);
                                ShowBagPanel(true);
                                GameData.Instance.LoadEquip(goodsItem.GoodsID);
                            }
                            else
                                Tools.ShowTip("功能制作中");
                        }
                    });
                }
            }
        }
    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowBagPanel, this.ShowBagPanel);

    }
}