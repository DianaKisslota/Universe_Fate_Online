using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Weapon : Item
{
    public List<Skill> SkillsNeeded {  get; private set; } = new List<Skill>();
    public WeaponType WeaponType { get; set; }

    public void AddSkill(SkillType skill, int skillLevel)
    {
        SkillsNeeded.Add(new Skill() { Type = skill, Level = skillLevel });
    }
}

