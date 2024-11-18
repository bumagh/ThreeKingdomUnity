
using UnityEngine;
public class GameController : MonoBehaviour
{
    private GameObject leftSeats;
    private GameObject rightSeats;
    private Transform[] leftSeatsTrans = new Transform[3];
    private Transform[] rightSeatsTrans = new Transform[3];
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
    void Start()
    {
        for (int i = 0; i < leftSeatsTrans.Length; i++)
        {
            var newPlayerPrefab = Resources.Load<GameObject>("Prefabs/Player");
            var newPlayerGo = Instantiate(newPlayerPrefab, leftSeatsTrans[i]);
        }
        for (int i = 0; i < rightSeatsTrans.Length; i++)
        {
            var newPlayerPrefab = Resources.Load<GameObject>("Prefabs/Player");
            var newPlayerGo = Instantiate(newPlayerPrefab, rightSeatsTrans[i]);
        }
    }
}