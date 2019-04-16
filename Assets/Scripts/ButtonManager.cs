using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private int puzzleNumber = 1;

    public GameObject greenPuzzle;
    public GameObject movingPuzzle;
    public Button button;
    public Text message;
    public GameObject timer;

    public void ButtonClick()
    {
        if (this.puzzleNumber == 1)
        {
            this.StartGreenPuzzle();
        }
    }

    private void StartGreenPuzzle()
    {
        this.HideUI();
        this.greenPuzzle.SetActive(true);

        TimerManager.SetTimerDuration(500f);
        TimerManager.ResetTimer();
        TimerManager.StartTimer();
    }

    private void StartMovingPuzzle()
    {
        this.HideUI();
        this.movingPuzzle.SetActive(true);
        TimerManager.SetTimerDuration(30f);
        TimerManager.ResetTimer();
        TimerManager.StartTimer();
    }

    private void HideUI()
    {
        this.button.gameObject.SetActive(false);
        this.message.gameObject.SetActive(false);
        this.timer.SetActive(true);
    }

    private void ShowUI()
    {
        TimerManager.StopTimer();
        this.timer.SetActive(false);
        this.puzzleNumber = 2;
        this.message.text = "This is our seccond puzzle. Here, you have to look at the sides of the cube in order to move it to the right place";

        this.button.gameObject.SetActive(true);
        this.message.gameObject.SetActive(true);
    }
}
