
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadeController : MonoBehaviour
{
    private Button fightBtn;
    private Text mapStrText;
    
    void Awake()
    {
        fightBtn = GameObject.Find("Canvas/TopPanel/RightInfo/PersonItems/PersonItem/Button").GetComponent<Button>();
        mapStrText = GameObject.Find("Canvas/TopMapStr").GetComponent<Text>();
        fightBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });


        PlayerData.SetString(PlayerData.CurMap, "村口");

        mapStrText.text = PlayerData.GetString(PlayerData.CurMap, "新手村");

    }
}