
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    private GameObject leftSeats;
    private GameObject rightSeats;
    private Transform[] leftSeatsTrans = new Transform[3];
    private Transform[] rightSeatsTrans = new Transform[3];
    private string[] enemyIds = new string[3] { "1006", "1006", "1006" };
    private List<Player> players = new List<Player>();
    private List<PlayerController> playerCtrls = new List<PlayerController>();
    private string curRoundPlayerId = null;
    private Text curRoundText;
    void Awake()
    {
        leftSeats = GameObject.Find("GameRoot/LeftSeats");
        rightSeats = GameObject.Find("GameRoot/RightSeats");
        curRoundText = GameObject.Find("Canvas/RoundTip").GetComponent<Text>();
        for (int i = 0; i < leftSeats.transform.childCount; i++)
        {
            leftSeatsTrans[i] = leftSeats.transform.GetChild(i);
        }
        for (int i = 0; i < rightSeats.transform.childCount; i++)
        {
            rightSeatsTrans[i] = rightSeats.transform.GetChild(i);
        }

    }
    async void Start()
    {
        await ConfigData.LoadConfigsAsync();
        var newPlayerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        for (int i = 0; i < leftSeatsTrans.Length; i++)
        {
            var newPlayerGo = Instantiate(newPlayerPrefab, GameObject.Find("GameRoot").transform);
            newPlayerGo.transform.position = leftSeatsTrans[i].position;
            var playerController = newPlayerGo.GetComponent<PlayerController>();
            playerController.Init(ConfigData.soldiers.Find(ele => ele.SoldierId == enemyIds[0]).SodierName, 100, 1, 15 + i, ConfigData.soldiers.Find(ele => ele.SoldierId == enemyIds[0]));
            players.Add(playerController.player);
            playerCtrls.Add(playerController);
        }
        // var initIds = ConfigData.gameConfigs.Find(ele=>ele.GameMacro=="").GameValues;
        for (int i = 0; i < rightSeatsTrans.Length; i++)
        {
            var newPlayerGo = Instantiate(newPlayerPrefab, GameObject.Find("GameRoot").transform);
            newPlayerGo.transform.position = rightSeatsTrans[i].position;
            var playerController = newPlayerGo.GetComponent<PlayerController>();
            if (i == 0)
            {
                playerController.Init("主将", 100, 1, 40, ConfigData.soldiers.Find(ele => ele.SoldierId == "1000"));
                players.Add(playerController.player);
                playerCtrls.Add(playerController);
            }
            else
            {
                // playerController.Init(,100,1,10);
                newPlayerGo.SetActive(false);
                rightSeatsTrans[i].gameObject.SetActive(false);
            }
        }
        //根据场上存活的单位的速度来生成回合顺序
        players.Sort((a, b) =>
        {
            return b.sp - a.sp;
        });
        curRoundPlayerId = players[0].soldierId;
        UpdateCurRoundPlayerText(curRoundPlayerId);
        if (curRoundPlayerId == "1000")
        {
            EventManager.DispatchEvent(EventName.ShowBattleMenuPanel, true);
        }
        else
        {
            EventManager.DispatchEvent(EventName.ShowBattleMenuPanel, false);
        }
        //显示操作UI
    }
    private void UpdateCurRoundPlayerText(string id)
    {
        curRoundText.text = "当前回合:" + ConfigData.soldiers.Find(ele => ele.SoldierId == id).SodierName;
    }
    void Update()
    {
        // 检查鼠标左键是否被按下
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标在屏幕上的位置
            Vector3 mousePosition = Input.mousePosition;
            // 将屏幕坐标转换为射线
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            // 进行射线检测，获取命中到的目标
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null)
            {
                // 打印出被点击对象的tag名称或其他信息
                // Debug.Log(hit.collider.gameObject.GetComponent<PlayerController>().player.sodierName);
                EventManager.DispatchEvent(EventName.ShowBattleMenuPanel, false);
                playerCtrls.Find(ele => ele.player.soldierId == curRoundPlayerId).target = hit.collider.gameObject;
                // 在此处添加点击后的处理逻辑

            }
        }
    }

}