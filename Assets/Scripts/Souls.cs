using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoulsType
{
    Assasin,
    Bandit,
    Business_woman,
    Knight,
    Samurai,
    Sniper,
    Soldier,
    Supergirl,
    Viking
}


[System.Serializable]
public class Souls
{
    public SoulsType soulsType;
    public GameObject soulObj;
}
