using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    float startY;
    public float m_hoverAmount;
    public float m_rotationSpeed;

    float minimum;
    float maximum;

    float t = 0.0f;

    private void Start()
    {
        minimum = -m_hoverAmount;
        maximum = m_hoverAmount;

        startY = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(0, m_rotationSpeed, 0);

        transform.position = new Vector3(transform.position.x,startY + Mathf.Lerp(minimum, maximum, t),transform.position.z);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
