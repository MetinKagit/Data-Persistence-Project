using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class FlowManager : MonoBehaviour
{
    public void StartNew()
    {
        DataManager.Instance.currentPlayerName = DataManager.Instance.username.text;
        SceneManager.LoadScene(1);
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
