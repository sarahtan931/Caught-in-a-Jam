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
        pickUpText.SetActive(false);
        doorText.SetActive(false);
        item.GetComponent<Rigidbody2D>().simulated = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.SetActive(true);
        }

        if (other.gameObject.CompareTag("FriendDoor"))
        {
            doorText.SetActive(true);
            health--;
            if (health == 0)
            {
                Destroy(other.gameObject);
                doorText.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (carrying)
        {
            Carry(item);
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
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
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            carrying = false;
            item.GetComponent<Rigidbody2D>().gravityScale = 3;
            item.isStatic = true;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
        }
    }
}