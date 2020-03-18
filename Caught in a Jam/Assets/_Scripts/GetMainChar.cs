using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{

    public Sprite strawberry, peach, apple, blueberry;
    private SpriteRenderer mySprite;
    private readonly string selectedCharacter = "SelectedCharacter";

    private Text stats;

    private int strength = 0;
    private int defense = 0;
    private float rot = 0;

    private void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
        stats = this.GetComponent<Text>();

    }
    // Start is called before the first frame update
    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch (getCharacter)
        {
            case 1:
                mySprite.sprite = peach;
                strength = 2;
                defense = 4;
                rot = 1.05f;
                break;
            case 2:
                mySprite.sprite = apple;
                strength = 4;
                defense = 2;
                rot = 1.25f;
                break;
            case 3:
                mySprite.sprite = strawberry;
                strength = 3;
                defense = 2;
                rot = 1f;
                break;
            case 4:
                mySprite.sprite = blueberry;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //stats.text = "Strength: " + strength + "/10, Defense: " + defense + "/10";
    }
}
