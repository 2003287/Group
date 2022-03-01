using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    // Start is called before the first frame update
    private bool m_testing;
    void Start()
    {
        m_testing = false;
        Debug.Log("remove has spawned in yoo");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Testing()
    {

        Debug.Log("this Remove has been pressed");
        m_testing = true;
    }

    public void testing()
    {
        Debug.Log("this is testing");
    }
}
