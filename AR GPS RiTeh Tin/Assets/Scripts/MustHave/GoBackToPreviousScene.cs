using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToPreviousScene : MonoBehaviour
{
    int counter = 0;

    private void Start()
    {
        counter = 0;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
                SceneManager.LoadScene(0);
            else
            {
                counter++;
                if (counter >= 2)
                {
                    Input.backButtonLeavesApp = true;
                }
            }
        }
    }
}
