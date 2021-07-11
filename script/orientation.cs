using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orientation : MonoBehaviour
{
    public bool Portrait;
    public bool Landscape;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Awake()
    {
        Orientation();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void Orientation()
    {
        if (Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else if (Landscape)
        {
            Screen.orientation = ScreenOrientation.Landscape;
        }
    }
}
