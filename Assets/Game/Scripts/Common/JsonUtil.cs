using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;
using System.IO;
using System.Threading.Tasks;

public class JsonUtil
{
    public static async Task<List<T>> DeserializeJsonToObjectAsync<T>(string jsonFileName)
    {
        string jsonFilePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        string jsonData = await LoadJsonData(jsonFilePath);
        if (string.IsNullOrEmpty(jsonData))
            return new List<T>();
        T[] myObjects = JsonHelper.FromJson<T>(jsonData);
        return new List<T>(myObjects);
    }
    private static async Task<string> LoadJsonData(string filePath)
    {
       
          using (UnityWebRequest request = UnityWebRequest.Get(filePath))
            {
                var asyncOperation = await request.SendWebRequestAsync();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to load JSON data: " + filePath);
                    return null;
                }
                return request.downloadHandler.text;
            }

    }
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string jsonString)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonString);
            return wrapper.Sheet1;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Sheet1;
        }
    }
}

public static class UnityWebRequestExtensions
{
    public static async Task<UnityWebRequestAsyncOperation> SendWebRequestAsync(this UnityWebRequest request)
    {
        var asyncOperation = request.SendWebRequest();
        while (!asyncOperation.isDone)
        {
            await Task.Yield();
        }
        return asyncOperation;
    }
}
