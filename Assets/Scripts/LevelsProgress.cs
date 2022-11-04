using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsProgress : ProgressOnScene
{
   public void SetMaxValue(int count)
    {
        slider.maxValue = count;
    }

   public void  SetLevel(float num)
    {
        Debug.Log(num);

        slider.DOValue(num, 0);
    }
}
