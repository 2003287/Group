using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameobject;
    public void AttachedObject(GameObject game)
    {
        m_gameobject = game;
        Debug.Log("this has been created correctly");
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
