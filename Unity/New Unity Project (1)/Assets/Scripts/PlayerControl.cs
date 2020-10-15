using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 respawnPoint;

    public float rayDist;

    public int state = 0;

    [SerializeField] Animator m_animator;

    private void Start()
    {
        respawnPoint = transform.position;
    }

    void Update()
    {
        m_animator.SetInteger("State", state);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Shift(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Shift(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Shift(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Shift(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Shift(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Shift(6);
        }
        
        
        Debug.DrawRay(transform.position, new Vector3(0, -1, 1), Color.red);
        Debug.DrawRay(transform.position, new Vector3(0, -1, -1), Color.red);
        Debug.DrawRay(transform.position, new Vector3(-1, -1, 0), Color.red);
        Debug.DrawRay(transform.position, new Vector3(1, -1, 0), Color.red);

        Movement();
    }

    void Shift(int dimension)
    {
        for(int i = 0; i<MultiDimesionalObject.s_MDOs.Count;i++)
        {
            if(MultiDimesionalObject.s_MDOs[i].m_shifting)
            {
                return;
            }
        }
        MultiDimesionalObject.s_DimensionShift = dimension;
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Physics.Raycast(new Ray(transform.position, new Vector3(0, -1, 1)), rayDist))
            {
                transform.Translate(new Vector3(0, 0, 1));
                
                //TODO ei näin
                transform.GetChild(0).rotation = Quaternion.identity;
                transform.GetChild(0).Rotate(0,-90,0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            
            if (Physics.Raycast(new Ray(transform.position, new Vector3(0, -1, -1)), rayDist))
            {
                transform.Translate(new Vector3(0, 0, -1));
                //TODO ei näin
                transform.GetChild(0).rotation = Quaternion.identity;
                transform.GetChild(0).Rotate(0, 90, 0);

            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            
            if (Physics.Raycast(new Ray(transform.position, new Vector3(-1, -1, 0)), rayDist))
            {
                transform.Translate(new Vector3(-1, 0, 0));
                //TODO ei näin
                transform.GetChild(0).rotation = Quaternion.identity;
                transform.GetChild(0).Rotate(0, 180, 0);

            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            
            if (Physics.Raycast(new Ray(transform.position, new Vector3(1, -1, 0)), rayDist))
            {
                transform.Translate(new Vector3(1, 0, 0));
                //TODO ei näin
                transform.GetChild(0).rotation = Quaternion.identity;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RespawnPoint"))
        {
            respawnPoint = other.transform.position;
        }
        if(other.CompareTag("kill"))
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = respawnPoint+new Vector3(0,2,0);
        }
    }
}