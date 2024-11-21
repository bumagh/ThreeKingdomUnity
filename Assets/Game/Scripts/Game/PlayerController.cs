
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    private TextMeshPro nameTmp;
    [HideInInspector]
    private TextMeshPro hpTmp;
    [HideInInspector]
    private TextMeshPro atkTmp;
    [HideInInspector]
    private TextMeshPro speedTmp;
    public Player player = new Player();
    void Awake()
    {
        nameTmp = transform.Find("NameTextTmp").GetComponent<TextMeshPro>();
        hpTmp = transform.Find("HpTextTmp").GetComponent<TextMeshPro>();
        atkTmp = transform.Find("AtkTextTmp").GetComponent<TextMeshPro>();
        speedTmp = transform.Find("SpeedTextTmp").GetComponent<TextMeshPro>();
    }
    public void Init(string name, int hp, int atk, int speed, Soldier soldier)
    {
        nameTmp = transform.Find("NameTextTmp").GetComponent<TextMeshPro>();
        hpTmp = transform.Find("HpTextTmp").GetComponent<TextMeshPro>();
        atkTmp = transform.Find("AtkTextTmp").GetComponent<TextMeshPro>();
        speedTmp = transform.Find("SpeedTextTmp").GetComponent<TextMeshPro>();
        nameTmp.text = name;
        hpTmp.text = "hp:" + hp.ToString();
        atkTmp.text = "atk:" + atk.ToString();
        speedTmp.text = "sp:" + speed.ToString();
        player.hp = hp;
        player.atk = atk;
        player.mp = hp;
        player.sp = speed;
        player.sodierName = soldier.SodierName;
        player.soldierId = soldier.SoldierId;
    }
}