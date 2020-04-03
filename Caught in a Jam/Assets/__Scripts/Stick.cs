using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    //Declaring GameObject for the stick player 
    private GameObject stick;
    private GameObject player;
    //Declaring a boolean function to store the direction of the stick 
    private bool stickDirection;
    
    private readonly string selectedCharacter = "SelectedCharacter";

    // Start is called before the first frame update
    void Start()
    {
        stick = this.gameObject;
        stickDirection = PlayerMovement.direction;
        player = this.transform.parent.gameObject;

        //Any other character other than the blueberry can not have a stick 
        if (PlayerPrefs.GetInt(selectedCharacter) != 2)
        {
            stick.SetActive(false);
        }

    }


    // Update is called once per frame
    void Update()
    {

        stickDirection = PlayerMovement.direction;

        if (stickDirection == true)
        {
            this.gameObject.transform.position = new Vector2(6 + player.transform.position.x, -2 + player.transform.position.y);
        }

        if (stickDirection == false)
        {
            this.gameObject.transform.position = new Vector2(-6 + player.transform.position.x, -2 + player.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (stickDirection == true)
            {
                this.gameObject.transform.position = new Vector2(12 + player.transform.position.x, -2 + player.transform.position.y);
            }

            if (stickDirection == false)
            {
                this.gameObject.transform.position = new Vector2(-12 + player.transform.position.x, -2 + player.transform.position.y);
            }
        }

    }
}
    

