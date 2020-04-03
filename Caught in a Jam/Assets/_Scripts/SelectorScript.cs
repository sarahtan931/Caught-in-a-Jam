using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorScript : MonoBehaviour
{
    //Declaring the GameObjects strawberry and blueberry
    public GameObject strawberry;
    public GameObject blueberry;
    //Declaring two Vector3 varibles to store the position of the character and to track and make sure the player stays onscreen
    private Vector3 _characterPosition;
    private Vector3 _offScreen;

    private SpriteRenderer StrawRender, BlueRender;
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        _characterPosition = strawberry.transform.position;
        _offScreen = blueberry.transform.position;
        StrawRender = strawberry.GetComponent<SpriteRenderer>();
        BlueRender = blueberry.GetComponent<SpriteRenderer>();
    }

    
    public void NextCharacterStraw()
    {
       //If the Strawberry was selected, the blueberry is set off screen and disabled
        PlayerPrefs.SetInt(selectedCharacter, 1);
     
        BlueRender.enabled = false;
        blueberry.transform.position = _offScreen;
        strawberry.transform.position = _characterPosition;
        StrawRender.enabled = true;

    }

    public void NextCharacterBlue()
    {
        //If the blueberry was selected, the strawberry is set off screen and disabled
        PlayerPrefs.SetInt(selectedCharacter, 2);
      
        StrawRender.enabled = false;
        strawberry.transform.position = _offScreen;
        blueberry.transform.position = _characterPosition;
        BlueRender.enabled = true;
    }
}
