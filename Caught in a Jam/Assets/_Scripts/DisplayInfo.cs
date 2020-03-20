using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    private int healthTrack = PlayerMovement.health;
    private Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      healthTrack = PlayerMovement.health;
      healthText.text = "Health: " + healthTrack + "/5";
    }
}
