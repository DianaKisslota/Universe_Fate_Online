public class SectorMain1110 : SectorData
{
    public SectorMain1110(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(FeralDog), 1, 3));
        AddItem(typeof(AK47));
        AddItem(typeof(PM));
    }
}
