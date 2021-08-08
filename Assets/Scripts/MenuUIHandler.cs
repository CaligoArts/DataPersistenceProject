using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{

    public InputField playername;
    public static string playernamestr;
    public Text playerNameDisplay;

    private void Awake()
    {
        LoadPlayerName();
    }

    private void Start()
    {
        playerNameDisplay.text = playernamestr;
        //Need to figure out how to get LoadPlayerName(); working here. started to go this route: if (playernamestr == null) {LoadPlayerName();} 

    }

    public void StartNew()
    {
        Debug.Log("Player Name is: " + playername.text);
        playernamestr = playername.text;

        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        //SavePlayerName();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public Text playerNameDisplay;
    }

    public void SavePlayerName()
    {
        SaveData data = new SaveData();
        data.playerNameDisplay = playerNameDisplay;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameDisplay = data.playerNameDisplay;
        }
    }
}
