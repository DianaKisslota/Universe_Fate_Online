using System;
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

    public List<EntitySpawner> Monsters { get; } = new List<EntitySpawner>();
    public List<ItemSpawner> Items { get; } = new List<ItemSpawner> ();
    protected List<string> NPC { get; } = new List<string>();

    public void AddItem(Type itemType)
    {
        Items.Add(new ItemSpawner(itemType));
    }

    public void AddMonster(EntitySpawner spawner)
    {
        Monsters.Add(spawner);
    }

    public void ADDNPC (string npc)
    {
        NPC.Add(npc);
    }
    public string GetMonsterList()
    {
        string result = string.Empty;
        foreach (EntitySpawner monster in Monsters)
        {
            result += monster.MonsterName + "\n";
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
