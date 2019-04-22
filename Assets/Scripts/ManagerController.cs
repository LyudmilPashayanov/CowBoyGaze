﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManagerController : MonoBehaviour
{
    public List<GameObject> puzzles;
    public GameObject menu;
    public float concentrationHS=0;
    public float peripheralHS=0;
    public float logicalHS=0;
    public float rapidHS = 0;
    public float preciseHS=0;
    public Text logicText;
    public Text preciseText;
    public Text peripheralText;
    public Text rapidText;
    public Text concentrationText;
    void Start()
    {
        BackToMenu();
    }
    public void BackToMenu()
    {
        foreach (GameObject gb in puzzles)
        {
             gb.SetActive(false);
        }
        menu.gameObject.SetActive(true);      
    }
    public void StartPuzzle(GameObject puzzle)
    {
        puzzle.SetActive(true);
        this.menu.SetActive(false);
    }
   public void getLogical(float logical)
    {
        if (logical > logicalHS)
        {
            logicalHS = logical;
            logicText.text = "Logic Eye Movement: " + logical.ToString("F2") + "/10";
        }
        //    return "New Highscore: " + logicalHS + " !!!";
        //}
        //else
        //{
        //    return "score: " + logical;
        //}
    }
    public void getPeripheral(float peripheral)
    {
        if (peripheral > peripheralHS)
        {
            peripheralHS = peripheral;
            peripheralText.text = "Peripheral Sight: " + peripheral.ToString("F2") + "/10";
        }
        //    return "New Highscore: " + peripheralHS + " !!!";
        //}
        //else
        //{
        //    return "score: " + peripheral;
        //}
    }
    public void getPrecise(float precise)
    {
        if (precise > preciseHS)
        {

            preciseHS = precise;
            preciseText.text = "Precise Eye Movement: " + precise.ToString("F2") + "/10 ";
        }
        //    return "New Highscore: " + preciseHS + " !!!";
        //}
        //else
        //{
        //    return "score: " + precise;
        //}
    }
    public void getConcentration(float concentration)
    {
        if (concentration > concentrationHS)
        {
            concentrationHS = concentration;
            concentrationText.text = "Eye Concentration: " + concentration.ToString("F2") + "/10";
        }
        //    return "New Highscore: " + concentrationHS + " !!!";
        //}
        //else
        //{
        //    return "Conscore: " + concentration;
        //}
    }
    public void getRapid(float rapid)
    {
        if (rapid > rapidHS)
        {
            rapidHS = rapid;
            rapidText.text = "Rapid Eye Movement: " + rapid.ToString("F2") + "/10";
        }
        //    return "New Highscore: "+ rapidHS +" !!!";
        //}
        //else
        //{
        //    return "score: " + rapid ;
        //}
    }
}
