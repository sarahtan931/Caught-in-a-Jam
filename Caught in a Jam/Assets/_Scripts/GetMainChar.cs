using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{
    //Declaring the Sprite variables strawberry and blueberry 
    public Sprite strawberry,blueberry;
    private SpriteRenderer _mySprite;
    private readonly string _selectedCharacter = "SelectedCharacter";

    void Awake()
    {
        _mySprite = this.GetComponent<SpriteRenderer>();
       

    }
    // Start is called before the first frame update
    void Start()
    {
        //Choosing between a strawberry and a blueberry 
        //Declaring an int value to store the choice 
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(_selectedCharacter);

        //Switch statement between a strawberry and blueberry. First case representing the strawberry player, second case representing the blueberry player
        switch (getCharacter)
        {
            case 1:
                _mySprite.sprite = strawberry;
                break;
            case 2:
                _mySprite.sprite = blueberry;
                break;
           
            default:
                break;
        }
    }

}
