[System.Serializable]
public class UnitCoe
{
    public int No;
    public int AttackUnitType;
    public int AffectUnitType;
    public float CounterCoe;

    public UnitCoe(int no, int attackUnitType, int affectUnitType, float counterCoe)
    {
        No = no;
        AttackUnitType = attackUnitType;
        AffectUnitType = affectUnitType;
        CounterCoe = counterCoe;
    }
}
 