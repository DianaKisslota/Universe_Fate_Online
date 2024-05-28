using System.Collections.Generic;

public class DataSource : IDataSource
{
    private Dictionary<string, SectorData> _sectors = new Dictionary<string, SectorData>();
    public DataSource()
    {
        AddSector(new SectorMain1110(11, 10));
        AddSector(new SectorMain1210(12, 10));
        AddSector(new SectorMain1209(12, 9));
        AddSector(new SectorMain1010(10, 10));
        AddSector(new SectorMain1009(10, 9));
        AddSector(new SectorMain0910(9, 10));
        AddSector(new SectorMain0810(8, 10));
        AddSector(new SectorMain1011(10, 11));
        AddSector(new SectorMain1109(11, 9));
        AddSector(new SectorMain1111(11, 11));
        AddSector(new SectorMain0911(9, 11));
        AddSector(new SectorMain0909(9, 9));
        AddSector(new SectorMain0710(07, 10));
        AddSector(new SectorMain0811(08, 11));
        AddSector(new SectorMain0711(07, 11));
        AddSector(new SectorMain0809(08, 09));
        AddSector(new SectorMain1211(12, 11));
        AddSector(new SectorMain1311(13, 11));
        AddSector(new SectorMain1411(14, 11));
        AddSector(new SectorMain1512(15, 12));
        AddSector(new SectorMain1513(15, 13));
        AddSector(new SectorMain1612(16, 12));
        AddSector(new SectorMain1613(16, 13));
        AddSector(new SectorMain1614(16, 14));
        AddSector(new SectorMain1714(17, 14));
        AddSector(new SectorMain1713(17, 13));
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
