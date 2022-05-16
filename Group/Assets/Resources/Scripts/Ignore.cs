using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameObject;
   
    public Vector3 movepos = new Vector3(3.0f,0.0f,0.0f);
    void Start()
    {
        
    }
    public void Testing(GameObject game)
    {
        m_gameObject = game;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //move the object off screen
    public void Move()
    {
        this.transform.position = new Vector3(-500,60,60);
    }

    //delete this object
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
