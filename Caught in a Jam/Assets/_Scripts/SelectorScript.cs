using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorScript : MonoBehaviour
{
    public GameObject strawberry;
    public GameObject blueberry;
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
        PlayerPrefs.SetInt(selectedCharacter, 1);
     
        BlueRender.enabled = false;
        blueberry.transform.position = _offScreen;
        strawberry.transform.position = _characterPosition;
        StrawRender.enabled = true;

    }

    public void NextCharacterBlue()
    {
        PlayerPrefs.SetInt(selectedCharacter, 2);
      
        StrawRender.enabled = false;
        strawberry.transform.position = _offScreen;
        blueberry.transform.position = _characterPosition;
        BlueRender.enabled = true;
    }
}
