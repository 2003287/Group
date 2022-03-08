using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorpressed : MonoBehaviour
{
    private float timer;
    // private bool m_change;
    // private bool m_notdown;
    //debug varible
    private bool m_debug_timer;

    private bool m_resettimer;
    public GameObject[] m_gameobject;
    private bool m_ray_hit;
    private string m_hitstring;
    private bool m_reset_colour;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        m_debug_timer = false;
        m_resettimer = false;
        m_ray_hit = false;
        m_reset_colour = false;
    }

    void ChangeColour()
    {
        foreach (GameObject go in m_gameobject)
        {
            if (m_ray_hit)
            {               
                if (timer > 0 && timer < 3.0)
                {
                    if (go.name == m_hitstring)
                        go.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else
                {
                    if (go.name == m_hitstring)
                        go.GetComponent<MeshRenderer>().material.color = Color.blue;
                }
            }
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!m_ray_hit)
            {
                m_resettimer = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction, Color.green, 0.5f);
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    m_hitstring = hit.transform.name;
                    Debug.Log(hit.transform.name);
                    Debug.Log("hit");
                    Debug.Log(Input.mousePosition.x);
                    Debug.Log(Input.mousePosition.y);
                    m_ray_hit = true;
<<<<<<< HEAD

                    

=======
<<<<<<< Updated upstream
                    m_reset_colour = true;
=======
>>>>>>> parent of da97bba (Merge branch 'main' into Liam-Branch)

                    if (hit.collider.CompareTag("Clickable"))
                    {
                        //get the game object and send a message to the gameobject
                        m_gameObject = GameObject.Find(m_hitstring);
                        m_gameObject.transform.SendMessage("Testvoid");
                    }
                    else if (hit.collider.CompareTag("Popped"))
                    {
                        m_gameObject = GameObject.Find(m_hitstring);
                    }

>>>>>>> Stashed changes
                }
                else
                {
                    m_ray_hit = false;
                    Debug.Log("no hit");
                }
            }
           
        }
        
        if (Input.GetButton("Fire1"))
        {
            timer += Time.deltaTime;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (!m_resettimer)
            {
                timer = 0;
                m_resettimer = true;
                m_ray_hit = false;
            }
        }
        if (timer >= 3.0)
        {
            if (!m_debug_timer)
            {
                Debug.Log("timer has passed 3 seconds");
                m_debug_timer = true;
            }
            
            
        }


        //switch colour back to white

        if (timer == 0&& m_reset_colour)
        {
            foreach (GameObject go in m_gameobject)
            {
                if (go.GetComponent<MeshRenderer>().material.color != Color.white)
                {
                    go.GetComponent<MeshRenderer>().material.color = Color.white;
                }
            }
            m_reset_colour = false;
        }

        ChangeColour();
        
    }
}
