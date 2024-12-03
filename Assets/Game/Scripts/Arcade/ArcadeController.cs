
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
        fightBtn = GameObject.Find("Canvas/TopPanel/RightInfo/PersonItems/PersonItem/Button").GetComponent<Button>();
        mapStrText = GameObject.Find("Canvas/TopMapStr").GetComponent<Text>();
        hospitalBtn = GameObject.Find("Canvas/TopPanel/RightInfo/FacilityItems/HospitalBtn").GetComponent<Button>();

        fightBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
        hospitalBtn.onClick.AddListener(() =>
              {

              });


        PlayerData.SetString(PlayerData.CurMap, "村口");

        mapStrText.text = PlayerData.GetString(PlayerData.CurMap, "新手村");

    }
}