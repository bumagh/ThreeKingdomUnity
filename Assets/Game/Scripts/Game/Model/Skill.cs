[System.Serializable]
public class Skill
{
    public int SkillId;
    public string SkillMacro;
    public string SkillTemp;
    public float AtkCoe;
    public int EnergyCost;
    public string Description;
    public int Duration;
    public int CdTime;

    /// <summary>
    ///
    ///0	自身技能
    ///1	单体选择
    ///2	范围攻击（点）选择
    ///3	友方单位
    /// </summary>
    public int SelectType;
    public int SelectRange;
    public int DamageRange;
    public float Repulsion;
    public int SliiTrigger;
    public string TriggerNum;
    public string Sound;
    public int Bulletlogic;
    public string BulletImg;
    public string SkillIcon;

    public Skill(
        int skillId,
        string skillMacro,
        string skillTemp,
        float atkCoe,
        int energyCost,
        string description,
        int duration,
        int cdTime,
        int selectType,
        int selectRange,
        int damageRange,
        float repulsion,
        int sliiTrigger,
        string triggerNum,
        string sound,
        int bulletlogic,
        string bulletImg,
        string skillIcon
    )
    {
        SkillId = skillId;
        SkillMacro = skillMacro;
        SkillTemp = skillTemp;
        AtkCoe = atkCoe;
        EnergyCost = energyCost;
        Description = description;
        Duration = duration;
        CdTime = cdTime;
        SelectType = selectType;
        SelectRange = selectRange;
        DamageRange = damageRange;
        Repulsion = repulsion;
        SliiTrigger = sliiTrigger;
        TriggerNum = triggerNum;
        Sound = sound;
        Bulletlogic = bulletlogic;
        BulletImg = bulletImg;
        SkillIcon = skillIcon;
    }
}
