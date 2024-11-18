[System.Serializable]
public class SoldierCardModel
{
    public float cost = 0;
    public float upgradeCost = 0;
    public string soldierName;
    public bool enable = false;
    public Soldier soldier;

    public SoldierCardModel(float cost, float upgradeCost, string soldierName, bool enable, Soldier soldier)
    {
        this.cost = cost;
        this.upgradeCost = upgradeCost;
        this.soldierName = soldierName;
        this.enable = enable;
        this.soldier = soldier;
    }
}