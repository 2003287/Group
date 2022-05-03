using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotester : MonoBehaviour
{
    public GameObject m_tester;
    public AudioSource m_audio;
    public AudioClip m_clip;
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
            if (m_audio != null)
            {
                if (!m_audio.enabled)
                {
                    Debug.Log("sound should be playing");

                }
                else
                {

                    m_audio.Play();
                    test++;
                }
            }
            else
            {
                Debug.Log("WHY THE FUCK IS THE AUDIO NULL");
            }
          
           
        }
        
    }

    public void PlaySounds()
    {
        if (m_audio != null)
        {
            m_audio.Play();
            Debug.Log(m_tester.name);
        }
           
    }
}
