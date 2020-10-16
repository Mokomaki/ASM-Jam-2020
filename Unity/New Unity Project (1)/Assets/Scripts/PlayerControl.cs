using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 respawnPoint;

    BoxCollider m_collider;

    public float rayDist;

    public int state = 0;

    [SerializeField] Animator m_animator;

    public AudioSource m_ass;

    public AudioClip saatana;
    public AudioClip move;

    public Transform box;
    Rigidbody m_rb;
    bool m_dropping = false;

    private void Start()
    {
        m_collider = GetComponent<BoxCollider>();

        m_rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (!Physics.Raycast(new Ray(transform.position, Vector3.down * 3), 3.0f))
        {
            if (!m_dropping)
            {
                m_ass.clip = saatana;
                m_ass.Play();
            }
            m_dropping = true;
        }
        else
        {
            m_dropping = false;
        }

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

        if (m_rb.velocity.y == 0) Movement();
    }

    void Shift(int dimension)
    {
        for (int i = 0; i < MultiDimesionalObject.s_MDOs.Count; i++)
        {
            if (MultiDimesionalObject.s_MDOs[i].m_shifting)
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
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, new Vector3(0, -1, 1)), out hit, rayDist))
            {

                if (hit.transform.CompareTag("ground"))
                {
                    transform.Translate(new Vector3(0, 0, 1));

                }
            }

            m_ass.clip = move;
            m_ass.Play();
            m_collider.center = new Vector3(0, 0, 1);

            //TODO ei näin
            transform.GetChild(0).rotation = Quaternion.identity;
            transform.GetChild(0).Rotate(0, -90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, new Vector3(0, -1, -1)), out hit, rayDist))
            {
                if (hit.transform.CompareTag("ground"))
                {
                    transform.Translate(new Vector3(0, 0, -1));
                }
            }

            m_ass.clip = move;
            m_ass.Play();
            m_collider.center = new Vector3(0, 0, -1);

            //TODO ei näin
            transform.GetChild(0).rotation = Quaternion.identity;
            transform.GetChild(0).Rotate(0, 90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, new Vector3(-1, -1, 0)), out hit, rayDist))
            {
                if (hit.transform.CompareTag("ground"))
                {
                    transform.Translate(new Vector3(-1, 0, 0));
                }
            }
            m_collider.center = new Vector3(-1, 0, 0);

            m_ass.clip = move;
            m_ass.Play();
            //TODO ei näin
            transform.GetChild(0).rotation = Quaternion.identity;
            transform.GetChild(0).Rotate(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, new Vector3(1, -1, 0)), out hit, rayDist))
            {

                if (hit.transform.CompareTag("ground"))
                {
                    transform.Translate(new Vector3(1, 0, 0));
                }


            }

            m_ass.clip = move;
            m_ass.Play();
            m_collider.center = new Vector3(1, 0, 0);

            //TODO ei näin
            transform.GetChild(0).rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RespawnPoint"))
        {
            respawnPoint = other.transform.position;
        }
        if (other.CompareTag("kill"))
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = respawnPoint + new Vector3(0, 2, 0);
        }
    }
}