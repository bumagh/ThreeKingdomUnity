
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private bool isGaming = false;

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
        EventManager.AddEvent(EventName.SetNextRoundPlayerId, this.SetNextRoundPlayerId);
        EventManager.AddEvent(EventName.SetGamingState, this.SetGamingState);
    }
    void OnDestroy()
    {
        EventManager.RemoveEvent(EventName.SetNextRoundPlayerId, this.SetNextRoundPlayerId);
        EventManager.RemoveEvent(EventName.SetGamingState, this.SetGamingState);
    }
    private void SetGamingState()
    {
        isGaming = !isGaming;
    }

    async void Start()
    {
        await ConfigData.LoadConfigsAsync();
        isGaming = true;
        var newPlayerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        for (int i = 0; i < leftSeatsTrans.Length; i++)
        {
            var newPlayerGo = Instantiate(newPlayerPrefab, GameObject.Find("GameRoot").transform);
            newPlayerGo.transform.position = leftSeatsTrans[i].position;
            var playerController = newPlayerGo.GetComponent<PlayerController>();
            playerController.Init(ConfigData.soldiers.Find(ele => ele.SoldierId == enemyIds[0]).SodierName, 100, 10, 15 + i, ConfigData.soldiers.Find(ele => ele.SoldierId == enemyIds[0]));
            playerController.isLeft = true;
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
                playerController.Init("主将", PlayerData.GetInt(PlayerData.Hp,100), 10, 40, ConfigData.soldiers.Find(ele => ele.SoldierId == "1000"));
                playerController.isLeft = false;
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

        SetNextRoundPlayerId();
    }

    private void SetNextRoundPlayerId()
    {
        //判断是否胜利或失败
        bool leftPlayerLive = false;
        bool rightPlayerLive = false;
        foreach (var item in playerCtrls)
        {
            if (item.player.hp > 0 && item.isLeft)
            {
                leftPlayerLive = true;
            }
            if (item.player.hp > 0 && item.isLeft == false)
            {
                rightPlayerLive = true;
            }
        }
        if (rightPlayerLive && leftPlayerLive == false)
        {
            isGaming = false;
            //玩家胜利
            // Tools.ShowTip("游戏胜利");
            int nextNeedExp = GameData.Instance.UpPlayer(10);
            PlayerData.SetInt(PlayerData.Coin, PlayerData.GetInt(PlayerData.Coin, 0) + 1);
            // Tools.ShowConfirm("游戏胜利,经验+10,金币+1,差" + nextNeedExp + "经验升级", () =>
            Tools.ShowConfirm("游戏胜利,经验+10,金币+1", () =>
            {
                SceneManager.LoadScene("Arcade");
            }, () =>
            {
                SceneManager.LoadScene("Arcade");
            });

        }
        if (rightPlayerLive == false && leftPlayerLive == true)
        {
            isGaming = false;
            
            Tools.ShowConfirm("游戏失败", () =>
            {
                SceneManager.LoadScene("Arcade");
            }, () =>
            {
                SceneManager.LoadScene("Arcade");
            });
        }
        int nextIndex = 0;
        players.Sort((a, b) =>
           {
               return b.sp - a.sp;
           });
        //根据场上存活的单位的速度来生成回合顺序
        if (curRoundPlayerId == null)
        {

        }
        else
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (curRoundPlayerId == players[i].uuid)
                {
                    nextIndex = (i + 1) % players.Count;
                    while (players[nextIndex].hp <= 0)
                    {
                        nextIndex = (nextIndex + 1) % players.Count;
                    }
                    break;
                }
            }
        }
        //显示操作UI

        curRoundPlayerId = players[nextIndex].uuid;
        UpdateCurRoundPlayerText(players[nextIndex].soldierId);
        if (players.Find(ele => ele.uuid == curRoundPlayerId).soldierId == "1000")
        {
            EventManager.DispatchEvent(EventName.ShowBattleMenuPanel, true);
        }
        else
        {
            EventManager.DispatchEvent(EventName.ShowBattleMenuPanel, false);
            //机器人的回合
            playerCtrls.Find(ele => ele.player.uuid == curRoundPlayerId).target = playerCtrls.Find(ele => ele.player.soldierId == "1000").gameObject;
        }
    }
    private void UpdateCurRoundPlayerText(string id)
    {
        curRoundText.text = "当前回合:" + ConfigData.soldiers.Find(ele => ele.SoldierId == id).SodierName;
    }
    void Update()
    {
        if (isGaming == false) return;
        if (curRoundPlayerId == null) return;
        // 检查鼠标左键是否被按下
        if (Input.GetMouseButtonDown(0) && players.Find(ele => ele.uuid == curRoundPlayerId).soldierId == "1000")
        {
            // 获取鼠标在屏幕上的位置
            Vector3 mousePosition = Input.mousePosition;
            // 将屏幕坐标转换为射线
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            // 进行射线检测，获取命中到的目标
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<PlayerController>().player.hp > 0 && hit.collider.gameObject.GetComponent<PlayerController>().player.uuid != curRoundPlayerId)
            {
                // 打印出被点击对象的tag名称或其他信息
                // Debug.Log(hit.collider.gameObject.GetComponent<PlayerController>().player.sodierName);
                EventManager.DispatchEvent(EventName.ShowBattleMenuPanel, false);
                playerCtrls.Find(ele => ele.player.uuid == curRoundPlayerId).target = hit.collider.gameObject;
                // 在此处添加点击后的处理逻辑
            }
        }
    }


}