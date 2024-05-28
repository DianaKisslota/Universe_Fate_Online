public class SectorMain0809 : SectorData
{
    public SectorMain0809(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
