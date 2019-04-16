//-----------------------------------------------------------------------
// Copyright 2016 Tobii AB (publ). All rights reserved.
//-----------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Tobii.Gaming;
using UnityEngine.UI;

/// <summary>
/// If the object is in focus of the user's eye-gaze when the user presses a 
/// button the object wobbles up.
/// </summary>
/// <remarks>
/// Referenced by the Target game objects in the Simple Gaze Selection example scene.
/// </remarks>
public class CipherScript : MonoBehaviour
{
    public AnimationCurve blendingCurve;

    private Vector3 _startScale;
    private GazeAware _gazeAware;
    private string _buttonName = "Fire1";
    private float _waitingTime = 0.1f;
    private float _timeSinceButtonPressed = 0;
    private bool _useBlobEffect = false;
    public List<GameObject> Digits = new List<GameObject>();
    List<GameObject> chosenDigits = new List<GameObject>();
    public GameObject greenDigit;
    public GameObject redDigit;
    public GameObject orangeDigit;
    public GameObject blueDigit;
    public GameObject yellowDigit;

    public Text firstDigit;
    public Text secondDigit;
    public Text thirdDigit;
    public Text fourthDigit;
    public Text FifthDigit;

    public bool firstRight = false;
    public bool secondRight = false;
    public bool ThirdRight = false;
    public bool FourthRight = false;
    public bool FifthRight = false;
    public bool counterStop = false;
    public int counter=0;
    public float overallTime = 0f;
    public bool gameOn = true;
    public float peripheralScore = 10;
    public float logicalScore = 10;
    public bool startOnce = true;
    public float lookingTimer = 0;
    /// <summary>
    /// Store the start scale of the object
    /// </summary>
    void Start()
    {
        _startScale = transform.localScale;
        _gazeAware = GetComponent<GazeAware>();
        Randomize();
    }
    public void Randomize()
    {
        List<GameObject> temp = Digits;
        for (int i = 0; i <= 5; i++)
        {
            int index = UnityEngine.Random.Range(0, temp.Count - 1);
            chosenDigits.Add(temp[index]);
            temp.Remove(temp[index]);
        }
        
    }
    /// <summary>
    /// Reset the component when it gets disabled
    /// </summary>
    void OnDisable()
    {
        _useBlobEffect = false;
        transform.localScale = _startScale;
    }

    /// <summary>
    /// Do the wobble effect and react to the users input
    /// </summary>
    void Update()
    {
        if (gameOn)
        {
            overallTime += Time.deltaTime;
            CheckNumbers();
        }
        
        if (_gazeAware.HasGazeFocus)
        {
            //foreach (Button button in CipherButtons)
            //{
            //    button.interactable = true;
            //}
            if (startOnce)
            {
                gameOn = true;
                startOnce = false;
            }
            if (gameOn)
            {
                lookingTimer += Time.deltaTime;
                if (counterStop)
                {
                    counter++;
                    counterStop = false;
                }
            }
            chosenDigits[0].GetComponent<Text>().color =  Color.green;
            chosenDigits[1].GetComponent<Text>().color = Color.yellow; 
            chosenDigits[2].GetComponent<Text>().color = Color.red;
            chosenDigits[3].GetComponent<Text>().color = new Color(255, 144, 6, 255);
            chosenDigits[4].GetComponent<Text>().color =  Color.blue;
        }
        else
        {
            //foreach (Button button in CipherButtons)
            //{
            //    button.interactable = true;
            //}
            counterStop = true;
            chosenDigits[0].GetComponent<Text>().color = Color.black;
            chosenDigits[1].GetComponent<Text>().color = Color.black;
            chosenDigits[2].GetComponent<Text>().color = Color.black;
            chosenDigits[3].GetComponent<Text>().color = Color.black;
            chosenDigits[4].GetComponent<Text>().color = Color.black;
        }
        if (_useBlobEffect)
        {
            float scaleFactor = blendingCurve.Evaluate(_timeSinceButtonPressed / _waitingTime);
            _timeSinceButtonPressed += Time.deltaTime;
            transform.localScale = _startScale + _startScale * scaleFactor;
        }
    }

    public void CheckNumbers()
    {
        if (firstDigit.text == chosenDigits[0].GetComponent<Text>().text)
        {
            Debug.Log("chosen digit[0] text is " + chosenDigits[0].GetComponent<Text>().text);
            firstRight = true;
        }
        else
        {
            firstRight = false;
        }
        if (secondDigit.text == chosenDigits[1].GetComponent<Text>().text)
        {
            secondRight = true;
        }
        else
        {
            secondRight = false;
        }
        if (thirdDigit.text == chosenDigits[2].GetComponent<Text>().text)
        {
            ThirdRight = true;
        }
        else
        {
            ThirdRight = false;
        }
        if (fourthDigit.text == chosenDigits[3].GetComponent<Text>().text)
        {
            FourthRight = true;
        }
        else
        {
            FourthRight = false;
        }
        if (FifthDigit.text == chosenDigits[4].GetComponent<Text>().text)
        {
            FifthRight = true;
        }
        else
        {
            FifthRight = false;
        }
        if (firstRight == true && secondRight == true && ThirdRight == true && FourthRight == true && FifthRight == true)
        {
            gameOn = false;
            Debug.Log("game won");
            Debug.Log("peripheral score = " + getPeripheralScore());
            Debug.Log("logical score = " + getLogicalScore().ToString());
          
        }
    }
    public float getPeripheralScore()
    {
        if(counter < 3)
        {
            for (float i = 0; i < lookingTimer-3; i = +0.3f) // calculates the score based on how much time you spend                                                           
            {                                                // looking at the unlocker.
                peripheralScore = peripheralScore - 0.1f;
            }
        }
        else
        {
            for (int i = 0; i < counter-3; i++)
            {
                peripheralScore = peripheralScore -0.6f;
            }
            for (float i = 0; i < lookingTimer;)
            {
                peripheralScore = peripheralScore - 0.1f;
                i= i + 0.3f;
            }
        }
        return peripheralScore;
    }
    public float getLogicalScore()
    {
        if (overallTime < 10)
        {
            logicalScore = 10;
        }
        else
        {
            for (float i = 0; i < overallTime-10;)
            {
                logicalScore = logicalScore - 0.2f; // takes out ~ 0.6 ~ points for each second after the 10th second.
                i = i + 0.3f;
            }
        }
        return logicalScore;
    }

    IEnumerator StartScaleEffect()
    {
        _useBlobEffect = true;
        yield return new WaitForSeconds(_waitingTime);
        _useBlobEffect = false;
    }
}
