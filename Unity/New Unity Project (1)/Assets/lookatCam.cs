using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatCam : MonoBehaviour
{
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(t);
        transform.Rotate(0, 180, 0);
    }
}
