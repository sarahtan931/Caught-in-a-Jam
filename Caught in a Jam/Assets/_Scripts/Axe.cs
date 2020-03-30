using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    float throwForce = 600;
    Vector2 objectPos;
    public bool isHolding = false;
    public GameObject axe;
    public GameObject tempParent;
    // Start is called before the first frame update

    private void Update()
    {
        if (isHolding == true)
        {
            axe.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            axe.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1))
            {
                //throw
                axe.GetComponent<Rigidbody2D>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = axe.transform.position;
            axe.transform.SetParent(null);
            axe.GetComponent<Rigidbody2D>().gravityScale =1;
            axe.transform.position = objectPos;
        }
    }
    void OnMouseDown()
    {
        isHolding = true;
        axe.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        isHolding = false;
        axe.GetComponent<Rigidbody>().useGravity = true;
    }
}
