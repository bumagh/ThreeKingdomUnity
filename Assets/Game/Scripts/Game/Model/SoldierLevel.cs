[System.Serializable]
public class SoldierLevel
{
    public int SoldierLv;
    public int HpBase;
    public int AtkBase;
    public int SpBase;
    public float DefBase;
    public int DodBase;
    public int EnergyCostBase;
    public int UpgradeBase;
    public int CampEnergy;

    public SoldierLevel(int soldierLv, int hpBase, int atkBase, int spBase, float defBase, int dodBase, int energyCostBase, int upgradeBase, int campEnergy)
    {
        SoldierLv = soldierLv;
        HpBase = hpBase;
        AtkBase = atkBase;
        SpBase = spBase;
        DefBase = defBase;
        DodBase = dodBase;
        EnergyCostBase = energyCostBase;
        UpgradeBase = upgradeBase;
        CampEnergy = campEnergy;
    }
    public override string ToString()
    {
        return $"SoldierLv: {SoldierLv}, HpBase: {HpBase}, AtkBase: {AtkBase}, SpBase: {SpBase}, DefBase: {DefBase}, DodBase: {DodBase}, EnergyCostBase: {EnergyCostBase}, UpgradeBase:{UpgradeBase}";
    }
}