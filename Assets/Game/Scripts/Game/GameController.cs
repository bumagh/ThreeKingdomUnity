
using UnityEngine;
public class GameController : MonoBehaviour
{
    private GameObject leftSeats;
    private GameObject rightSeats;
    private Transform[] leftSeatsTrans = new Transform[3];
    private Transform[] rightSeatsTrans = new Transform[3];
    private string[] enemyIds = new string[3] { "1006", "1006", "1006" };
     void Awake()
    {
        leftSeats = GameObject.Find("GameRoot/LeftSeats");
        rightSeats = GameObject.Find("GameRoot/RightSeats");
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
            playerController.Init(ConfigData.soldiers.Find(ele => ele.SoldierId == enemyIds[0]).SodierName, 100, 1, 15);
        }
        // var initIds = ConfigData.gameConfigs.Find(ele=>ele.GameMacro=="").GameValues;
        for (int i = 0; i < rightSeatsTrans.Length; i++)
        {
            var newPlayerGo = Instantiate(newPlayerPrefab, GameObject.Find("GameRoot").transform);
            newPlayerGo.transform.position = rightSeatsTrans[i].position;
            var playerController = newPlayerGo.GetComponent<PlayerController>();
            if(i==0){
                playerController.Init("主将",100,1,10);
            }else{
                // playerController.Init(,100,1,10);
                newPlayerGo.SetActive(false);
                rightSeatsTrans[i].gameObject.SetActive(false);
            }
        }
    }
}