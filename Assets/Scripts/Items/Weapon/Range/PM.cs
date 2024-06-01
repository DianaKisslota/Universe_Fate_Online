public class PM : RangeWeapon
{
    public PM()
    {
        WeaponType = WeaponType.Pistol;
        Weight = 0.73f;
        Volume = 0.3f;
        AddSkill(SkillType.Pistol, 1);
    }
}

