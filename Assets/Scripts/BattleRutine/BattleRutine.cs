using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleRutine : MonoBehaviour
{
    private IDataSource _source;
    private SectorData _sectorData;

    private void Start()
    {
        _source = new DataSource();
        _sectorData = _source.GetSectorData(Global.CurrentSectorID);
    }
    public void FinishBattle()
    {
        SceneManager.LoadScene(Global.CurrentMapName);
    }
}
