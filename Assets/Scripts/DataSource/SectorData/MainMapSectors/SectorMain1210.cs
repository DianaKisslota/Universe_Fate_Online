public class SectorMain1210 : SectorData
{
    public SectorMain1210(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
