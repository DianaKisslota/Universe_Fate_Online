public class SectorMain1209 : SectorData
{
    public SectorMain1209(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
    }
}
