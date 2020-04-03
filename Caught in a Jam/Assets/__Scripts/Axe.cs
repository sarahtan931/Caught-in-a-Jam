using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    //Declaring the GameObjects
    public GameObject item;
    public GameObject tempParent;
    public GameObject pickUpText;
    public GameObject doorText;

    public Transform guide;

    bool carrying;
    float health = 4;
    // Start is called before the first frame update

    private void Start()
    {
        // assigns text to inactive so that the text appears only when it is triggered
        pickUpText.SetActive(false);
        doorText.SetActive(false);
        // simulates the rigidbody for the axe so that it sits on the ground when it is not held
        item.GetComponent<Rigidbody2D>().simulated = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if player comes nearby, text appears explaining how to pick up the axe
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);
        }

        // if the door entrapping the friend triggers the collider of the axe, the health of the door diminishes
        // until the door is broken down
        if (other.gameObject.CompareTag("FriendDoor"))
        {
            doorText.SetActive(true);
            health--;
            if (health < 2)
            {
                // destroys the door and displays text
                Destroy(other.gameObject);
                doorText.SetActive(false);
            }
        }
    }

    void Update()
    {
        // if the player is carrying the axe, it activates isKinematic to transfer the rigidbody effects to the script
        if (carrying)
        {
            Carry(item);
            // player can only drop object if they are currently carrying it so carrying = true
            Drop();
        }
        else
        {
            PickUp();
        }
    }

    void Carry(GameObject c)
    {
        c.GetComponent<Rigidbody2D>().isKinematic = true;
    }
    void PickUp()
    {
        // if user presses down arrow, player will pick up axe
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // turns gravity off and isKinematic to false to make it appear that the player is holding the axe
            carrying = true;
            item.GetComponent<Rigidbody2D>().gravityScale = 0;
            item.GetComponent<Rigidbody2D>().isKinematic = false;
            item.transform.position = guide.transform.position;
            item.transform.rotation = guide.transform.rotation;
            item.transform.parent = tempParent.transform;
        }
    }

    // Update is called once per frame
    void Drop()
    {
        // if user presses backspace key, axe will be placed back on the ground
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            carrying = false;
            // turns gravity back on
            item.GetComponent<Rigidbody2D>().gravityScale = 3;
            // makes axe static so player can pick up object in the same spot that it was dropped
            item.isStatic = true;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
        }
    }
}