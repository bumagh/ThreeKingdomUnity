
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadeController : MonoBehaviour
{
    private Button fightBtn;
    private Text mapStrText;
    private Button hospitalBtn;

    void Awake()
    {
        fightBtn = GameObject.Find("Canvas/HomePanel/TopPanel/RightInfo/PersonItems/PersonItem/Button").GetComponent<Button>();
        mapStrText = GameObject.Find("Canvas/HomePanel/TopPanel/TopMapStr").GetComponent<Text>();
        hospitalBtn = GameObject.Find("Canvas/HomePanel/TopPanel/RightInfo/FacilityItems/HospitalBtn").GetComponent<Button>();

        fightBtn.onClick.AddListener(() =>
        {
            if (PlayerData.GetInt(PlayerData.Hp, 1) <= 1)
            {
                Tools.ShowConfirm("当前血量值过低,是否继续战斗?", () =>
                {
                    SceneManager.LoadScene("Game");
                });
            }
            else

                SceneManager.LoadScene("Game");
        });
        hospitalBtn.onClick.AddListener(() =>
              {
                  EventManager.DispatchEvent<bool>(EventName.ShowHospitalPanel, true);
                  EventManager.DispatchEvent<bool>(EventName.ShowHomePanel, false);
              });


        PlayerData.SetString(PlayerData.CurMap, "新手村");

        mapStrText.text = PlayerData.GetString(PlayerData.CurMap, "新手村");
        EventManager.DispatchEvent<CenterBtnEnums>(EventName.TopPanelUpdate, CenterBtnEnums.PersonItems);

    }


    async void Start()
    {
        await ConfigData.LoadConfigsAsync();
    }
}