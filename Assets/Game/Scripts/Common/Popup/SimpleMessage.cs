using UnityEngine;
using UnityEngine.UI;

public class SimpleMessage : MonoBehaviour
{
    public Text text;
    public Animator animator;

    public void UpdateContent(string content)
    {
        text.text = content;
    }

    public void DestroyMessage()
    {
        GameObject.Destroy(gameObject);
    }
}