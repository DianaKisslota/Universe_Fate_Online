public abstract class BaseEntity
{
    public int Level { get; set; } = 1;
    public string Name {  get; set; }
    public string Description { get; set; }

    private int _strength;
    private int _perception;
    private int _agility;
    private int _constitution;
    private int _intelligence;
    private int _will;

    public int Strength 
    {  
        get { return _strength; } 
        set {  _strength = value; } 
    }

    public int Perception 
    { 
        get { return _perception; } 
        set { _perception = value; }
    }

    public int Agility 
    { 
        get { return _agility; }
        set { _agility = value; }
    }

    public int Constitution 
    { 
        get { return _constitution; }
        set { _constitution = value; }
    }

    public int Intelligence 
    { 
        get { return _intelligence; }
        set { _intelligence = value; }
    }

    public int Will
    {
        get { return _will; }
        set { _will = value; }
    }

    public float MaxHealth
    {
        get
        {
            return Constitution * 20;
        }
    }

    public float MaxWeight
    { 
        get
        {
            return Strength * 20;
        }
    }


}

