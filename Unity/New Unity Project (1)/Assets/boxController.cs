using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    Hover m_hover;
    BoxCollider m_collider;
    MultiDimesionalObject m_mdo;
    void Start()
    {
        m_mdo = GetComponent<MultiDimesionalObject>();
        m_collider = GetComponent<BoxCollider>();
        m_hover = GetComponentInChildren<Hover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!other.GetComponent<PlayerControl>().box)
            {
                m_mdo.enabled = false;
                m_collider.enabled = false;
                transform.parent = other.transform.GetChild(0);
                other.GetComponent<PlayerControl>().state = 1;
                m_hover.m_hovering = false;
                other.GetComponent<PlayerControl>().box = transform;
            }
        }
    }
}
