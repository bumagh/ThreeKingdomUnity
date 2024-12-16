using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Goods
{
    public int GoodsID;
    public string GoodsName;
    public string GoodsDescribed;
    public int GoodsTypeId;
    public int GoodsTypeChild;
    public int Price;
    public string Stats;
    // 解析后的 Stats 字典
    public Dictionary<string, int> ParsedStats = new Dictionary<string, int>();

    // 解析 Stats 字符串
    public void ParseStats()
    {
        if (string.IsNullOrEmpty(Stats)) return;

        var statPairs = Stats.Split('|');  // 按 "|" 分割
        foreach (var stat in statPairs)
        {
            var statParts = stat.Split('#');  // 按 "#" 分割
            if (statParts.Length == 2)
            {
                string statType = statParts[0].Trim();
                if (int.TryParse(statParts[1], out int statValue))
                {
                    ParsedStats[statType] = statValue;
                }
            }
        }
    }
    public Goods()
    {
        ParseStats();
    }
    public override string ToString()
    {
        string statsString = string.Join(", ", ParsedStats.Select(kvp => $"{kvp.Key}#{kvp.Value}"));
        return $"GoodsID: {GoodsID}, Name: {GoodsName}, Description: {GoodsDescribed}, GoodsTypeId: {GoodsTypeId}, GoodsTypeChild: {GoodsTypeChild}, Price: {Price}, Stats: {statsString}";
    }
}