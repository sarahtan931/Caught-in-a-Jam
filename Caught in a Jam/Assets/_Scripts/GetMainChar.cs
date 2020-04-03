using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{
    //Declaring the Sprite variables strawberry and blueberry 
    public Sprite strawberry,blueberry;
    private SpriteRenderer mySprite;
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
       

    }
    // Start is called before the first frame update
    void Start()
    {
        //Choosing between a strawberry and a blueberry 
        //Declaring an int value to store the choice 
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        //Switch statement between a strawberry and blueberry. First case representing the strawberry player, second case representing the blueberry player
        switch (getCharacter)
        {
            case 1:
                mySprite.sprite = strawberry;
                break;
            case 2:
                mySprite.sprite = blueberry;
                break;
           
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
