public class SectorMain1411 : SectorData
{
    public SectorMain1411(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

