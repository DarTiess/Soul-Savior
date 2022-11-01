using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoulsType
{
    Assasin,
    Bandit,
    Business_woman,
    Samurai,
    Supergirl,
    Viking,
    Character_1,
    Character_2,
    Character_3,
    Character_4,
    Character_5,
    Character_6,
    Character_7,
    Character_8,
    Character_9,
    Character_10,
    Character_11,
    Character_12,
    Character_13,
    Character_14,
    Character_15,
    Character_16
   
}


[System.Serializable]
public class Souls
{
    public SoulsType soulsType;
    public GameObject soulObj;
}
