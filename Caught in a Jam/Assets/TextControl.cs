using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public Text textBox;

    // Update is called once per frame
    void Update()
    {

        if (textBox.gameObject.tag == "Speed")
        {
            print(textBox.gameObject.tag);
            textBox.text = "Speed: " + PlayerMovement.speed;
        }

        if (textBox.gameObject.tag == "Strength")
        {
            print(textBox.gameObject.tag);
            textBox.text = "Strength: " + PlayerMovement.strength;
        }
    }
}
