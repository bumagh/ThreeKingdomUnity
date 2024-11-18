[System.Serializable]
public class SoldierConsumables
{
    public int SodierLv;
    public int ConsumablesNum;
    public int GoldNum;

    public SoldierConsumables(int sodierLv, int consumablesNum, int goldNum)
    {
        SodierLv = sodierLv;
        ConsumablesNum = consumablesNum;
        GoldNum = goldNum;
    }
}
