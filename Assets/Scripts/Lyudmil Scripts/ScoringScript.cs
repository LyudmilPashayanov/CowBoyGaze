using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour {

    public bool CipherActive = false;
    public bool MovingGameActive = false;
    public bool ChangeColorActive = false;

    public static float peripheralScore = 10;
    public static float logicalScore = 10;
    public static float rapidMovementScore = 10;
    public static float precisionScore = 10;
    public static float concentrationScore = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateGame(string NameOfTheGame)
    {
        if(NameOfTheGame == "cipher")
        {
            CipherActive = true;
        }
        else if(NameOfTheGame == "moving")
        {
            MovingGameActive = true;
        }
        else if (NameOfTheGame == "colors")
        {
            ChangeColorActive = true;
        }
    }

    public void DecreaseScore(string nameOfScore)
    {
        if(nameOfScore == "peripheral")
        {
            peripheralScore--;
        }
        else if(nameOfScore == "logic")
        {
            logicalScore--;
        }
        else if (nameOfScore == "rapid")
        {
            rapidMovementScore--;
        }
        else if(nameOfScore == "precision")
        {
            precisionScore--;
        } 
        concentrationScore = concentrationScore - 0.3f;
    }
    public List<float> getScore (string nameOfGame)
    {
        List<float> temp = new List<float>();
        if(nameOfGame == "peripheral")
        {
            temp.Add(logicalScore);
            temp.Add(peripheralScore);
        }
        else if(nameOfGame == "moving")
        {
            temp.Add(precisionScore);
            temp.Add(concentrationScore);
        }
        else if (nameOfGame == "color")
        {
            temp.Add(rapidMovementScore);
            temp.Add(concentrationScore);
        }
        return temp;
    }
}
