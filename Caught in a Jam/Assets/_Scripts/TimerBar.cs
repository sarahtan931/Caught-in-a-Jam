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
    public Slider Timer;

    // Use this for initialization
    void Start()
    {
        timesUpText.SetActive(false);
        Timer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        startingTime -= Time.deltaTime;
        Timer.value = startingTime;

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
        await Task.Delay(2000);
        if (livesLeft > 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else
        {
            SceneManager.LoadScene(0);
        }
    }
    }
