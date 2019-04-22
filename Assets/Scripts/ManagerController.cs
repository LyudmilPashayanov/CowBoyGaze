using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour
{
    public List<GameObject> puzzles;
    public GameObject menu;

    void Start()
    {
        this.BackToMenu();
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
