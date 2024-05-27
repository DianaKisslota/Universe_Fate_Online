public class SectorMain1513 : SectorData
{
    public SectorMain1513(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

