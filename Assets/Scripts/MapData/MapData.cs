using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MapData : MonoBehaviour
{
    [SerializeField] protected Navigation _navigation;
    [SerializeField] protected Vector2 _startSector;
    [SerializeField] protected TMP_Text _sectorInfoText;
    protected SectorData _currentSector;
    protected IDataSource _source;

    private void Start()
    {       
        _source = new DataSource();
        var x = _startSector.x.ConvertTo<int>();
        var y = _startSector.y.ConvertTo<int>();
        _currentSector = _source.GetSectorData(SectorData.CoordsToID(x, y));
        ReactToArriving();
        _navigation.ArriveToSector += OnArriveToSector;
    }
    private void OnArriveToSector(string direction)
    {
        var nextSectorX = _currentSector.X;
        var nextSectorY = _currentSector.Y;
        switch (direction)
        {
            case "N":
                { nextSectorY++; }
                break;
            case "S":
                { nextSectorY--; }
                break;
            case "W":
                { nextSectorX--; }
                break;
            case "E":
                { nextSectorX++; }
                break;
            case "NW":
                { nextSectorY++; nextSectorX--;
                }
                break;
            case "NE":
                { nextSectorY++; nextSectorX++; }
                break;
            case "SW":
                { nextSectorY--; nextSectorX--; }
                break;
            case "SE":
                { nextSectorY--; nextSectorX++; }
                break;

        }

        var nextSectorID = SectorData.CoordsToID(nextSectorX, nextSectorY);
        _currentSector = _source.GetSectorData(nextSectorID);
        Debug.Log("Прибыли в сектор " + _currentSector.ID);
        ReactToArriving();
    }

    private void ReactToArriving()
    {
        _sectorInfoText.text = "Сектор " + _currentSector.X.ToString() + ":" + _currentSector.Y.ToString() + "\n\n";
        var monsters = _currentSector.GetMonsterList();
        if (!string.IsNullOrEmpty(monsters))
            _sectorInfoText.text += "Здесь обитают монстры:\n" + monsters;
        var npc = _currentSector.GetNPCList();
        if (!string.IsNullOrEmpty(npc))
            _sectorInfoText.text += "Здесь находятся НПС: \n" + npc;
    }

}
