using System.Collections.Generic;

public abstract class Mob : AIEntity
{
    public int GroupID {  get; set; }
    public int AggressionLevel { get; set; }
    public List<string> Loot { get; set; } = new List<string>();        //Поскольку предметы пока не реализованы, на данном этапе в списке хранятся только их описание

    public void AddLoot(string loot)
    {
        Loot.Add(loot);
    }
}

