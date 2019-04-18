using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour
{
    public List<GameObject> puzzles;
    public GameObject menu;

    private float counter = 4;

    void Start()
    {
        this.BackToMenu();
    }

    void Update()
    {
        this.counter -= Time.deltaTime;
        Debug.Log(this.counter);
        if (this.counter <= 0)
        {
            this.StartPuzzle(this.puzzles[2]);

            this.counter = 100;
        }
    }

    public void BackToMenu()
    {
        this.menu.gameObject.SetActive(true);

        foreach (GameObject gb in this.puzzles)
        {
            if (gb.activeSelf)
            {
                gb.SetActive(false);
            }
        }
    }

    public void StartPuzzle(GameObject puzzle)
    {
        puzzle.SetActive(true);
        this.menu.SetActive(false);
    }
}
