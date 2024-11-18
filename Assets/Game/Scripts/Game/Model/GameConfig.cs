[System.Serializable]
public class GameConfig
{
    public int Id;
    public string GameMacro;
    public string GameValues;

    public GameConfig(int id, string gameMacro, string gameValues)
    {
        this.Id = id;
        this.GameMacro = gameMacro;
        this.GameValues = gameValues;
    }
    public override string ToString()
    {
        // 返回一个包含所有公共字段的字符串  
        return $"GameConfig{{Id='{Id}', GameMacro='{GameMacro}', GameValues='{GameValues}'}}";
    }
}
