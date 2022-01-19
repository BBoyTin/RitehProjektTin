using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScriptMain : MonoBehaviour
{
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void LoadScondSceneByNumber(int odredOfScene)
    {
        SceneManager.LoadScene(odredOfScene);

    }

}
