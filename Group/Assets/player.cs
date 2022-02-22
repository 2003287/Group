using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //positions of objects
    private Vector3[] positions;
    //smaller objects
    private List<GameObject> m_small_loadobject;
    private List<GameObject> m_small_gameobjects;


    //objects


    //testing 
    private bool m_testing;
    private bool m_testing2;
    // Start is called before the first frame update
    void Start()
    {
        //visible cursor dont know if its working
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //the posoitions for object
        positions = new Vector3[4];
        //creatation of the random positions
        for (int i = 0; i < 4; i++)
        {
            positions[i] = new Vector3(i,0,0);
        }
        //loading the small object
        m_small_loadobject = new List<GameObject>(Resources.LoadAll<GameObject>("Targets"));
        m_small_gameobjects = new List<GameObject>();
        //loading the objects
        for (int i = 0; i < 2; i++)
        {
           GameObject g = Instantiate(m_small_loadobject[i],new Vector3(10*i,0,0),Quaternion.identity);
            m_small_gameobjects.Add(g);
        }


        //testing
        m_testing = false;
        m_testing2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //positions of the mouse on the screen from the left mouse button
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition.x);
            Debug.Log(Input.mousePosition.y);
        }

        //reset the positions
        if (Input.GetButtonDown("Fire2"))
        {
            
                
            //clearing all of the object
                Clearobjects();
            //recreate the object on screen
                for (int i = 0; i < 2; i++)
                {
                int test = Random.Range(0, 3);
                GameObject g = Instantiate(m_small_loadobject[i], positions[test], Quaternion.identity);
                m_small_gameobjects.Add(g);
                Debug.Log("happens");
                }

            
        }

        if (m_testing2)
        {
            ObjectCheck();
        }

        m_testing2 = true;
        
    }

    //check if object is destroyed
    private void ObjectCheck()
    {
        foreach (GameObject go in m_small_gameobjects)
        {
            if (m_testing == false)
            {
                if (go == null)
                {
                    Debug.Log("the object was deleted remove from the list please");
                }
                m_small_gameobjects.Remove(go);
                m_testing= true;
            }
           
        }
    }
    //clearing of the object
    void Clearobjects()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject gameobjectremove = m_small_gameobjects[i];
            Destroy(gameobjectremove.gameObject);           
        }

        m_small_gameobjects.Clear();
    }
}


