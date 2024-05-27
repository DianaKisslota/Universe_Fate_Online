public class SectorMain1613 : SectorData
{
    public SectorMain1613(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

