public class AK47 : RangeWeapon
{
    public AK47()
    {
        WeaponType = WeaponType.AssaultRifle;
        Weight = 3.3f;
        Volume = 10;
        AddSkill(SkillType.AssaultRifle, 1);
    }
}

