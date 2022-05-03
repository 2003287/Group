using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codex1 : MonoBehaviour
{

    [SerializeField]
    private GameObject[] hideElements;
    [SerializeField]
    private GameObject[] showElements;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {

        foreach(GameObject UI in hideElements)
        {
            UI.SetActive(false);
        }

        foreach(GameObject UI2 in showElements)
        {
            UI2.SetActive(true);
        }
    }

    public void Back()
    {

        foreach (GameObject UI in hideElements)
        {
            UI.SetActive(true);
        }

        foreach (GameObject UI2 in showElements)
        {
            UI2.SetActive(false);
        }
    }
}
