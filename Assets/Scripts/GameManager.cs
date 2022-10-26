using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public event Action StoreSouls;

   public void StartStoringSouls()
    {
        StoreSouls?.Invoke();
    }
}
