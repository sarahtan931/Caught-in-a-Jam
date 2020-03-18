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
    void OnTriggerEnter2D(Collider2D collision)
    {
        Transform rootT = collision.gameObject.transform.root;
        GameObject go = rootT.gameObject;



        // checks if the current GameObject triggering Hero's collider is the same as the last
        // if it is, the collision is ignored, if not it sets the lastTriggerGo to the current triggering Gameobject
        if (go == _lastTriggerGo)
        {
            return;
        }
        _lastTriggerGo = go;

        // destroys the enemy the GameObject collides with the enemy (object with tag "Enemy")
        if (go.tag == "Enemy")
        {
            destroyEnemy--;
            Destroy(go);
        }
    }
    public float destroyEnemy
    {
        get
        {
            return (_destroyEnemy);
        }
        set
        {
            _destroyEnemy = Mathf.Min(value, 4);
            if (value < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }


}
