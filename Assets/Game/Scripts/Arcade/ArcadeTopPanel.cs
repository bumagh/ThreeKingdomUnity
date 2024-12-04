
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

        nameText.text = PlayerData.GetString(PlayerData.NickName, "三国新人");
        coinText.text = PlayerData.GetInt(PlayerData.Coin, 100).ToString();
        levelText.text = PlayerData.GetInt(PlayerData.Level, 1).ToString();
        expText.text = PlayerData.GetInt(PlayerData.Exp, 0).ToString();
        jobText.text = PlayerData.GetString(PlayerData.Job, "武士");
        hpText.text = PlayerData.GetInt(PlayerData.Hp, 100).ToString();
        mpText.text = PlayerData.GetInt(PlayerData.Mp, 100).ToString();
        EventManager.AddEvent<bool>(EventName.ShowHomePanel, this.ShowHomePanel);

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
    }
    void OnDestroy()
    {
        EventManager.RemoveEvent<bool>(EventName.ShowHomePanel, this.ShowHomePanel);

    }
}