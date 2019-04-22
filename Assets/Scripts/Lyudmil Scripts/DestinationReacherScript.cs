using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestinationReacherScript : MonoBehaviour
{
    public GameObject MovingObject;
    public GameObject destinationArrow;
    public GameObject activationCollider;
    public Material successMaterial;
    public GameObject nextMoving;
    public GameObject canvas;
    public Text preciseText;
    public ReactOnUserInputMovement script;
    public ManagerController manager;
    private void Update()
    {
        if (canvas.activeSelf == true)
        {
            if (script.getPreciseScore() > 10) {
                manager.getPrecise(10f);
                preciseText.text = "Eye precision: 10/10";
            }
            else
            {
                manager.getPrecise(script.getPreciseScore());
                preciseText.text = "Eye precision: " + script.getPreciseScore().ToString("F1") + "/10";
            }       
        }  
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == activationCollider.name)
        {
            Debug.Log("asd");
            MovingObject.GetComponent<MeshRenderer>().material.color = successMaterial.color;
            int count = MovingObject.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                MovingObject.transform.GetChild(i).gameObject.SetActive(false);
                destinationArrow.SetActive(false);
            }
            nextMoving.SetActive(true);
        }
    }
}
