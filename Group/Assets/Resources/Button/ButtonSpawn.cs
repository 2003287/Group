using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameobject;
    private List<GameObject> m_buttons;
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
            go.gameObject.SendMessage("Testing");
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
