using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject _lastTriggerGo = null;
    [SerializeField]
    private float _destroyEnemy = 1;
    private BoundsCheck bndCheck;
    
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
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
