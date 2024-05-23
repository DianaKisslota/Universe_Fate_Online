using System.Collections.Generic;

public abstract class NPC : AIEntity
{
    public List<string> Quests {  get; set; }   //Пока квесты не реализованы поэтому в списке на данный момент хранятся только их названия

    public void AddQuest(string quest)
    {
        Quests.Add(quest);
    }
}

