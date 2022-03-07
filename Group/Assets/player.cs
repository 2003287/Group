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
<<<<<<< Updated upstream
                }

            
=======
                //activate a void or function to go to activate the score page
            }
        }

       

    }

    //check if object is destroyed
    private void ObjectCheck()
    {
        //small gameobjects
        foreach (GameObject go in m_small_gameobjects)
        {
           if (go == null)
            {
               m_small_gameobjects.Remove(go);       
               break;
             }          
        }
       
        foreach (GameObject go in m_buttons)
        {
            if (go == null)
            {
                m_buttons.Remove(go);
                break;
            }
>>>>>>> Stashed changes
        }
        
    }
    void Clearobjects()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject gameobjectremove = m_testing[i];
            Destroy(gameobjectremove.gameObject);           
        }

<<<<<<< Updated upstream
        m_testing.Clear();
=======
        m_small_gameobjects.Clear();
    }

   public void CreateButtons(GameObject Touchedobject) 
    {
        Debug.Log("this will spawn a button");
        if (m_buttons.Count < 1)
        {
            m_buttons.Add(Instantiate(Resources.Load("Button/Canvas") as GameObject));
            m_buttons[0].GetComponent<ButtonSpawn>().AttachedObject(Touchedobject);
            Debug.Log(Touchedobject);
        }
        else
        { 
          //destroy the button on the screen and do stuff
         
        }
>>>>>>> Stashed changes
    }
}


