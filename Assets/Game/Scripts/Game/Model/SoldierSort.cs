[System.Serializable]
public class SoldierSort
{
    public int SoldierSortId;
    public string SoldierSortName;
    public string Description;


    public SoldierSort(int soldierSortId, string soldierSortName, string description)
    {
        SoldierSortId = soldierSortId;
        SoldierSortName = soldierSortName;
        Description = description;
    }
}