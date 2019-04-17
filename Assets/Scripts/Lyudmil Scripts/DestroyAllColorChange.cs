using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAllColorChange : MonoBehaviour {

    public Canvas resultPlane;
    public ReactOnUserInputColorChange scoreScript;
    static float concentrationScore = 10;
    public Text rapidText;
    public Text concentrationText;
    public float overallTime = 0;
    public bool gameOver = false;
    void Update () {
        if(!gameOver)
        {
            overallTime += Time.deltaTime;
            checkAll();
        }
        getAllChildren();
        
	}
    public List<bool> getAllChildren()
    {
        List<bool> allDestroy = new List<bool>();
        foreach (Transform item in transform)
        {
            allDestroy.Add(item.GetComponent<ReactOnUserInputColorChange>().destroy);
        }
        return allDestroy;
    }
    public void checkAll()
    {
        foreach (bool item in getAllChildren())
        {
            if (item == false)
            {
                Debug.Log("NO");
                return;
            }
        }
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
        gameOver = true;
         if(overallTime < 8)
        {
            concentrationText.text = "Eye Concentration skills: 10/10";
        }
        else
        {
            for (float i = 0; i < overallTime-8;)
            {
                concentrationScore = concentrationScore - 0.1f;
                i = i + 0.3f;
            }
        }
        resultPlane.gameObject.SetActive(true);
        if (scoreScript.getScore() == 10)
        {
            rapidText.text = "Rapid Eye Movement skills: 10/10";
        }
        else
        {
            rapidText.text = "Rapid Eye Movement skills: " + scoreScript.getScore().ToString("F1") + "/10";
        }
        concentrationText.text = "Eye Concentration skills: "+ concentrationScore.ToString("F1") +"/10";

    }
}
