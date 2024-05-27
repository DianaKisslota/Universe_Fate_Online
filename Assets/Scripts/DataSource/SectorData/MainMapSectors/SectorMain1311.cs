public class SectorMain1311 : SectorData
{
    public SectorMain1311(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

