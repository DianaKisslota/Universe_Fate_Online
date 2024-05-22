using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MapData : MonoBehaviour
{
    [SerializeField] protected Navigation _navigation;
    [SerializeField] protected Vector2 _startSector;
    [SerializeField] protected TMP_Text _sectorInfoText;
    protected SectorData _currentSector;
    protected IDataSource _source;
    public event Action<List<string>> RefreshDirections;
    protected string Name {get; set;}

    private void Start()
    {       
        _source = new DataSource();
        var x = _startSector.x.ConvertTo<int>();
        var y = _startSector.y.ConvertTo<int>();
        _currentSector = _source.GetSectorData(SectorData.CoordsToID(Name, x, y));
        ReactToArriving();
        _navigation.ArriveToSector += OnArriveToSector;
        RefreshDirections += _navigation.UpdateButtons;
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

        var nextSectorID = SectorData.CoordsToID(Name, nextSectorX, nextSectorY);
        _currentSector = _source.GetSectorData(nextSectorID);
        Debug.Log("Прибыли в сектор " + _currentSector.ID);
        ReactToArriving();
        CheckDirections();
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

    private bool isSectorAvailable(int x, int y)
    {
        var sector = _source.GetSectorData(SectorData.CoordsToID(Name, x, y));
        return sector != null && !sector.IsRestricted();

    }

    private void CheckDirections()
    {
        var availableDirections = new List<string>();
        if (isSectorAvailable(_currentSector.X, _currentSector.Y + 1))
            availableDirections.Add("N");
        if (isSectorAvailable(_currentSector.X, _currentSector.Y - 1))
            availableDirections.Add("S");
        if (isSectorAvailable(_currentSector.X - 1, _currentSector.Y))
            availableDirections.Add("W");
        if (isSectorAvailable(_currentSector.X + 1, _currentSector.Y))
            availableDirections.Add("E");
        if (isSectorAvailable(_currentSector.X - 1, _currentSector.Y + 1))
            availableDirections.Add("NW");
        if (isSectorAvailable(_currentSector.X + 1, _currentSector.Y + 1))
            availableDirections.Add("NE");
        if (isSectorAvailable(_currentSector.X + 1, _currentSector.Y - 1))
            availableDirections.Add("SE");
        if (isSectorAvailable(_currentSector.X - 1, _currentSector.Y - 1))
            availableDirections.Add("SW");

        RefreshDirections?.Invoke(availableDirections);
    }

}
