using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject[] scoreMenus;
    [SerializeField]
    private GameObject scoreBase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScore(string Button)
    {

        switch(Button)
        {
            case "Money":
                scoreMenus[0].SetActive(true);
                scoreBase.SetActive(false);
            break;
            case "Environment":
                scoreMenus[1].SetActive(true);
                scoreBase.SetActive(false);
                break;
            case "Economic":
                scoreMenus[2].SetActive(true);
                scoreBase.SetActive(false);
                break;
            case "Comfort":
                scoreMenus[3].SetActive(true);
                scoreBase.SetActive(false);
                break;
        }
    }

    public void Back(GameObject button)
    {
        button.transform.parent.gameObject.SetActive(false);
        scoreBase.SetActive(true);
    }

    public void Close()
    {
        SceneManager.LoadScene("Home");
    }
}
