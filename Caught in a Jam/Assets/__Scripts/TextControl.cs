﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    //Displaying the stats to the User 
    public Text textBox;

    // Update is called once per frame
    void Update()
    {

        if (textBox.gameObject.tag == "Speed")
        {
            textBox.text = "Speed: " + PlayerMovement.speed;
        }

        //printing the strength 
        if (textBox.gameObject.tag == "Strength")
        {
            textBox.text = "Strength: " + PlayerMovement.strength;
        }
        //printing the points 
        if (textBox.gameObject.tag == "Points")
        {
            textBox.text = "Score: " + StatsSave.S.points;
        }
    }
}
