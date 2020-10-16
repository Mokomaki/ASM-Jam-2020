using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuAnimation : MonoBehaviour
{

    public int min, max;

    void Start()
    {
        InvokeRepeating("changeShift", 0, 3);
    }

    void changeShift()
    {
        if(MultiDimesionalObject.s_DimensionShift<max)
        {
            MultiDimesionalObject.s_DimensionShift++;
        }else if (MultiDimesionalObject.s_DimensionShift==max)
        {
            MultiDimesionalObject.s_DimensionShift = min;
        }
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}