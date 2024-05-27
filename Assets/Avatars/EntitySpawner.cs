using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EntitySpawner
{ 
    public Type EntityType { get; private set; }
    public int MinSpawn {  get; private set; }
    public int MaxSpawn { get; private set; }

    public string MonsterName
    {
        get
        {
            return GetMonster().Name;
        }
    }

    public BaseEntity GetMonster()
    {
        return Activator.CreateInstance(EntityType) as BaseEntity;
    }

    public EntitySpawner(Type entityType, int minSpawn, int maxSpawn = 0)
    {
        EntityType = entityType;
        MinSpawn = minSpawn;
        MaxSpawn = maxSpawn;
    }
}
    

