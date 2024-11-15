
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector]
    private TextMeshPro nameTmp;
    [HideInInspector]
    private TextMeshPro hpTmp;
    [HideInInspector]
    private TextMeshPro atkTmp;
    [HideInInspector]
    private TextMeshPro speedTmp;
    void Awake()
    {
        nameTmp = transform.Find("NameTextTmp").GetComponent<TextMeshPro>();
        hpTmp = transform.Find("HpTextTmp").GetComponent<TextMeshPro>();
        atkTmp = transform.Find("AtkTextTmp").GetComponent<TextMeshPro>();
        speedTmp = transform.Find("SpeedTextTmp").GetComponent<TextMeshPro>();
    }
    public void Init(string name, int hp, int atk, int speed)
    {
        nameTmp.text = name;
        hpTmp.text = hp.ToString();
        atkTmp.text = atk.ToString();
        speedTmp.text = speed.ToString();
    }
}