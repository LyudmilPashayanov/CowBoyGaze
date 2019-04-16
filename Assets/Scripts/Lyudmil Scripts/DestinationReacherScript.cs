using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReacherScript : MonoBehaviour
{
    public GameObject MovingObject;
    public GameObject destinationArrow;
    public GameObject lookAwayPuzzle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ActivationCollider")
        {
            Debug.Log("asd");
            MovingObject.GetComponent<MeshRenderer>().material.color = Color.green;
            int count = MovingObject.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                MovingObject.transform.GetChild(i).gameObject.SetActive(false);
                destinationArrow.SetActive(false);
            }

            this.lookAwayPuzzle.SetActive(true);
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
