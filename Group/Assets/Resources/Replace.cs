using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Testing()
    {
        Debug.Log("this Replace has been pressed");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
