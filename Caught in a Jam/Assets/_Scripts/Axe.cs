using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public GameObject item;
    public GameObject tempParent;
    public Transform guide;
    bool carrying;

    // Start is called before the first frame update

    private void Start()
    {
        item.GetComponent<Rigidbody2D>().simulated = true;
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
