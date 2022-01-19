using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDimScreen : MonoBehaviour
{
    private void Start()
    {
        //dont dim my screen while playingon phone
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
