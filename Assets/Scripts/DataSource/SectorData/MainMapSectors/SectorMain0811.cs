public class SectorMain0811 : SectorData
{
    public SectorMain0811(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
