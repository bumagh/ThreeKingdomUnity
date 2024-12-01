using UnityEngine;
using UnityEngine.Events;

public static class Tools
{
    public static bool isDebug = Application.platform == RuntimePlatform.WindowsEditor;

    public static void ShowTip(string textStr)
    {
        var battleMessage = Resources.Load<GameObject>("Prefabs/Popup/SimpleMessage");
        if (battleMessage != null)
        {
            var bmGo = GameObject.Instantiate(battleMessage);
            if (bmGo != null)
            {
                var battleMsg = bmGo.GetComponent<SimpleMessage>();
                battleMsg.UpdateContent(textStr);
            }
        }
    }
    public static void ShowConfirm(string textStr, UnityAction confirmAction = null, UnityAction cancelAction = null)
    {
        var panelPrefab = Resources.Load<GameObject>("Prefabs/Popup/ConfirmPanel");
        if (panelPrefab == null)
            return;
        var panelObj = GameObject.Instantiate(panelPrefab);
        var panel = panelObj.GetComponent<ConfirmPanel>();
        panel.Init(textStr, confirmAction, cancelAction);
    }
}
