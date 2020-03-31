﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendInstruction : MonoBehaviour
{
    public float time = 5; //Seconds to read the text

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
