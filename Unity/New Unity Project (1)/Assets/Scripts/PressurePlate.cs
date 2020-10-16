using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    BoxCollider m_collider;
    public GameObject m_swicharoo;
    void Start()
    {
        m_collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerControl>().box)
            {
                PlayerControl pc = other.GetComponent<PlayerControl>(); 
                m_collider.enabled = false;
                pc.state = 2;
                pc.box.parent = null;
                pc.box.position = new Vector3(pc.box.position.x, -7, pc.box.position.z);
                if(m_swicharoo) m_swicharoo.SetActive(!m_swicharoo.activeSelf);
                pc.box.GetComponent<MultiDimesionalObject>().enabled = true;
                pc.box.GetComponent<MultiDimesionalObject>().m_DimensionShiftIndex = GetComponent<MultiDimesionalObject>().m_DimensionShiftIndex;
                pc.box = null;
            }
        }
    }

}
