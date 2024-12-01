
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadeController : MonoBehaviour
{
    private Button fightBtn;
    void Awake()
    {
        fightBtn = GameObject.Find("Canvas/TopPanel/RightInfo/PersonItems/PersonItem/Button").GetComponent<Button>();
        fightBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }
}