[System.Serializable]
public class Skill
{
    public int SkillId;
    public string SkillName;
    public string Description;
    public float AtkCoe;
    public int MpCost;
    public int RoundCount;

    /// <summary>
    ///
    // 0	自身单体
    // 1	敌方单体
    // 2	敌方多人
    // 3	友方单体
    // 4	友方多人
    /// </summary>
    public int SelectType;
    public int SelectCount;
}
