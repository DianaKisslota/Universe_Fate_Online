public class SectorMain1714 : SectorData
{
    public SectorMain1714(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

