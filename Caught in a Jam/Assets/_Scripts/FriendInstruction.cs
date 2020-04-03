using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendInstruction : MonoBehaviour
{
    public float time = 5f; //Seconds to read the text

    IEnumerator Start()
    {
        // displays text for certain amount of time before destroying the text
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
