using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
        this._timer -= Time.deltaTime;
        this.timerText.text = this._timer.ToString("F2");
	}
}
