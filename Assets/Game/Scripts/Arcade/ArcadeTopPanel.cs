
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadeTopPanel : MonoBehaviour
{
    private Text nameText;
    private Text coinText;
    private Text levelText;
    private Text expText;
    private Text soldierText;
    private Text jobText;
    private Text hpText;
    private Text mpText;
    private Text atkText;
    private Text defText;
    private Text spText;
    private GameObject rightInfo;
    private GameObject personItems;
    private GameObject facilityItems;
    private GameObject mapItems;
    private GameObject funcItems;
    private Button bagBtn;
    private Button rankBtn;
    private Button shopBtn;
    private Button exitBtn;
    private Button bankBtn;
    private Button equipBtn;
    private Button skillBtn;
    private Button soldierBtn;


    void Awake()
    {
        nameText = transform.Find("LeftInfo/AttrValue/Name").GetComponent<Text>();
        coinText = transform.Find("LeftInfo/AttrValue/Coin").GetComponent<Text>();
        levelText = transform.Find("LeftInfo/AttrValue/Level").GetComponent<Text>();
        expText = transform.Find("LeftInfo/AttrValue/Exp").GetComponent<Text>();
        soldierText = transform.Find("LeftInfo/AttrValue/Soldier").GetComponent<Text>();
        jobText = transform.Find("LeftInfo/AttrValue/Job").GetComponent<Text>();
        hpText = transform.Find("LeftInfo/AttrValue/Hp").GetComponent<Text>();
        mpText = transform.Find("LeftInfo/AttrValue/Mp").GetComponent<Text>();
        atkText = transform.Find("LeftInfo/AttrValue/Atk").GetComponent<Text>();
        defText = transform.Find("LeftInfo/AttrValue/Def").GetComponent<Text>();
        spText = transform.Find("LeftInfo/AttrValue/Sp").GetComponent<Text>();

        bagBtn = transform.Find("RightInfo/FuncItems/BagBtn").GetComponent<Button>();
        rankBtn = transform.Find("RightInfo/FuncItems/RankBtn").GetComponent<Button>();
        shopBtn = transform.Find("RightInfo/FuncItems/ShopBtn").GetComponent<Button>();
        exitBtn = transform.Find("RightInfo/FuncItems/ExitBtn").GetComponent<Button>();

        bankBtn = transform.Find("RightInfo/FacilityItems/BankBtn").GetComponent<Button>();
        equipBtn = transform.Find("RightInfo/FacilityItems/EquipBtn").GetComponent<Button>();
        soldierBtn = transform.Find("RightInfo/FacilityItems/SoldierBtn").GetComponent<Button>();
        skillBtn = transform.Find("RightInfo/FacilityItems/SkillBtn").GetComponent<Button>();

        bagBtn.onClick.AddListener(() =>
        {
            EventManager.DispatchEvent<bool>(EventName.ShowBagPanel, true);
            EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, false);

        });
        rankBtn.onClick.AddListener(() =>
        {
            Tools.ShowTip("功能开发中");
        });
        shopBtn.onClick.AddListener(() =>
        {
            Tools.ShowTip("功能开发中");
        });
        exitBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Login");
        });

        bankBtn.onClick.AddListener(() =>
        {
            EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, false);
            EventManager.DispatchEvent<bool>(EventName.ShowBankPanel, true);
        });
        equipBtn.onClick.AddListener(() =>
               {
                   EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, false);
                   EventManager.DispatchEvent<bool>(EventName.ShowEquipPanel, true);
               });
        soldierBtn.onClick.AddListener(() =>
        {
            Tools.ShowTip("功能开发中");
        });
        skillBtn.onClick.AddListener(() =>
                    {
                        EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, false);
                        EventManager.DispatchEvent<bool>(EventName.ShowSkillPanel, true);
                    });
        rightInfo = transform.Find("RightInfo").gameObject;
        personItems = transform.Find("RightInfo/PersonItems").gameObject;
        facilityItems = transform.Find("RightInfo/FacilityItems").gameObject;
        mapItems = transform.Find("RightInfo/MapItems").gameObject;
        funcItems = transform.Find("RightInfo/FuncItems").gameObject;
        EventManager.AddEvent<bool>(EventName.ShowHomePanel, this.ShowHomePanel);
        EventManager.AddEvent<CenterBtnEnums>(EventName.TopPanelUpdate, this.TopPanelUpdate);
        Init();
    }

    private void Init()
    {
        nameText.text = PlayerData.GetString(PlayerData.NickName, "三国新人");
        coinText.text = PlayerData.GetInt(PlayerData.Coin, 100).ToString();
        levelText.text = PlayerData.GetInt(PlayerData.Level, 1).ToString();
        expText.text = PlayerData.GetInt(PlayerData.Exp, 0).ToString();
        jobText.text = PlayerData.GetString(PlayerData.Job, "武士");
        hpText.text = PlayerData.GetInt(PlayerData.Hp, 100).ToString();
        mpText.text = PlayerData.GetInt(PlayerData.Mp, 100).ToString();
        atkText.text = PlayerData.GetInt(PlayerData.Atk, 10).ToString();
        defText.text = PlayerData.GetInt(PlayerData.Def, 1).ToString();
        spText.text = PlayerData.GetInt(PlayerData.Sp, 1).ToString();
    }
    private void TopPanelUpdate(CenterBtnEnums enums)
    {
        switch (enums)
        {
            case CenterBtnEnums.PersonItems:
                personItems.SetActive(true);
                facilityItems.SetActive(false);
                mapItems.SetActive(false);
                funcItems.SetActive(false);
                break;
            case CenterBtnEnums.FacilityItems:
                personItems.SetActive(false);
                facilityItems.SetActive(true);
                mapItems.SetActive(false);
                funcItems.SetActive(false);
                break;
            case CenterBtnEnums.MapItems:
                personItems.SetActive(false);
                facilityItems.SetActive(false);
                mapItems.SetActive(true);
                funcItems.SetActive(false);
                break;
            case CenterBtnEnums.FuncItems:
                personItems.SetActive(false);
                facilityItems.SetActive(false);
                mapItems.SetActive(false);
                funcItems.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void ShowHomePanel(bool show)
    {
        if (show)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;

        }
        Init();
    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowHomePanel, this.ShowHomePanel);
        EventManager.RemoveEvent<CenterBtnEnums>(EventName.TopPanelUpdate, this.TopPanelUpdate);

    }
}