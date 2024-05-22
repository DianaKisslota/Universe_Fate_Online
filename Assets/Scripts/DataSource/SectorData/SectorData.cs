using System.Collections.Generic;

public abstract class SectorData
{
    public int X { get; }
    public int Y { get; }
    private string _prefix;
    public string Prefix => _prefix;

    public bool IsRestricted() => false;
    public SectorData(string prefix, int x, int y)
    {
        _prefix = prefix;
        X = x;
        Y = y;
    }
    public static string CoordsString(int x, int y)
    {
        return x.ToString().PadLeft(2, '0') + y.ToString().PadLeft(2, '0');
    }

    public static string CoordsToID(string prefix, int x, int y)
    {
        return prefix + CoordsString(x, y);
    }
    public string ID => CoordsToID(_prefix, X, Y);
    public string Coords => CoordsString(X, Y);

    protected List<string> Monsters { get; } = new List<string>();
    protected List<string> NPC { get; } = new List<string>();

    public void AddMonster(string monster)
    {
        Monsters.Add(monster);
    }

    public void ADDNPC (string npc)
    {
        NPC.Add(npc);
    }
    public string GetMonsterList()
    {
        string result = string.Empty;
        foreach (string monster in Monsters)
        {
            result += monster + "\n";
        }
        return result;
    }

    public string GetNPCList()
    {
        string result = string.Empty;
        foreach (string npc in NPC)
        {
            result += npc + "\n";
        }
        return result;
    }

}
