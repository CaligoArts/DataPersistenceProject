using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{

    public InputField playername;

    

    public void StartNew()
    {
        Debug.Log("Player Name is: " + playername.text);
        MySettings.playernamestr = playername.text;

        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif

    }
}
