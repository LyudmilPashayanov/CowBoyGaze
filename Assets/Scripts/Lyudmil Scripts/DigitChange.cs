using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DigitChange : MonoBehaviour {

    public Text currentDigitText;
    private int currentDigit =0;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        currentDigit = Convert.ToInt32(currentDigitText.text);
	}

    public void nextDigit()
    {
        if (currentDigit >= 9)
        {
            currentDigit = 0;
        }
        else
        {
            currentDigit++;
        }
        currentDigitText.text = currentDigit.ToString();
    }
}
