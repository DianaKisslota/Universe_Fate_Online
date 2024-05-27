public class SectorMain1211 : SectorData
{
    public SectorMain1211(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

