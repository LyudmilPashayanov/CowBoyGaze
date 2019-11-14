using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManagerController : MonoBehaviour
{
    private GameObject _currentPuzzle;
    private List<GameObject> puzzles;
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
    LogInScript loginScript;

    void Start()
    {
        this.puzzles = new List<GameObject>();
        loginScript = gameObject.GetComponent<LogInScript>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loginScript.SaveNewData();
        }  
    }
    public void BackToMenu()
    {
        /*foreach (GameObject puzzle in this.puzzles)
        {
            Destroy(puzzle);
        }*/

        Destroy(this._currentPuzzle);
        menu.gameObject.SetActive(true);      
    }

    public void LoadHS()
    {
        concentrationHS=loginScript.playerData.concentrationHS;
        concentrationText.text = concentrationHS.ToString("F1") + "/10";
        logicalHS = loginScript.playerData.logicHS;
        logicText.text = logicalHS.ToString("F1") + "/10";
        preciseHS = loginScript.playerData.precisionHS;
        preciseText.text = preciseHS.ToString("F1") + "/10";
        rapidHS = loginScript.playerData.rapidHS;
        rapidText.text = rapidHS.ToString("F1") + "/10";
        peripheralHS = loginScript.playerData.peripheralHS;
        peripheralText.text = peripheralHS.ToString("F1") + "/10";

    }

    public void StartPuzzle(GameObject puzzle)
    {
        Instantiate(puzzle);
        this.menu.SetActive(false);
        this._currentPuzzle = GameObject.Find(puzzle.name + "(Clone)");
    }

    public void getLogical(float logical)
    {
        if (logical > logicalHS)
        {
            logicalHS = logical;
            logicText.text =logical.ToString("F1") + "/10";
            loginScript.SaveNewData();
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
            peripheralText.text = peripheral.ToString("F1") + "/10";
            loginScript.SaveNewData();
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
            preciseText.text = precise.ToString("F1") + "/10 ";
            loginScript.SaveNewData();
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
            concentrationText.text = concentration.ToString("F1") + "/10";
            loginScript.SaveNewData();
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
            rapidText.text = rapid.ToString("F1") + "/10";
            loginScript.SaveNewData();
        }

        //    return "New Highscore: "+ rapidHS +" !!!";
        //}
        //else
        //{
        //    return "score: " + rapid ;
        //}
    }
}
