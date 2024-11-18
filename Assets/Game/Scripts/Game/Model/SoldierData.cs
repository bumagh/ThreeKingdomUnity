using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoldierData
{
    public List<string> ids;
    public List<int> levels;

    public SoldierData(Dictionary<string, int> soldierDict)
    {
        ids = new List<string>(soldierDict.Keys);
        levels = new List<int>(soldierDict.Values);
    }

    public Dictionary<string, int> ToDictionary()
    {
        var dict = new Dictionary<string, int>();
        for (int i = 0; i < ids.Count; i++)
        {
            dict[ids[i]] = levels[i];
        }
        return dict;
    }
}

