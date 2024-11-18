[System.Serializable]
public class MapLevel
{
    public string SceneId;
    public int CustomsSortId;
    public int CustomsTypeId;
    public string ArchiteItem;
    public string ArchiteNmae;
    public string MapSrcId;
    public string LevelIndex;
    public string SoldierCfg;
    public int SoldireRefreshTime;
    public string TowerCfg;
    public int SoldierAiLv;
    public int SoldierLvUp;
    public int EnergyRecSpeed;
    public string HeroId;
    public string MapGoodsId;
    public string ArchiteName;
    public int DebrisPoolFF;
    public int DebrisPoolNumber;
    public int DebrisPoolIdSoldier;
    public int MapSoldierNumber;
    public int MapEnergyNumber;
    public string DebrisPoolId;
    public int SkillPoolId;
    public int PoollCd;
    public int SoldierMaxNum;

    public MapLevel(string sceneId, string mapSrcId, string levelIndex, string soldierCfg, int soldireRefreshTime, string towerCfg, int energyRecSpeed)
    {
        SceneId = sceneId;
        MapSrcId = mapSrcId;
        LevelIndex = levelIndex;
        SoldierCfg = soldierCfg;
        SoldireRefreshTime = soldireRefreshTime;
        TowerCfg = towerCfg;
        EnergyRecSpeed = energyRecSpeed;
    }

    public override string ToString()
    {
        return $"SceneId: {SceneId}, MapSrcId: {MapSrcId}, LevelIndex: {LevelIndex}, " +
               $"SoldierCfg: {SoldierCfg}, SoldierRefreshTime: {SoldireRefreshTime}, " +
               $"TowerCfg: {TowerCfg}, EnergyRecSpeed: {EnergyRecSpeed}";
    }
}
