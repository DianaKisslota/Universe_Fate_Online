using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataSource
{
    public SectorData GetSectorData(string sectorID);
}
