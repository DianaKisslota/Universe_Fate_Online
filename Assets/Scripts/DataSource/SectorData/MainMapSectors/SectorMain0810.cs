public class SectorMain0810 : SectorData
{
    public SectorMain0810(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
