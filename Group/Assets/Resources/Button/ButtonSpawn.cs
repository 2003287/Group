using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameobject;
    private List<GameObject> m_buttons;
    public Vector3 positions = new Vector3(0.0f,0.0f,0.0f);
    public InventoryoObject m_inventoryoObject;
    private Scoreboard score;
    public Image Back;
    public Sprite behaviourimage;

    public void AttachedObject(GameObject game)
    {
        m_gameobject = game;
       // Debug.Log("this has been created correctly");
        m_buttons = new List<GameObject>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("button"))
        {
            m_buttons.Add(go);
           // Debug.Log(go.name+" button has spawned in the game");
        }
        foreach (GameObject go in m_buttons)
        {
            
            go.gameObject.SendMessage("Testing",game);
        }

        score = GameObject.FindObjectOfType<Scoreboard>();
    }
    // Update is called once per frame
    void Update()
    {
        if (m_gameobject == null)
        {
           // Debug.Log("the object is null now to remove");
            foreach (GameObject go in m_buttons)
            {
                if (go)
                {
                    go.SendMessage("Delete");
                    Debug.Log(go);
                }
                m_buttons.Remove(go);
                break;
            }

            Destroy(this.gameObject);
        }
        if (SharedScoreVaribles.Finishedlevel)
        {
            Deletion();
        }
    }

    public void tester()
    {
        m_gameobject = null;
      //  Debug.Log("the ignore button has been pressed");
    }

    public void Createbuttons()
    {
        Movebuttons();
        var item = m_gameobject.GetComponent<item>();
        int posint = 0;
        if (Input.touchCount > 0 || Input.GetMouseButtonUp(0))
        { 
        
        }
            if (item)
        {
            for (int i = 0; i < m_inventoryoObject.m_container.Count; i++)
            {
                if (item.m_item.m_roomtype == m_inventoryoObject.m_container[i].m_item.m_roomtype)
                {
                    if (item.m_item.m_objectType == m_inventoryoObject.m_container[i].m_item.m_objectType)
                    {

                        if (SharedScoreVaribles.MoneyVarible > m_inventoryoObject.m_container[i].m_item.m_cost)
                        {
                            DefaultControls.Resources uires = new DefaultControls.Resources();
                            //name and cost
                           GameObject image = DefaultControls.CreateText(uires);
                            image.transform.SetParent(Back.transform, true);
                            image.transform.position = new Vector3(100 + (posint * 100), 10, image.transform.position.z);
                           // image.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                            image.GetComponentInChildren<Text>().text = "Cost " + m_inventoryoObject.m_container[i].m_item.m_cost.ToString();
                            //button
                            uires.standard = m_inventoryoObject.m_container[i].m_item.m_sprite;
                            GameObject button = DefaultControls.CreateButton(uires);
                            button.transform.SetParent(Back.transform, true);
                            // button.transform.position = new Vector3(50 + (posint * 100), 50, button.transform.position.z);
                            if (posint == 0)
                            {
                                button.transform.position = new Vector3(Back.transform.position.x -150 , 50, Back.transform.position.z);
                                image.transform.position = new Vector3(Back.transform.position.x - 100, 10, image.transform.position.z);
                            }
                            else if (posint == 1)
                            {
                                button.transform.position = new Vector3(Back.transform.position.x  , 50, Back.transform.position.z);
                                image.transform.position = new Vector3(Back.transform.position.x +50, 10, image.transform.position.z);
                            }
                            else
                            {
                                button.transform.position = new Vector3(Back.transform.position.x + 150 , 50, Back.transform.position.z);
                                image.transform.position = new Vector3(Back.transform.position.x + 200, 10, image.transform.position.z);
                            }

                           
                            button.GetComponentInChildren<Text>().text = "";
                            button.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
                           // button.GetComponentInChildren<Text>().text = "Cost: " + m_inventoryoObject.m_container[i].m_item.m_cost.ToString();
                            //button.GetComponent<Image>().sprite = item.m_item.m_sprite;
                            var btn = button.GetComponent<Button>();
                            var touched = m_inventoryoObject.m_container[i].m_item;
                            UnityEngine.Events.UnityAction action = () => { Testingbutton(touched); };
                            btn.onClick.AddListener(action);                           


                            

                            posint++;
                        }
                       
                    }
                   
                }
            }

            
           
        }       
    }


    public void CreateBehaviourButtons()
    {
        //hides currentbuttons
        Movebuttons();
        var item = m_gameobject.GetComponent<item>();
        Debug.Log("whelp happems");
        if (Input.touchCount > 0|| Input.GetMouseButtonUp(0))
        {
            if (item)
            {
                if (item.m_item.m_Behaviour != 0)
                {
                    Debug.Log("the behaviour is hear");
                    DefaultControls.Resources uires = new DefaultControls.Resources();
                    uires.standard = behaviourimage;
                    GameObject button = DefaultControls.CreateButton(uires);
                    button.transform.SetParent(this.GetComponent<Canvas>().transform, true);
                    button.transform.position = new Vector3(Back.transform.position.x - 100, 40, Back.transform.position.z);

                    if (behaviourimage)
                    {
                        Debug.Log("image should apper");
                    }
                    Debug.Log("image is wrong");
                    button.GetComponentInChildren<Text>().text = "OFF";
                    button.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 50);
                    var testing = 1;
                    var btn = button.GetComponent<Button>();
                    UnityEngine.Events.UnityAction action = () => { NewBehaviour(testing); };
                    btn.onClick.AddListener(action);

                    GameObject button2 = DefaultControls.CreateButton(uires);
                    button2.transform.SetParent(this.GetComponent<Canvas>().transform, true);
                    button2.transform.position = new Vector3(Back.transform.position.x + 100, 40, Back.transform.position.z);
                    button2.GetComponentInChildren<Text>().text = "ON";

                    button2.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 50);
                    var testing2 = 2;
                    var btn2 = button2.GetComponent<Button>();
                    UnityEngine.Events.UnityAction action2 = () => { NewBehaviour(testing2); };
                    btn2.onClick.AddListener(action2);


                }
                else
                {
                    Debug.Log("there is no behaviour on the object");
                    Deletion();
                }

            }
        }
       

    }


    public void NewBehaviour(int newbehav)
    {
        if ( Input.touchCount > 0 ||  Input.GetMouseButtonUp(0))
        {           
           
            Debug.Log(newbehav);
            m_gameobject.GetComponent<item>().m_item.m_Behaviour = newbehav;

            Debug.Log(m_gameobject.GetComponent<item>().m_item.m_Behaviour);
            //scoreboard changing the behaviour
            score.BehaviourChange(m_gameobject);
            Deletion();
        }
       

    }

    public void Testingbutton(ItemObject item)
    {
        //Debug.Log("the button created was pressed"+item);
        //   m_inventoryoObject.SpawnObject(item);
        if (Input.touchCount > 0 || Input.GetMouseButtonUp(0))
        {
            var testgame = Instantiate(item.gameObject, m_gameobject.transform.position, Quaternion.identity);
            SharedScoreVaribles.MoneyVarible -= item.m_cost;
            if (m_gameobject.GetComponent<item>().m_item.m_Behaviour != 0)
            {
                testgame.GetComponent<item>().m_item.m_Behaviour = m_gameobject.GetComponent<item>().m_item.m_Behaviour;
                Debug.Log(testgame.GetComponent<item>().m_item.m_Behaviour);
            }

            score.NewInstance(m_gameobject, testgame);

            m_gameobject.SendMessage("Delete");
        }
        

    }
    void Movebuttons()
    {
        foreach (GameObject go in m_buttons)
        {
            go.SendMessage("Move");
           // break;
        }
    }
    public void Deletion()
    {
        //Debug.Log("the ignore button has been pressed");
        foreach (GameObject go in m_buttons)
        {
            go.SendMessage("Delete");
            m_buttons.Remove(go);
            break;
        }

        Destroy(this.gameObject);
    }
}
