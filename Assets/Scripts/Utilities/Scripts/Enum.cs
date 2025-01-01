using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum SlotType
{
    None,
    CONTAINER,
    WEAPON,
    ARMOR_HEAD,
    ARMOR_EYE,
    ARMOR_BODY,
    ARMOR_LEG,
    ARMOR_FEET,
    ACTION
}

public enum ItemType
{
    ARMOR_HEAD,
    ARMOR_EYE,
    ARMOR_BODY,
    ARMOR_LEG,
    ARMOR_FEET,
    WEAPON,
    POTION,
    FOOD,
    STUFF,
    BOOK,
    ATLAS,
    ARTIFACT,
};

public enum MaterialType 
{ 
    IRON,
    COPPER,
    GOLD,
}

public enum EntityState
{
    ALIVE,
    SLEEP,
    DEATH
}

public enum MemoryType
{
    SOCIAL_MEMORY,
    NATURAL_MEMORY
}

public enum MoodType
{
    NETURAL,
    HAPPY,
    SAD,
}

public enum StereoType
{
    HATE,
    NETURAL,
    LIKE,
    LOVE,
}


