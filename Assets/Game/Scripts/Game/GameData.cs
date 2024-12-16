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
    public Dictionary<int, int> items = new Dictionary<int, int>();
    public Dictionary<int, Goods> equips = new Dictionary<int, Goods>();


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

        PlayerData.SetInt(PlayerData.Atk, 10);
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="exp"></param>
    /// <returns>还差多少升级</returns>
    public int UpPlayer(int exp)
    {
        int curExp = PlayerData.GetInt(PlayerData.Exp, 0);
        int curLevel = PlayerData.GetInt(PlayerData.Level, 1);
        int newExp = curExp + exp;
        while (newExp >= ConfigData.levels.Find(ele => ele.id == curLevel).needExp)
        {
            newExp -= ConfigData.levels.Find(ele => ele.id == curLevel).needExp;
            curLevel++;
            PlayerData.SetInt(PlayerData.Hp, ConfigData.levels.Find(ele => ele.id == curLevel).blood);
            PlayerData.SetInt(PlayerData.Level, curLevel);
        }
        PlayerData.SetInt(PlayerData.Exp, newExp);
        int nextExp = 0;
        return nextExp;
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

    public void LoadEquip(int equipId)
    {
        // 假设有一个从数据库或配置表获取装备的函数
        Goods equip = ConfigData.goods.Find(ele => ele.GoodsID == equipId);
        if (equip == null)
        {
            Debug.LogError("Invalid Equip ID");
            return;
        }

        // 获取装备类型
        EquipTypeEnums equipType = (EquipTypeEnums)equip.GoodsTypeChild;

        // 如果当前已有装备，先卸下
        if (equips.ContainsKey((int)equipType))
        {
            UnloadEquip(equipType);

        }

        // 装备上该物品
        equips[(int)equipType] = equip;
        ApplyEquipStats(equip);
        Debug.Log($"Equipped {equip.GoodsName} on {equipType}");
    }

    private void ApplyEquipStats(Goods equip)
    {
        if (equip.ParsedStats.ContainsKey("DEF"))
        {
            PlayerData.UpdateData("DEF", equip.ParsedStats["DEF"]);
        }
        if (equip.ParsedStats.ContainsKey("ATK"))
        {
            PlayerData.UpdateData("ATK", equip.ParsedStats["ATK"]);

        }
        if (equip.ParsedStats.ContainsKey("HP"))
        {
            PlayerData.UpdateData("HP", equip.ParsedStats["HP"]);
        }
        if (equip.ParsedStats.ContainsKey("MP"))
        {
            PlayerData.UpdateData("MP", equip.ParsedStats["MP"]);
        }
        if (equip.ParsedStats.ContainsKey("SP"))
        {
            PlayerData.UpdateData("SP", equip.ParsedStats["SP"]);
        }
    }


    private void UnloadEquip(EquipTypeEnums equipType)
    {
        if (equips.ContainsKey((int)equipType))
        {
            Goods equip = equips[(int)equipType];
            RemoveEquipStats(equip);
            equips.Remove((int)equipType);
            Debug.Log($"Unequipped {equip.GoodsName} from {equipType}");
            //卸下放入背包
            AddItemToKnapsack(equip.GoodsID, 1);
        }
        else
        {
            Debug.Log($"No item equipped on {equipType}");
        }
    }

    private void RemoveEquipStats(Goods equip)
    {
        if (equip.ParsedStats.ContainsKey("DEF"))
        {
            PlayerData.UpdateData("DEF", -equip.ParsedStats["DEF"]);
        }
        if (equip.ParsedStats.ContainsKey("ATK"))
        {
            PlayerData.UpdateData("ATK", -equip.ParsedStats["ATK"]);

        }
        if (equip.ParsedStats.ContainsKey("HP"))
        {
            PlayerData.UpdateData("HP", -equip.ParsedStats["HP"]);
        }
        if (equip.ParsedStats.ContainsKey("MP"))
        {
            PlayerData.UpdateData("MP", -equip.ParsedStats["MP"]);
        }
        if (equip.ParsedStats.ContainsKey("SP"))
        {
            PlayerData.UpdateData("SP", -equip.ParsedStats["SP"]);
        }
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
