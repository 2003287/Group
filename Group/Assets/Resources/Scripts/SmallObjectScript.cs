using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallObjectScript : MonoBehaviour
{
    //test varibles
    private bool m_testing;
    private int m_counting;
    //timer
    private float m_timer_varible;

    // Start is called before the first frame update
    void Start()
    {
        //settign up the test varibles
        m_testing = false;
        m_counting = 0;
        m_timer_varible = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //once a hit happens
        if (m_testing && m_counting == 0)
        {
            Debug.Log("this happen");
            m_counting++;
        }
        if (m_testing && m_timer_varible < 3.0)
        {
            if(this.GetComponent<MeshRenderer>().material.color != Color.red)
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (m_timer_varible >= 3.0)
        {
            if (this.GetComponent<MeshRenderer>().material.color != Color.blue)
                this.GetComponent<MeshRenderer>().material.color = Color.blue;
            Destroy(this.gameObject);
        }
        else
        {
            if (this.GetComponent<MeshRenderer>().material.color != Color.white)
            {
                this.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }

    }
     void Testvoid()
    {
        if (!m_testing)
        {
            m_testing = true;
        }
    }
    void TimerSetting(float time)
    {
        m_timer_varible = time;
    }

}
