using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StrengthBar : MonoBehaviour
{
    //Setting up a bar to visual represent the strength of the player 
    public Slider slider;
    public Image fill;

    public void SetMinStrength(float strength)
    {
        slider.minValue = strength;
        slider.value = strength;
    }

    public void SetStrength(float strength)
    {
        slider.value = strength;
    }
}