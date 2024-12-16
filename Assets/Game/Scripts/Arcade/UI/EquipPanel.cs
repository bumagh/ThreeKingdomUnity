
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EquipPanel : MonoBehaviour
{
    private GameObject panel;
    private Button backBtn;
    private Button[] equipBtns = new Button[6];
    private string[] equipStrs = new string[] { "Helmet", "Weapon", "Boots", "Armor", "Necklace", "Wristband" };
    private Transform detailTrans;
    private Transform typeTrans;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        detailTrans = transform.Find("Panel/EquipDetail");
        typeTrans = transform.Find("Panel/EquipTypes");
        for (int i = 0; i < equipStrs.Length; i++)
        {
            equipBtns[i] = transform.Find("Panel/EquipTypes/" + equipStrs[i] + "/Button").GetComponent<Button>();
        }

        EventManager.AddEvent<bool>(EventName.ShowEquipPanel, this.ShowEquipPanel);
        backBtn = transform.Find("Panel/BackBtn").GetComponent<Button>();

        backBtn.onClick.AddListener(() =>
        {
            if (typeTrans.gameObject.activeSelf)
            {
                EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, true);
                ShowEquipPanel(false);
            }
            else
            {
                typeTrans.gameObject.SetActive(true);
                detailTrans.gameObject.SetActive(false);
            }

        });

    }
    void Start()
    {

        for (int i = 0; i < equipStrs.Length; i++)
        {
            int index = i;
            equipBtns[i].onClick.AddListener(() =>
            {
                typeTrans.gameObject.SetActive(false);
                detailTrans.gameObject.SetActive(true);
                ClearUI();
                var prefab = Resources.Load<GameObject>("Prefabs/Arcade/GoodsItem");
                var goodsItem = ConfigData.goods.Find(ele => ele.GoodsTypeId == 6 && ele.GoodsTypeChild == (index + 1));
                var go = GameObject.Instantiate(prefab, detailTrans);
                var goodsNameText = go.transform.Find("Name").GetComponent<Text>();
                var goodsDescText = go.transform.Find("Description").GetComponent<Text>();
                var goodsCountText = go.transform.Find("Count").GetComponent<Text>();
                var goodsButton = go.transform.Find("Button").GetComponent<Button>();
                var goodsButtonText = go.transform.Find("Button/Text").GetComponent<Text>();
                goodsButtonText.text = "购买";
                goodsNameText.text = goodsItem.GoodsName;
                goodsDescText.text = goodsItem.GoodsDescribed;
                goodsCountText.text = goodsItem.Price.ToString() + "金币";
                goodsButton.onClick.AddListener(() =>
                {
                    if (PlayerData.GetInt(PlayerData.Coin, 100) < goodsItem.Price)
                    {
                        Tools.ShowTip("金币不足,购买失败");
                    }
                    else
                    {
                        GameData.Instance.UseItemByCount(1001, 1);
                        PlayerData.SetInt(PlayerData.Coin, PlayerData.GetInt(PlayerData.Coin, 100) - goodsItem.Price);
                        Tools.ShowTip("购买" + goodsItem.GoodsName + "成功,金币-" + goodsItem.Price);
                        GameData.Instance.AddItemToKnapsack(goodsItem.GoodsID, 1);
                    }
                    // if (goodsItem.GoodsID == 1004)
                    // {
                    //     Tools.ShowTip("使用成功,生命值已恢复满");
                    //     int curLevel = PlayerData.GetInt(PlayerData.Level, 1);
                    //     int levelHp = ConfigData.levels.Find(ele => ele.id == curLevel).blood;
                    //     PlayerData.SetInt(PlayerData.Hp, levelHp);
                    //     GameData.Instance.UseItemByCount(1004, 1);
                    //     ShowBagPanel(true);
                    // }
                    // else
                });
            });
        }

    }

    private void ClearUI()
    {
        for (int i = 0; i < detailTrans.childCount; i++)
        {
            var item = detailTrans.GetChild(i);
            Destroy(item.gameObject);
        }
    }
    private void ShowEquipPanel(bool show)
    {
        if (show)
            panel.transform.localScale = Vector3.one;
        else
            panel.transform.localScale = Vector3.zero;

    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowEquipPanel, this.ShowEquipPanel);

    }
}