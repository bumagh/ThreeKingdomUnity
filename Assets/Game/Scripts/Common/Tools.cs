using UnityEngine;

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
}
