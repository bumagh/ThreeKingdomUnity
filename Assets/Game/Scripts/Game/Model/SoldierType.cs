[System.Serializable]
public class SoldierType
{
    public string SoldierTypeId;
    public string SoldierTypeName;

    public SoldierType(string soldierTypeId, string soldierTypeName)
    {
        SoldierTypeId = soldierTypeId;
        SoldierTypeName = soldierTypeName;
    }
}