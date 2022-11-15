using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressOnScene : MonoBehaviour
{
    public Slider slider;
    float valueProgress = 0;
    float maxValues = 0;
    private void Start()
    {
        slider.value = valueProgress;
    }

    public void ChangeMaxValus()
    {
        maxValues += 1;
        slider.maxValue = maxValues;
    }

    public void SetValues( float time)
    {
            valueProgress+=1;
            slider.DOValue(valueProgress, time);
    }
}
