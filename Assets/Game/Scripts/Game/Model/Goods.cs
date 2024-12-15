[System.Serializable]
public class Goods
{
    public int GoodsID;
    public string GoodsName;
    public string GoodsDescribed;
    public int GoodsTypeId;
    public int GoodsTypeChild;
    public int Price;
    public override string ToString()
    {
        return $"GoodsID: {GoodsID}, Name: {GoodsName}, Description: {GoodsDescribed}, GoodsTypeId: {GoodsTypeId}, GoodsTypeChild:{GoodsTypeChild}, Price:{Price}";
    }
}