using UnityEngine;

public static class PlayerData
{
      public const string LoginTime = "LoginTime";
    public const string Items = "Items";
    public const string UnLockSoliders = "UnLockSoliders";
    public const string BattleSoldier = "BattleSoldier";
       public const string EnergyWorld = "EnergyWorld";
       public const string BgmVolume = "BgmVolume";
    public const string EffectVolume = "EffectVolume";
    public const string Language = "Language";

    public static string userId;

    public static void SetUserId(string user)
    {
        userId = user;
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(GetKey(key), value);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(GetKey(key), value);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(GetKey(key), value);
    }

    public static int GetInt(string key, int defaultValue = default)
    {
        return PlayerPrefs.GetInt(GetKey(key), defaultValue);
    }

    public static string GetString(string key, string defaultValue = default)
    {
        return PlayerPrefs.GetString(GetKey(key), defaultValue);
    }

    public static float GetFloat(string key, float defaultValue = default)
    {
        return PlayerPrefs.GetFloat(GetKey(key), defaultValue);
    }

    private static string GetKey(string key)
    {
        return $"{userId}-{key}";
    }
}
