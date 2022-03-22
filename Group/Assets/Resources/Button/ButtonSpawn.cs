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
    public void AttachedObject(GameObject game)
    {
        m_gameobject = game;
        Debug.Log("this has been created correctly");
        m_buttons = new List<GameObject>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("button"))
        {
            m_buttons.Add(go);
            Debug.Log(go.name+" button has spawned in the game");
        }
        foreach (GameObject go in m_buttons)
        {
            
            go.gameObject.SendMessage("Testing",game);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (m_gameobject == null)
        {
            Debug.Log("the object is null now to remove");
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
    }

    public void tester()
    {
        m_gameobject = null;
        Debug.Log("the ignore button has been pressed");
    }

    public void Createbuttons()
    {
        Movebuttons();
        var item = m_gameobject.GetComponent<item>();
        if (item)
        {
            for (int i = 0; i < m_inventoryoObject.m_container.Count; i++)
            {
                if (item.m_item.m_roomtype == m_inventoryoObject.m_container[i].m_item.m_roomtype)
                {
                    if (item.m_item.m_objectType == m_inventoryoObject.m_container[i].m_item.m_objectType)
                    {
                        DefaultControls.Resources uires = new DefaultControls.Resources();
                        GameObject button = DefaultControls.CreateButton(uires);
                        button.transform.SetParent(this.GetComponent<Canvas>().transform, false);
                        button.transform.position = new Vector3(positions.x + (i * 40), positions.y, positions.z);
                        button.GetComponentInChildren<Text>().text = m_inventoryoObject.m_container[i].m_item.gameObject.ToString();
                        button.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);

                        //button.GetComponent<Image>().sprite = item.m_item.m_sprite;
                        var btn = button.GetComponent<Button>();
                        var touched = m_inventoryoObject.m_container[i].m_item;
                        UnityEngine.Events.UnityAction action = () => { Testingbutton(touched); };
                        btn.onClick.AddListener(action);
                    }
                   
                }
            }

            
           
        }

       
    }
    public void Testingbutton(ItemObject item)
    {
        Debug.Log("the button created was pressed"+item);
        //   m_inventoryoObject.SpawnObject(item);
        Instantiate(item.gameObject,m_gameobject.transform.position,Quaternion.identity);
        m_gameobject.SendMessage("Delete");
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
        Debug.Log("the ignore button has been pressed");
        foreach (GameObject go in m_buttons)
        {
            go.SendMessage("Delete");
            m_buttons.Remove(go);
            break;
        }

        Destroy(this.gameObject);
    }
}
