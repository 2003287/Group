using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotester : MonoBehaviour
{
    public GameObject m_tester;
    public AudioSource m_audio;
    int test = 0;
    // Start is called before the first frame update
    void Start()
    {
        //m_audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_tester.tag == "Popped" && test == 0)
        {
            Debug.Log("sound should be playing");
            m_audio.Play();
            test++;
        }
        
    }
}
