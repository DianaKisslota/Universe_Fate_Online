public class SectorMain1612 : SectorData
{
    public SectorMain1612(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

