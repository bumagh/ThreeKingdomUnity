using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T instance;
    private static bool isCreate = false;
    private static object lockObject = new object();
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    var go = new GameObject(typeof(T).Name);
                    GameObject.DontDestroyOnLoad(go);
                    instance = go.AddComponent<T>();
                    (instance as MonoSingleton<T>)?.Initialize();
                    isCreate = true;
                }
            }
            return instance;
        }
    }

    public static bool IsCreate => isCreate;

    protected virtual void Initialize() { }

    protected virtual void Awake()
    {
        instance = this as T;
    }
}
