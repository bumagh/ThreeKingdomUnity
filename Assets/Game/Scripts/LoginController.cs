
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    private Button startBtn;
    void Awake()
    {
        startBtn = GameObject.Find("Canvas/StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Arcade");
        });
    }
}