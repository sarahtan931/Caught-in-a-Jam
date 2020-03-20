using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private bool stickDirection;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        stickDirection = PlayerMovement.direction;
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        stickDirection = PlayerMovement.direction;

        if(stickDirection == true)
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
