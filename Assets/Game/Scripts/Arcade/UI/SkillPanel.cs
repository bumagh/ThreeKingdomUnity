
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
    void Awake()
    {
        panel = transform.Find("Panel").gameObject;
        detailTrans = transform.Find("Panel/SkillDetail");
        typeTrans = transform.Find("Panel/SkillTypes");

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