using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotester : MonoBehaviour
{
    public GameObject m_tester;
    public AudioSource m_audio;
    public AudioClip m_clip;
    private item item;
    int test = 0;
    public MoveCamera m_cameraholder;
    private int itemroom;
    public int type;
    private bool inroom;
    // Start is called before the first frame update
    void Start()
    {
        //m_audio.Play();
        //set up the object in teh level and allow them to play audio
        if (type == 1)
        {
            m_cameraholder = Camera.main.GetComponent<MoveCamera>();
            item = m_tester.GetComponent<item>();
            itemroom = item.m_item.itemroom;
            inroom = false;
         

        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //when the item is pooped play a sound 
        if (m_tester.tag == "Popped" && test == 0)
        {
            if (m_audio != null)
            {
                //audio isnt working
                if (!m_audio.enabled)
                {
                    Debug.Log("sound should be playing");
                    
                }
                else
                {
                    //play the sound
                    if (m_audio.volume != 0.8f)
                    {
                        m_audio.volume = 0.8f;
                    }
                    m_audio.Play();
                    test++;
                }
            }
            else
            {
                Debug.Log("WHY IS THE AUDIO NULL");
            }
          
           
        }
        //if the item has a behaviour and the item is in the room
        if (item)
        {
            //when not playing the sound
            if (!inroom)
            {
                //if the camera is in the room turn sound on
                if (m_cameraholder.Getpos() == itemroom)
                {
                    inroom = true;                   
                }
            }
            else
            {
                //when the object isn't in the room stop playing the sound
                if (m_cameraholder.Getpos() != itemroom)
                {
                    inroom = false;
                    m_audio.loop = false;
                    m_audio.Stop();
                }
            }
            

            //play the sound on loop when the behaviour is on
            if (item.m_item.m_Behaviour != 0)
            {
                if (inroom)
                {
                    //play the sound on loop
                    if (item.m_item.m_Behaviour == 2)
                    {
                        if (m_audio.volume != 0.1f)
                        {
                            m_audio.volume = 0.1f;
                        }
                        if (!m_audio.loop)
                        {
                            m_audio.loop = true;
                            m_audio.Play();
                        }
                        //Debug.Log("sound is playing");
                    }
                    //the behaviouris off stop tehe sound
                    else
                    {
                        m_audio.loop = false;
                        m_audio.Stop();
                    }
                }
                
            }
        }
        
        
    }

    public void PlaySounds()
    {
        if (m_audio != null)
        {
            m_audio.Play();
            //Debug.Log(m_tester.name);
        }
           
    }
}
