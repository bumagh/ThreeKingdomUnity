[System.Serializable]
public class SoldierBase
{
    public Soldier soldier;
    public SoldierLevel soldierLevel;
    public SoldierSort soldierSort;
    public SoldierType soldierType;
    public UnitCoe unitCoe;

    public SoldierBase(Soldier soldier, SoldierLevel soldierLevel, SoldierSort soldierSort, SoldierType soldierType, UnitCoe unitCoe)
    {
        this.soldier = soldier;
        this.soldierLevel = soldierLevel;
        this.soldierSort = soldierSort;
        this.soldierType = soldierType;
        this.unitCoe = unitCoe;
    }
}