using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSave : MonoBehaviour
{
    public int strength;
    public float speed;
    public int points;

    private readonly string selectedCharacter = "SelectedCharacter";

    static public StatsSave S { get; private set; }

    void Awake()
    {
        if (S == null)
        {
            S = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SetStats();
    }

    public void SetStats()
    {
        if (PlayerPrefs.GetInt(selectedCharacter) == 1)
        {
            speed = 60f;

            strength = 1;
            points = 0;
        }
        if (PlayerPrefs.GetInt(selectedCharacter) == 2)
        {
            speed = 80f;

            strength = 2;
            points = 0;
        }
    }
    public void SavePlayer()
    {
        StatsSave.S.strength = strength;
        StatsSave.S.speed = speed;
        StatsSave.S.points = points;
    }

    public void SetSpeed(float s)
    {
        speed = s;

    }

    public void SetStrength(int s)
    {
        strength = s;
    }

    public void SetPoints(int s)
    {
        points += s;
    }

    public void LoseSpeed()
    {
        speed -= 10;
    }
}

