using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoSingleton<GameData>
{

    private readonly Dictionary<string, int> soldierDict = new Dictionary<string, int>();
    private readonly string[] battleSoldiers = new string[10];
    private readonly Dictionary<int, string> soldierUpDict = new Dictionary<int, string>();
    private readonly Dictionary<int, int> items = new Dictionary<int, int>();


    protected override void Initialize()
    {
#if UNITY_EDITOR
        //PlayerPrefs.DeleteAll();
        // PlayerData.SetUserId(UnityEngine.Random.Range(0, 100).ToString());
#endif
        LoadBattleSoldier();

        var unlockSoliers = PlayerData.GetString(PlayerData.UnLockSoliders, "1000#1001#1013");
        foreach (var id in unlockSoliers.Split('#'))
        {
            soldierDict.Add(id, PlayerData.GetInt(id, 1));
        }
        var itemsStr = PlayerData.GetString(PlayerData.Items, "");
        foreach (var item in itemsStr.Split('|'))
        {
            if (string.IsNullOrEmpty(item))
                continue;
            var array = item.Split('#');
            items.Add(int.Parse(array[0]), int.Parse(array[1]));
        }

    }



    public string[] GetBattleSoldiers()
    {
        return battleSoldiers;
    }

    public void UpdateBattleSodiers(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            battleSoldiers[i] = array[i];
        }
        PlayerData.SetString(
            PlayerData.BattleSoldier,
            string.Join('#', battleSoldiers.Where(s => !string.IsNullOrEmpty(s)))
        );
    }

    public void RemoveBattleSodier(string soldierId)
    {
        for (int i = 0; i < battleSoldiers.Length; i++)
        {
            if (battleSoldiers[i] == soldierId)
            {
                battleSoldiers[i] = null;
                PlayerData.SetString(
                    PlayerData.BattleSoldier,
                    string.Join('#', battleSoldiers.Where(s => !string.IsNullOrEmpty(s)))
                );
                Debug.Log(PlayerData.GetString(PlayerData.BattleSoldier, "1001"));
                return;
            }
        }
        Debug.Log("SoldierId not found in the array.");
    }

    public int GetSoldierLv(string soliderId)
    {
        if (soldierDict.TryGetValue(soliderId, out var lv))
            return lv;
        return 1;
    }


    private int GetEnergyWorld()
    {
        return PlayerData.GetInt(PlayerData.EnergyWorld);
    }

    private void UpdateLoginTime()
    {
        PlayerData.SetString(PlayerData.LoginTime, DateTime.Now.ToString("yyyy-MM-dd"));
    }

    private DateTime GetLoginTime()
    {
        DateTime.TryParse(
            PlayerData.GetString(
                PlayerData.LoginTime,
                DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
            ),
            out var result
        );
        return result;
    }


    private void UpdateItems()
    {
        List<string> list = new List<string>();
        foreach (var item in items)
        {
            if (item.Value <= 0)
                continue;
            list.Add($"{item.Key}#{item.Value}");
        }
        PlayerData.SetString(PlayerData.Items, string.Join('|', list));
    }



    private void LoadBattleSoldier()
    {
        var str = PlayerData.GetString(PlayerData.BattleSoldier, "1001");
        var array = str.Split('#');
        for (var i = 0; i < array.Length; i++)
        {
            battleSoldiers[i] = array[i];
        }
    }

    public void AddItemToKnapsack(int itemId, int count)
    {
        if (items.ContainsKey(itemId))
        {
            items[itemId] += count;
        }
        else
        {
            items[itemId] = count;
        }
        UpdateItems();
    }

    public void UseItemByCount(int itemId, int count)
    {
        if (items.ContainsKey(itemId))
        {
            items[itemId] = items[itemId] - count;
        }
        UpdateItems();
    }



    public int GetCoinItemCount()
    {
        int coinCount;
        items.TryGetValue(1001, out coinCount);
        return coinCount;
    }

    public int GetItemCount(string itemId)
    {
        int count;
        items.TryGetValue(int.Parse(itemId), out count);
        return count;
    }

    private void OnDestroy()
    {

    }

    public void AddOrUpdateSoldier(string soldierId, int level)
    {
        soldierDict[soldierId] = level;
    }

}
