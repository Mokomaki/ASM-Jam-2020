using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDimesionalObject : MonoBehaviour
{
    public static int s_DimensionShift = 1;
    [SerializeField] int m_DimensionShiftIndex = 0;
    float m_shiftyness = 2;
    [SerializeField] MeshRenderer[] m_rends;

    public bool m_shifting = false;

    public static List<MultiDimesionalObject> s_MDOs = new List<MultiDimesionalObject>();

    float minimum = -1.0f;
    float maximum = 2.0f;

    float t = 0.0f;

    private void Start()
    {
        s_MDOs.Add(this);
        //m_rend = GetComponentInChildren<MeshRenderer>();    
    }

    void FixedUpdate()
    {
        if(m_shiftyness <= -1 || m_shiftyness >= 2)
        {
            m_shifting = false;
        }
        else
        {
            m_shifting = true;
        }

        for(int i = 0; i< m_rends.Length; i++)
        {
            m_rends[i].material.SetFloat("Vector1_C7F57F92", m_shiftyness);
        }

        if(m_DimensionShiftIndex!=s_DimensionShift)
        {


            if (m_shiftyness<=-1)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                t = 0;
            }
            else
            {
                m_shiftyness = Mathf.Lerp(maximum, minimum, t);
                t += 1.5f * Time.deltaTime;
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if (m_shiftyness >= 2)
            {
                t = 0;
            }
            else
            {
                m_shiftyness = Mathf.Lerp(minimum, maximum, t);
                t += 1.5f * Time.deltaTime;
            }
        }
    }
}