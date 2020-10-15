using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimensionDisplayer : MonoBehaviour
{
    [SerializeField] Image[] m_IMGs;
    [SerializeField] Sprite m_sprSelected;
    [SerializeField] Sprite m_sprUnSelected;

    int m_lastDIM = 1;
    // Update is called once per frame
    private void Start()
    {
        Show(1);
    }

    void FixedUpdate()
    {
        if(m_lastDIM!=MultiDimesionalObject.s_DimensionShift)
        {
            Show(MultiDimesionalObject.s_DimensionShift);
            m_lastDIM = MultiDimesionalObject.s_DimensionShift;
        }
    }

    void Show(int dim)
    {

        for (int i = 0; i < m_IMGs.Length; i++)
        {
            m_IMGs[i].sprite = (dim-1==i) ? m_sprUnSelected : m_sprSelected;
        }
    }

}
