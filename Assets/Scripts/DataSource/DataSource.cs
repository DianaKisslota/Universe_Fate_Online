using System.Collections.Generic;

public class DataSource : IDataSource
{

    private Dictionary<string, SectorData> _sectors = new Dictionary<string, SectorData>();
    public DataSource()
    {
        AddSector(new SectorMain1110(11, 10));
        AddSector(new SectorMain1110(12, 10));
        AddSector(new SectorMain1110(12, 9));
        AddSector(new SectorMain1010(10, 10));
        AddSector(new SectorMain1009(10, 9));
        AddSector(new SectorMain0910(9, 10));
        AddSector(new SectorMain0910(8, 10));
        AddSector(new SectorMain1011(10, 11));
        AddSector(new SectorMain1109(11, 9));
        AddSector(new SectorMain1111(11, 11));
        AddSector(new SectorMain0911(9, 11));
        AddSector(new SectorMain0909(9, 9));
    }
    public SectorData GetSectorData(string sectorID)
    {
        _sectors.TryGetValue(sectorID, out var sectorData);

        return sectorData;
    }

    private void AddSector(SectorData sectorData)
    {
        _sectors.Add(sectorData.ID, sectorData);
    }


}
