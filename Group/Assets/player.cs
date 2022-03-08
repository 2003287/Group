using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class player : MonoBehaviour
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
                GameObject g = Instantiate(m_small_loadobject[i], positions[test], Quaternion.identity);
                m_small_gameobjects.Add(g);
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

<<<<<<< HEAD

       

=======
<<<<<<< Updated upstream
        m_testing.Clear();
=======
>>>>>>> parent of da97bba (Merge branch 'main' into Liam-Branch)
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
<<<<<<< HEAD

    }
        

    
=======
>>>>>>> Stashed changes
    }
>>>>>>> parent of da97bba (Merge branch 'main' into Liam-Branch)
}*/


public class player : MonoBehaviour
{
      //positions of objects
    private Vector3[] positions;
    
    //smaller objects
    private List<GameObject> m_small_loadobject;
    private List<GameObject> m_small_gameobjects;
    private List<GameObject> m_buttons;
    private float m_GameTimer;
    private bool m_levelOver;
    //objects
    private GameObject testing;

    //testing 
    // private bool m_testing;
    private bool m_testing2;
    // Start is called before the first frame update
    void Start()
    {
        //visible cursor dont know if its working
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        positions = new Vector3[4];
        //creatation of the random positions
        for (int i = 0; i < 4; i++)
        {
            positions[i] = new Vector3(i, 0, 0);
        }
        //loading the small object

        m_small_loadobject = new List<GameObject>(Resources.LoadAll<GameObject>("Targets"));

        m_small_gameobjects = new List<GameObject>();

        //loading the list of buttons
        m_buttons = new List<GameObject>();


        //loading the objects

        for (int i = 0; i < 2; i++)
        {
            GameObject g = Instantiate(m_small_loadobject[i], new Vector3(10 * i, 0, 0), Quaternion.identity);
            m_small_gameobjects.Add(g);
        }

        //testing
        // m_testing = false;
        m_testing2 = false;

        //timer
        m_GameTimer = 0.0f;
        m_levelOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_levelOver)
        {

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
        }



        ObjectCheck();

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
                Debug.Log("the button has a null refference");
                break;
            }

        }

    }
    void Clearobjects()
    {
        for (int i = 0; i < m_small_gameobjects.Count; i++)
        {
            GameObject gameobjectremove = m_small_gameobjects[i];
            Destroy(gameobjectremove.gameObject);
        }     

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
           
        }


    }

}