public class SectorMain1512 : SectorData
{
    public SectorMain1512(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

