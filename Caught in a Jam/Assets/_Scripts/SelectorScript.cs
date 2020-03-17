using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorScript : MonoBehaviour
{
    public GameObject strawberry;
    public GameObject peach;
    public GameObject apple;
    private Vector3 _characterPosition;
    private Vector3 _offScreen;
    private SpriteRenderer StrawRender, AppleRender, PeachRender;
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        PlayerPrefs.SetInt(selectedCharacter,1);
        _characterPosition = strawberry.transform.position;
        _offScreen = apple.transform.position;
        StrawRender = strawberry.GetComponent<SpriteRenderer>();
        AppleRender = apple.GetComponent<SpriteRenderer>();
        PeachRender = peach.GetComponent<SpriteRenderer>();
    }

    public void NextCharacterPeach()
    {
        PlayerPrefs.SetInt(selectedCharacter, 2);
        StrawRender.enabled = false;
        strawberry.transform.position = _offScreen;
        AppleRender.enabled = false;
        apple.transform.position = _offScreen;
        peach.transform.position = _characterPosition;
        PeachRender.enabled = true;
    }

    public void NextCharacterApple()
    {
        PlayerPrefs.SetInt(selectedCharacter, 3);
        PeachRender.enabled = false;
        peach.transform.position = _offScreen;
        StrawRender.enabled = false;
        strawberry.transform.position = _offScreen;
        apple.transform.position = _characterPosition;
        AppleRender.enabled = true;
      
    }

    public void NextCharacterStraw()
    {
        PeachRender.enabled = false;
        peach.transform.position = _offScreen;
        AppleRender.enabled = false;
        apple.transform.position = _offScreen;
        strawberry.transform.position = _characterPosition;
        StrawRender.enabled = true;

    }
}
