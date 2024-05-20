using System.Collections.Generic;
using UnityEngine;

public abstract class SectorData
{
    public int X { get; }
    public int Y { get; }
    public SectorData(int y, int x)
    {
        X = x;
        Y = y;
    }
    public static string CoordsToID(int x, int y)
    {
        return  y.ToString().PadLeft(2, '0') + x.ToString().PadLeft(2, '0');
    }
    public string ID => CoordsToID(X, Y);

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
