
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    private GameObject panel;
    private Button backBtn;
    private Transform detailTrans;
    private Transform typeTrans;
    private Button masterSkillBtn;
    private Button soldierSkillBtn;

    private GameObject wuShi;
    private GameObject wenRen;
    private GameObject shuShi;
    private GameObject shanRen;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        detailTrans = transform.Find("Panel/SkillDetail");
        typeTrans = transform.Find("Panel/SkillTypes");
        masterSkillBtn = transform.Find("Panel/SkillTypes/MasterSkill/Button").GetComponent<Button>();
        soldierSkillBtn = transform.Find("Panel/SkillTypes/SoldierSkill/Button").GetComponent<Button>();

        wuShi = transform.Find("Panel/SkillDetail/WuShi").gameObject;
        wenRen = transform.Find("Panel/SkillDetail/WenRen").gameObject;
        shuShi = transform.Find("Panel/SkillDetail/ShuShi").gameObject;
        shanRen = transform.Find("Panel/SkillDetail/ShanRen").gameObject;
        EventManager.AddEvent<bool>(EventName.ShowSkillPanel, this.ShowPanel);
        backBtn = transform.Find("Panel/BackBtn").GetComponent<Button>();

        backBtn.onClick.AddListener(() =>
        {
            if (typeTrans.gameObject.activeSelf)
            {
                EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, true);
                ShowPanel(false);
            }
            else
            {
                typeTrans.gameObject.SetActive(true);
                detailTrans.gameObject.SetActive(false);
            }

        });

        masterSkillBtn.onClick.AddListener(() =>
        {
            typeTrans.gameObject.SetActive(false);
            detailTrans.gameObject.SetActive(true);
            ShowSkillDetailMaster();

        });
        soldierSkillBtn.onClick.AddListener(() =>
    {
        typeTrans.gameObject.SetActive(false);
        detailTrans.gameObject.SetActive(true);
    });
    }
    private void ShowSkillDetailMaster()
    {
        var curJob = PlayerData.GetString(PlayerData.Job, "武士");
        if (curJob == "武士")
        {
            wuShi.SetActive(true);
            wenRen.SetActive(false);
            shuShi.SetActive(false);
            shanRen.SetActive(false);
        }
        if (curJob == "文人")
        {
            wuShi.SetActive(false);
            wenRen.SetActive(true);
            shuShi.SetActive(false);
            shanRen.SetActive(false);
        }
        if (curJob == "术士")
        {
            wuShi.SetActive(false);
            wenRen.SetActive(false);
            shuShi.SetActive(true);
            shanRen.SetActive(false);
        }
        if (curJob == "商人")
        {
            wuShi.SetActive(false);
            wenRen.SetActive(false);
            shuShi.SetActive(false);
            shanRen.SetActive(true);
        }
    }
    void Start()
    {


    }
    private void ShowPanel(bool show)
    {
        if (show)
            panel.transform.localScale = Vector3.one;
        else
            panel.transform.localScale = Vector3.zero;

    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowSkillPanel, this.ShowPanel);

    }
}