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
public class ReactOnUserInputColorChange : MonoBehaviour
{
	public AnimationCurve blendingCurve;
	private Vector3 _startScale;
	private GazeAware _gazeAware;
	private float _waitingTime = 0.1f;
	private float _timeSinceButtonPressed = 0;
	private bool _useBlobEffect = false;
   public float timerColorChange = 1.5f;
    public float timerDestroy = 1.5f;
    public Color defaultColor;
    public bool destroy = false;
    public bool green = false;
    static float rapidMovementScore = 10;
   
    bool reduceOnce =true;
    /// <summary>
    /// Store the start scale of the object
    /// </summary>
    void Start()
    {
        _startScale = transform.localScale;
        _gazeAware = GetComponent<GazeAware>();
        ChangeColorWings(defaultColor);
    }
    public void ChangeColorWings(Color color)
    {
        foreach (Transform item in transform)
        {
            if (item.name != "body")
                item.GetComponent<MeshRenderer>().material.color = color;
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
        if (_gazeAware.HasGazeFocus)
        {        
            IterateColors();
            startWings();
        }
        else
        {
            stopWings();
        }
        if (green)
        {
            timerDestroy -= Time.deltaTime;
            if (timerDestroy <= 0)
            {
                destroy = true;
            }
        }
        if (_useBlobEffect)
		{
			float scaleFactor = blendingCurve.Evaluate(_timeSinceButtonPressed / _waitingTime);
			_timeSinceButtonPressed += Time.deltaTime;
			transform.localScale = _startScale + _startScale * scaleFactor;
		}
	}
    public void IterateColors()
    {
        timerColorChange -= Time.deltaTime;
        if (timerColorChange == 1.0f)
        {
            reduceOnce = true;
            ChangeColorWings(Color.red);
        }
        if (timerColorChange <= 0.5f)
        {
            ChangeColorWings(Color.blue);
        }
        if (timerColorChange <= 0f)
        {
            ChangeColorWings(Color.green);
            green = true;
        }
        if (timerColorChange <= -0.5f)
        {
            green = false;
            destroy = false;
            ChangeColorWings(Color.red);
            timerDestroy = 1.5f;
            timerColorChange = 1.0f;
            if (reduceOnce)
            {
                reduceOnce = false;
                if (rapidMovementScore > 0)
                {
                    rapidMovementScore = rapidMovementScore - 0.4f;
                }
                else
                {
                    rapidMovementScore = 0;
                }
            }
        }
    }
    public void startWings()
    {
        foreach (Transform item in transform)
        {
            if(item.name != "body")
            {
                item.GetComponent<Animator>().enabled = true;
            }
        }
    }
    public void stopWings()
    {
        foreach (Transform item in transform)
        {
            if (item.name != "body")
            {
                item.GetComponent<Animator>().enabled = false;
            }
        }
    }
    public float getScore()
    {
        return rapidMovementScore;
    }

    IEnumerator StartScaleEffect()
	{
		_useBlobEffect = true;
		yield return new WaitForSeconds(_waitingTime);
		_useBlobEffect = false;
	}
}
