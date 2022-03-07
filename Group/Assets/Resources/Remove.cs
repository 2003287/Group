using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameobject;
    
    void Start()
    {
        
        Debug.Log("remove has spawned in yoo");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Testing(GameObject game)
    {
        m_gameobject = game;
        Debug.Log("this Remove has been pressed"+m_gameobject.name);
        RectTransform recttest = this.GetComponent<RectTransform>();
        Vector3 pos = new Vector3(m_gameobject.transform.position.x, m_gameobject.transform.position.y, m_gameobject.transform.position.z);
        Debug.Log(pos);
        
        Debug.Log(pos);
        Debug.Log(recttest.position);
        recttest.position += pos;
        Debug.Log(recttest.position);
    }

    public void testing()
    {
        Debug.Log("this is testing");
        m_gameobject.SendMessage("Delete");
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
