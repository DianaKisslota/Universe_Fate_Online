public class FeralDog : Mob
{
    public FeralDog()
    {
        Name = "Одичавшая собака";
        Description = "Это больше не друг человека. Голодные злобные и очень агрессивные они сбиваются в стаи и нападают на все живое в округе.";
       
        Strength = 3;
        Perception = 7;
        Agility = 5;
        Constitution = 4;
        Intelligence = 3;
        Will = 6;

        GroupID = 1;
        AggressionLevel = 2;

        AddLoot("Мясо собаки 1-2 шт., Шкура собаки 0-1 шт.");
    }
}

