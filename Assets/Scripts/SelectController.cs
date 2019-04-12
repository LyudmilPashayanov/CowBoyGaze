using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    private GazeAware _gazeAware;

    void Start ()
    {
        this._gazeAware = GetComponent<GazeAware>();
    }
	
	void Update ()
    {
		if (this._gazeAware.HasGazeFocus)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + Time.deltaTime, this.gameObject.transform.localScale.y + Time.deltaTime, 1);
        }
        else if (!this._gazeAware.HasGazeFocus && this.gameObject.transform.localScale.x > 1)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x - Time.deltaTime, this.gameObject.transform.localScale.y - Time.deltaTime, 1);
        }
	}
}
