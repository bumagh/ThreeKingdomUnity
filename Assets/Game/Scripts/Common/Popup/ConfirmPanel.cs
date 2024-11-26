using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{
    public Text content;
    public Button confirmBtn;
    public Button cancelBtn;

    public void Init(string tipContent, UnityAction confirmAction=null, UnityAction cancelAction = null)
    {
        confirmBtn.onClick.AddListener(() =>
        {
            GameObject.Destroy(gameObject);
            if (confirmAction != null)
                confirmAction();
        });
        cancelBtn.onClick.AddListener(() =>
        {
            GameObject.Destroy(gameObject);
            if (cancelAction != null)
                cancelAction();
        });

        this.content.text = tipContent;
    }
}
