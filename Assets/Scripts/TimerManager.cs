using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    private float _timer;

    public float timerDuration = 60;
    public Text timerText;

	void Start ()
    {
        this._timer = timerDuration;
	}
	
	void Update ()
    {
        if (this._timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        this._timer -= Time.deltaTime;

        if (this._timer <= 0)
        {
            this.timerText.text = 0.0f.ToString("F2");
        }
        else
        {
            this.timerText.text = this._timer.ToString("F2");
        }
	}
}
