using System.Text.RegularExpressions;

[System.Serializable]
public class Soldier
{
    public string SoldierId;
    public string SodierName;
    public string SkillId;
    public int SodierType;
    public int SodierSort;
    public float HpCoe;
    public float SpCoe;
    public float DefCoe;
    public SkillData[] skillDatas;

    public void Initialize()
    {
        string pattern = @"\{([^{}]+)\}";
        if (SkillId == null)
        {
            return;
        }
        MatchCollection matches = Regex.Matches(SkillId, pattern);
        skillDatas = new SkillData[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            var value = matches[i].Groups[1].Value;
            var data = new SkillData();
            MatchCollection numberMatches = Regex.Matches(value, @"\d+");
            int.TryParse(numberMatches[0].Value, out data.min);
            int.TryParse(numberMatches[1].Value, out data.max);
            MatchCollection arrayMatches = Regex.Matches(value, @"\b\d+(,\d+){2}\b");
            data.list = new SkillInfo[arrayMatches.Count];
            for (int j = 0; j < arrayMatches.Count; j++)
            {
                var array = arrayMatches[j].Value.Split(',');
                var info = new SkillInfo();
                int.TryParse(array[0], out info.skillId);
                int.TryParse(array[1], out info.probability);
                int.TryParse(array[2], out info.count);
                data.list[j] = info;
            }
            skillDatas[i] = data;
        }
    }

    public override string ToString()
    {
        return $"SoldierId: {SoldierId}, SoldierName: {SodierName}, SoldierType: {SodierType}, SoldierSort: {SodierSort},HpCoe: {HpCoe}, SpCoe: {SpCoe}, DefCoe: {DefCoe}, SkillId: {SkillId}";
    }

    public struct SkillData
    {
        public int min;
        public int max;
        public SkillInfo[] list;
    }

    public struct SkillInfo
    {
        public int skillId;
        public int probability;
        public int count;
    }
}
