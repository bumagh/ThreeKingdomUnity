
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EquipPanel : MonoBehaviour
{
    private GameObject panel;
    private Button backBtn;
    private Button helmetBtn;
    private Button weaponBtn;
    private Button bootsBtn;
    private Button armorBtn;
    private Button necklaceBtn;
    private Button wristbandBtn;
    private Transform detailTrans;
    private Transform typeTrans;
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        detailTrans = transform.Find("Panel/EquipDetail");
        typeTrans = transform.Find("Panel/EquipTypes");
        helmetBtn = transform.Find("Panel/EquipTypes/Helmet/Button").GetComponent<Button>();
        weaponBtn = transform.Find("Panel/EquipTypes/Weapon/Button").GetComponent<Button>();
        bootsBtn = transform.Find("Panel/EquipTypes/Boots/Button").GetComponent<Button>();
        armorBtn = transform.Find("Panel/EquipTypes/Armor/Button").GetComponent<Button>();
        necklaceBtn = transform.Find("Panel/EquipTypes/Necklace/Button").GetComponent<Button>();
        wristbandBtn = transform.Find("Panel/EquipTypes/Wristband/Button").GetComponent<Button>();
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
        weaponBtn.onClick.AddListener(() =>
        {
            typeTrans.gameObject.SetActive(false);
            detailTrans.gameObject.SetActive(true);
        });
        helmetBtn.onClick.AddListener(() =>
       {
           typeTrans.gameObject.SetActive(false);
           detailTrans.gameObject.SetActive(true);
       });
        bootsBtn.onClick.AddListener(() =>
       {
           typeTrans.gameObject.SetActive(false);
           detailTrans.gameObject.SetActive(true);
       });
        armorBtn.onClick.AddListener(() =>
       {
           typeTrans.gameObject.SetActive(false);
           detailTrans.gameObject.SetActive(true);
       });
        necklaceBtn.onClick.AddListener(() =>
       {
           typeTrans.gameObject.SetActive(false);
           detailTrans.gameObject.SetActive(true);
       });
        wristbandBtn.onClick.AddListener(() =>
       {
           typeTrans.gameObject.SetActive(false);
           detailTrans.gameObject.SetActive(true);
       });
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
        panel.SetActive(show);
    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowEquipPanel, this.ShowEquipPanel);

    }
}