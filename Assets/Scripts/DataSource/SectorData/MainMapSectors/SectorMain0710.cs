public class SectorMain0710 : SectorData
{
    public SectorMain0710(int x, int y) : base("Main", x, y)
    {
        AddMonster(new EntitySpawner(typeof(Reptiloid), 1));
    }
}

