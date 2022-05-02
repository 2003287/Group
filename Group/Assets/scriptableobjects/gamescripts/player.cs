using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour
{
      //positions of objects
    private Vector3[] positions;

    public InventoryoObject m_inventoryoObject;
    //smaller objects
    private List<GameObject> m_small_loadobject;
    private List<GameObject> m_small_gameobjects;
    private List<GameObject> m_buttons;
   // private float m_GameTimer;
   // private bool m_levelOver;
    //objects
    private GameObject testing;

    //testing 
    // private bool m_testing;
   // private bool m_testing2;
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


        


        //testing
        // m_testing = false;
        //m_testing2 = false;

        //timer
        //m_GameTimer = 0.0f;
       // m_levelOver = false;
        m_inventoryoObject.Setup();
       
    }

    // Update is called once per frame
    void Update()
    {
       



        ObjectCheck();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
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
              //  Debug.Log("the button has a null refference");
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
       // Debug.Log("this will spawn a button");
      //  Debug.Log(Touchedobject);
        if (Touchedobject)
        {
            if (m_buttons.Count == 0)
            {
                var item = Touchedobject.GetComponent<item>();
                if (item)
                {
                    m_inventoryoObject.Itemcheck(item.m_item);
                    //m_inventoryoObject.addItem(item.m_item, 1);
                }
                m_buttons.Add(Instantiate(Resources.Load("Button/Canvas") as GameObject));
                m_buttons[0].GetComponent<ButtonSpawn>().AttachedObject(Touchedobject);
                Debug.Log(Touchedobject);

            }
            else
            {
                m_buttons[0].GetComponent<ButtonSpawn>().Deletion();
                m_buttons.Clear();

              //  Debug.Log("removal of buttons onscreen" + Touchedobject);
            }
        }
    }
    private void OnApplicationQuit()
    {
        m_inventoryoObject.m_container.Clear();
    }
}