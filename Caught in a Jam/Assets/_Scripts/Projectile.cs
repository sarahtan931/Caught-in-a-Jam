using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    //calls move function for every frame
    void Update()
    { 

        //checks if BoundScript is active on GameObject and if so destroys object if needed
        if (bndCheck != null && (bndCheck.offDown || bndCheck.offLeft || bndCheck.offRight))
        {
            Destroy(gameObject);
        }

    }
}
