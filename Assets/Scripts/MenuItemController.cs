using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class MenuItemController : MonoBehaviour
{
    private GazeAware _gazeAware;
    private GameObject _manager;

    public GameObject puzzle;

    void Start()
    {
        this._gazeAware = GetComponent<GazeAware>();
        this._manager = GameObject.Find("Manager");
    }

    void Update()
    {
        if (this._gazeAware.HasGazeFocus)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x + Time.deltaTime * 10, 150, this.gameObject.transform.localScale.z + Time.deltaTime * 5);
        }
        else if (!this._gazeAware.HasGazeFocus && this.gameObject.transform.localScale.x > 150)
        {
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x - Time.deltaTime * 10, 150, this.gameObject.transform.localScale.z - Time.deltaTime * 5);
        }

        if (this.gameObject.transform.localScale.x > 165)
        {
            this.StartPuzzle();
        }
    }

    private void StartPuzzle()
    {
        gameObject.transform.localScale = new Vector3(150, 150, 150);
        this._manager.GetComponent<ManagerController>().StartPuzzle(puzzle);
    }
}
