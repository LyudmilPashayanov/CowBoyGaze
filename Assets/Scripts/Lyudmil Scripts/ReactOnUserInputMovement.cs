//-----------------------------------------------------------------------
// Copyright 2016 Tobii AB (publ). All rights reserved.
//-----------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Tobii.Gaming;

/// <summary>
/// If the object is in focus of the user's eye-gaze when the user presses a 
/// button the object wobbles up.
/// </summary>
/// <remarks>
/// Referenced by the Target game objects in the Simple Gaze Selection example scene.
/// </remarks>
public class ReactOnUserInputMovement : MonoBehaviour
{
    public AnimationCurve blendingCurve;

    private Vector3 _startScale;
    private GazeAware _gazeAware;
    private string _buttonName = "Fire1";
    private float _waitingTime = 0.1f;
    private float _timeSinceButtonPressed = 0;
    private bool _useBlobEffect = false;
    float timerColorChange = 1.5f;
    public float timerDestroy = 1.5f;
    static List<bool> allgreen = new List<bool>();
    public Color defaultColor;
    public bool side; // if true = right side / if false = left side
    public GameObject parent;
    
    /// <summary>
    /// Store the start scale of the object
    /// </summary>
    void Start()
    {
        _startScale = transform.localScale;
        _gazeAware = GetComponent<GazeAware>();
        gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
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
        
        if (_gazeAware.HasGazeFocus)
        {
            if(side == true)
            {
                
                parent.transform.Translate(new Vector3(2,0,0) *Time.deltaTime);
            }
            if(side == false)
            {
                parent.transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);

            }

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
