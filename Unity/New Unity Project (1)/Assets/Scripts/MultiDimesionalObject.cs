using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDimesionalObject : MonoBehaviour
{
    public static int s_DimensionShift = 0;
    [SerializeField] int m_DimensionShiftIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_DimensionShiftIndex!=s_DimensionShift)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
