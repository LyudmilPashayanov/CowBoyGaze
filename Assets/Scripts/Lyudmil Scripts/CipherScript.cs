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
     public List<Button> CipherButtons = new List<Button>();
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
    public bool Fifthight = false;

    float startTime;
    public float speed = 1.0f;

    /// <summary>
    /// Store the start scale of the object
    /// </summary>
    void Start()
    {
        _startScale = transform.localScale;
        _gazeAware = GetComponent<GazeAware>();
        startTime = Time.time;
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
        float t = (Time.time - startTime) * speed;
        if (firstDigit.text == "7")
        {
            firstRight = true;
        }
        if(secondDigit.text == "3")
        {
            secondRight = true;
        }
        if(thirdDigit.text == "4")
        {
            ThirdRight = true;
        }
        if (fourthDigit.text == "0")
        {
            FourthRight = true;
        }
        if (FifthDigit.text == "2")
        {
            Fifthight = true;
        }
        if (firstRight == true && secondRight == true && ThirdRight == true && FourthRight == true && Fifthight == true)
        {
            Debug.Log("Game Won Congratulations");
        }
        if (_gazeAware.HasGazeFocus)
        {
            //foreach (Button button in CipherButtons)
            //{
            //    button.interactable = true;
            //}
            
            redDigit.GetComponent<Text>().color = Color.red;
            orangeDigit.GetComponent<Text>().color =new Color(255, 144, 6, 255);
            greenDigit.GetComponent<Text>().color = Color.green;
            blueDigit.GetComponent<Text>().color = Color.blue;
            yellowDigit.GetComponent<Text>().color = Color.yellow;
        }
        else
        {
            //foreach (Button button in CipherButtons)
            //{
            //    button.interactable = true;
            //}
             redDigit.GetComponent<Text>().color = Color.black;
            orangeDigit.GetComponent<Text>().color = Color.black;
            greenDigit.GetComponent<Text>().color = Color.black;
            blueDigit.GetComponent<Text>().color = Color.black;
            yellowDigit.GetComponent<Text>().color = Color.black;
        }
        if (_useBlobEffect)
        {
            float scaleFactor = blendingCurve.Evaluate(_timeSinceButtonPressed / _waitingTime);
            _timeSinceButtonPressed += Time.deltaTime;
            transform.localScale = _startScale + _startScale * scaleFactor;
        }
    }

    IEnumerator StartScaleEffect()
    {
        _useBlobEffect = true;
        yield return new WaitForSeconds(_waitingTime);
        _useBlobEffect = false;
    }
}
