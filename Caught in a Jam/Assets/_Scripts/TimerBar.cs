using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public GameObject timesUpText;
    public float livesLeft = 3f;

    public float startingTime = 100.0f;
    public Slider timer;

    // Use this for initialization
    void Start()
    {
        // Sets text to false so that the text only appears once time has run out
        timesUpText.SetActive(false);
        timer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // sets the timer to a number of seconds
        startingTime -= Time.deltaTime;
        timer.value = startingTime;

        // if time has run out (time = 0) then text should appear to say Time's Up! and should load the main screen
        if (startingTime <= 0)
        {
            timesUpText.SetActive(true);
            startingTime = 0;
            livesLeft--;
            RestartAsync();
        }
    }
    // Pause before restarting game
    async Task RestartAsync()
    {
        // loads starting screen
        await Task.Delay(2000);
        if (livesLeft > 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else
        {
            SceneManager.LoadScene(0);
        }
    }
    }
