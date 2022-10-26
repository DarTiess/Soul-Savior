using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField]private SoulsType soulsType;
    
    public void SetType(SoulsType type)
    {
        soulsType = type;
    }

    public SoulsType GetTypeOfSoul()
    {
        return soulsType;
    }
}
