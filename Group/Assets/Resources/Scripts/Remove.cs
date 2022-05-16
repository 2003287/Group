using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameobject;
    public Vector3 movepos = new Vector3(0.0f, 0.0f, 0.0f);
    void Start()
    {
        
       // Debug.Log("remove has spawned in yoo");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //setup game object
    public void Testing(GameObject game)
    {
        m_gameobject = game;     
    }

    //tells the gameobect to delete its self and remove the object in scoreboard
    public void testing()
    {
        Debug.Log("this is testing");
        m_gameobject.SendMessage("Delete");
        var test = GameObject.FindObjectOfType<Scoreboard>();
        test.RemovalofObjects(m_gameobject);
    }
    //move the button off screen
    public void Move()
    {
        this.transform.position = new Vector3(-500, 60, 60);
    }
    void Delete()
    {
        Destroy(this.gameObject);
    }
}
