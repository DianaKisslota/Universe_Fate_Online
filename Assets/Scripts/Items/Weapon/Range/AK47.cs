public class AK47 : RangeWeapon
{
    public AK47()
    {
        Name = "АК-47";
        Description = "Автомат, принятый на вооружение в СССР в 1949 году. АК и его модификации являются самым распространённым стрелковым оружием в мире, он включён в Книгу рекордов Гиннесса";

        WeaponType = WeaponType.AssaultRifle;
        Weight = 3.3f;
        Volume = 10;
        AddSkill(SkillType.AssaultRifle, 1);
    }
}

