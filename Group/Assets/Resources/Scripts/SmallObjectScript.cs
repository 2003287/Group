using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallObjectScript : MonoBehaviour
{
    //test varibles
    private bool m_testing;
    private int m_counting;
    private bool m_finished;
    //timer
    private float m_timer_varible;
    private float m_Colour_back;

    //enum for clicked
    enum PoppingState {Notpopped,Popped };
    private PoppingState m_popState;
    // Start is called before the first frame update
    void Start()
    {
        //settign up the test varibles
        m_testing = false;
        m_counting = 0;
        m_timer_varible = 0;
        m_finished = false;
        m_Colour_back = 0;
        gameObject.tag = "Clickable";
        m_popState = PoppingState.Notpopped;
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
       
        else if (m_timer_varible >= 3.0)
        {           
            Destroy(this.gameObject);
        }
      
       
        //print(gameObject.activeSelf?"Active":"Inactive");
    }
     void Testvoid()
    {
        if (m_popState != PoppingState.Popped)
        {
            m_popState = PoppingState.Popped;
            this.GetComponent<MeshRenderer>().material.color = Color.gray;
            gameObject.tag = "Popped";
        }
        if (!m_testing)
        {
            m_testing = true;
        }
    }
    void ColourBack()
    {
        if (m_finished)
        {
            m_Colour_back += Time.deltaTime;
           
           // Debug.Log("testing");
        }

    }
    void TimerSetting(float time)
    {
        m_timer_varible = time;
        m_finished = true;
    }

}
