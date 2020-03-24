using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMinSpeed(float speed)
    {
        slider.minValue = speed;
        slider.value = speed;

        
    }

    public void SetSpeed(float speed)
    {
        slider.value = speed;

        

    }
}