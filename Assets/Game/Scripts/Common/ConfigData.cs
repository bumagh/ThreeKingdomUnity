using System.Collections.Generic;
using System.Threading.Tasks;

public static class ConfigData
{
    public static bool isLoad = false;
    public static List<Soldier> soldiers = new List<Soldier>();
    public static List<GameConfig> gameConfigs = new List<GameConfig>();
    public static List<Skill> skills = new List<Skill>();
    public static List<Goods> goods = new List<Goods>();
    public static async Task LoadConfigsAsync()
    {
        if (isLoad)
            return;

        skills = await JsonUtil.DeserializeJsonToObjectAsync<Skill>("skill.json");
        gameConfigs = await JsonUtil.DeserializeJsonToObjectAsync<GameConfig>("game_config.json");
        soldiers = await JsonUtil.DeserializeJsonToObjectAsync<Soldier>("soldier.json");
        goods = await JsonUtil.DeserializeJsonToObjectAsync<Goods>("goods.json");
        foreach (var soldier in soldiers)
        {
            soldier.Initialize();
        }

        isLoad = true;
    }
}
