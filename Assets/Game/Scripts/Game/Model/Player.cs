using System.Text.RegularExpressions;
public class Player
{
    public string soldierId;
    public string sodierName;
    public string skillId;
    public int sodierType;
    public int sodierSort;
    public int hp;
    public int mp;
    public int atk;
    public int sp;
    public string uuid;
    public Player()
    {
    }

    public Player(string soldierId, string sodierName, string skillId, int sodierType, int sodierSort, int hp, int mp, int atk, int sp)
    {
        this.soldierId = soldierId;
        this.sodierName = sodierName;
        this.skillId = skillId;
        this.sodierType = sodierType;
        this.sodierSort = sodierSort;
        this.hp = hp;
        this.mp = mp;
        this.atk = atk;
        this.sp = sp;
    }
}
