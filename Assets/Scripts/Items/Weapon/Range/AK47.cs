public class AK47 : RangeWeapon
{
    public AK47()
    {
        WeaponType = WeaponType.AssaultRifle;
        AddSkill(SkillType.AssaultRifle, 1);
    }
}

