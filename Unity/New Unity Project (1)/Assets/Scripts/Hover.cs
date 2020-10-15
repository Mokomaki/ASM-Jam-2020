using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    float startY;
    public float m_hoverAmount;
    public float m_rotationSpeed;
    public float m_hoverSpeed = 0.5f;

    [HideInInspector] public bool m_hovering = true;


    float minimum;
    float maximum;

    float t = 0.0f;

    private void Start()
    {
        minimum = -m_hoverAmount;
        maximum = m_hoverAmount;

        startY = transform.position.y;
        transform.position = new Vector3(transform.position.x, transform.position.y+Random.Range(minimum, maximum), transform.position.z);

        
    }

    void Update()
    {
        

        if (!m_hovering)
            return;

        transform.Rotate(0, m_rotationSpeed, 0);

        transform.position = new Vector3(transform.position.x,startY + Mathf.Lerp(minimum, maximum, t),transform.position.z);

        t += m_hoverSpeed * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
