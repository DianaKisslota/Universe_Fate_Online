public enum EntityAction
{
    Move,
    DistantAttack,
    PickObject
}
public class Quant
{
    public EntityAction Action { get; private set; }
    public object Object {  get; private set; }

    public Quant(EntityAction _action, object _object)
    {
        Action = _action;
        Object = _object;
    }
}

