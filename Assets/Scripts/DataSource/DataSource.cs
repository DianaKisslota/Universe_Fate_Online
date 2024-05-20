using System.Collections.Generic;

public class DataSource : IDataSource
{
    public SectorData GetSectorData(string sectorID)
    {
        _sectors.TryGetValue(sectorID, out var sectorData);

        return sectorData;
    }

    private Dictionary<string, SectorData> _sectors = new Dictionary<string, SectorData>() 
    {
        { "1110", new SectorMain1110(11, 10) },
        { "1010", new SectorMain1010(10, 10) },
        { "1009", new SectorMain1009(10, 9) },
        { "0910", new SectorMain0910(9, 10) },
        { "1011", new SectorMain1011(10, 11) },
        { "1109", new SectorMain1109(11, 9) },
        { "1111", new SectorMain1111(11, 11) },
        { "0911", new SectorMain0911(9, 11) },
        { "0909", new SectorMain0911(9, 9) },
    };
}
