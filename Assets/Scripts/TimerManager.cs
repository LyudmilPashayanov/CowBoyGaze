using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    private static float _timer;
    private static bool _running = false;

    public static float timerDuration = 60;
    public Text timerText;

	void Start ()
    {
        _timer = timerDuration;
	}
	
	void Update ()
    {
        if (_timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (_running)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                this.timerText.text = 0.0f.ToString("F2");
            }
            else
            {
                this.timerText.text = _timer.ToString("F2");
            }
        }
	}

    public static void StartTimer()
    {
        _running = true;
    }

    public static void StopTimer()
    {
        _running = false;
    }

    public static void ResetTimer()
    {
        _timer = timerDuration;
    }

    public static void SetTimerDuration(float duration)
    {
        timerDuration = duration;
    }
}
