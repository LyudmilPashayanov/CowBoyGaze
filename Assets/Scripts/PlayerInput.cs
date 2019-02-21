using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class PlayerInput : MonoBehaviour
{
    private void Select()
    {
        return;
    }

    private GazePoint Hover()
    {
        return TobiiAPI.GetGazePoint();
    }

	void Update ()
    {
	}
}
