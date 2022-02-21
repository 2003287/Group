using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector3[] positions;
    public List<GameObject> m_gameobject;
    private List<GameObject> m_testing;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        positions = new Vector3[4];

        for (int i = 0; i < 4; i++)
        {
            positions[i] = new Vector3(i,0,0);
        }
        m_gameobject = new List<GameObject>(Resources.LoadAll<GameObject>("Targets"));
        m_testing = new List<GameObject>();

        for (int i = 0; i < 2; i++)
        {
           GameObject g = Instantiate(m_gameobject[i],new Vector3(10*i,0,0),Quaternion.identity);
            m_testing.Add(g);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition.x);
            Debug.Log(Input.mousePosition.y);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            
                

                Clearobjects();
                for (int i = 0; i < 2; i++)
                {
                int test = Random.Range(0, 3);
                GameObject g = Instantiate(m_gameobject[i], positions[test], Quaternion.identity);
                m_testing.Add(g);
                Debug.Log("happens");
                }

            
        }
        
    }
    void Clearobjects()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject gameobjectremove = m_testing[i];
            Destroy(gameobjectremove.gameObject);           
        }

        m_testing.Clear();
    }
}


