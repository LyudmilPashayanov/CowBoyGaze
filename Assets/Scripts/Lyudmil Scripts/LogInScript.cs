using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class LogInScript : MonoBehaviour
{

    string saveFilePath;
    public PlayersData playerData;
    public InputField user;
    public InputField pass;
    private string nameOfFile;
    private string username;
    public Text greeting;
    public Text welcome;
    public ManagerController manager;

    public void SetGreeting()
    {
        Debug.Log("asdasdas");
        greeting.gameObject.SetActive(true);
        welcome.text = username;
    }

    public void Load()
    {
        username = user.text;
        nameOfFile = user.text + "_" + pass.text;
        user.text = "";
        pass.text = "";
        saveFilePath = Path.Combine(Application.persistentDataPath, nameOfFile + ".txt");
        string jsonString;
        if (File.Exists(saveFilePath))
        {
            jsonString = File.ReadAllText(saveFilePath);
            Debug.Log("user already exists");
        }
        else
        {
            playerData = new PlayersData();
            playerData.name_pass = nameOfFile;
            playerData.name = username;
            jsonString = JsonUtility.ToJson(playerData);
            File.WriteAllText(saveFilePath, jsonString);
            Debug.Log("creating new one");
            Save();
        }
        playerData = JsonUtility.FromJson<PlayersData>(jsonString);
        SetGreeting();
        manager.LoadHS();
    }

    public void Save() {
        string jsonString = JsonUtility.ToJson(playerData);
        File.WriteAllText(saveFilePath, jsonString);
    }

    public void SaveNewData()
    {
        playerData.concentrationHS= manager.concentrationHS;
        playerData.logicHS = manager.logicalHS;
        playerData.peripheralHS = manager.peripheralHS;
        playerData.rapidHS = manager.rapidHS;
        playerData.precisionHS = manager.preciseHS;
        string jsonString = JsonUtility.ToJson(playerData);
        File.WriteAllText(saveFilePath, jsonString);
    }
}
