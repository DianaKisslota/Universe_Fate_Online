public abstract class Character : BaseEntity
{
    public string ClassName {  get; set; }
    private int _expirience;
    public int Expirience
    {
        get { return _expirience; }
        set { _expirience = value; }
    }
}
