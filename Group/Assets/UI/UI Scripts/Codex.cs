using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codex : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bookPages;
    [SerializeField]
    private GameObject[] tabs;
    [SerializeField]
    private GameObject[] tabsPos;

    private int currentPage = 0;

    [SerializeField]
    private GameObject[] helpPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPage == 0)
        {
            tabs[0].transform.position = tabsPos[0].transform.position;
            tabs[1].transform.position = tabsPos[2].transform.position;
            tabs[2].transform.position = tabsPos[5].transform.position;
            tabs[3].transform.position = tabsPos[8].transform.position;
            tabs[4].transform.position = tabsPos[11].transform.position;
        }

        if (currentPage >= 1 && currentPage < 4)
        {
            tabs[0].transform.position = tabsPos[1].transform.position;
            tabs[1].transform.position = tabsPos[3].transform.position;
            tabs[2].transform.position = tabsPos[6].transform.position;
            tabs[3].transform.position = tabsPos[9].transform.position;
            tabs[4].transform.position = tabsPos[12].transform.position;
        }

        if (currentPage >= 4 && currentPage < 7)
        {
            tabs[0].transform.position = tabsPos[1].transform.position;
            tabs[1].transform.position = tabsPos[4].transform.position;
            tabs[2].transform.position = tabsPos[6].transform.position;
            tabs[3].transform.position = tabsPos[9].transform.position;
            tabs[4].transform.position = tabsPos[12].transform.position;
        }

        if (currentPage >= 7 && currentPage < 10)
        {
            tabs[0].transform.position = tabsPos[1].transform.position;
            tabs[1].transform.position = tabsPos[4].transform.position;
            tabs[2].transform.position = tabsPos[7].transform.position;
            tabs[3].transform.position = tabsPos[9].transform.position;
            tabs[4].transform.position = tabsPos[12].transform.position;
        }

        if (currentPage == 10)
        {
            tabs[0].transform.position = tabsPos[1].transform.position;
            tabs[1].transform.position = tabsPos[4].transform.position;
            tabs[2].transform.position = tabsPos[7].transform.position;
            tabs[3].transform.position = tabsPos[10].transform.position;
            tabs[4].transform.position = tabsPos[12].transform.position;
        }

        if (currentPage >= 11)
        {
            tabs[0].transform.position = tabsPos[1].transform.position;
            tabs[1].transform.position = tabsPos[4].transform.position;
            tabs[2].transform.position = tabsPos[7].transform.position;
            tabs[3].transform.position = tabsPos[10].transform.position;
            tabs[4].transform.position = tabsPos[13].transform.position;
        }
    }

    public void openCodex(string name)
    {
        switch(name)
        {
            case "Popped":
                bookPages[currentPage].SetActive(false);
                currentPage = 1;
                bookPages[currentPage].SetActive(true);
                break;
            case "Upgrades":
                bookPages[currentPage].SetActive(false);
                currentPage = 4;
                bookPages[currentPage].SetActive(true);
                break;
            case "Glossary":
                bookPages[currentPage].SetActive(false);
                currentPage = 9;
                bookPages[currentPage].SetActive(true);
                break;
            case "Help":
                bookPages[currentPage].SetActive(false);
                currentPage = 10;
                bookPages[currentPage].SetActive(true);
                break;
            case "Settings":
                bookPages[currentPage].SetActive(false);
                currentPage = 11;
                bookPages[currentPage].SetActive(true);
                break;
            default:
                print("No Button Selected");
                break;
        }
    }
    public void NextPage(int pageNum)
    {
        bookPages[currentPage].SetActive(false);
        currentPage += pageNum;
        bookPages[currentPage].SetActive(true);
    }
    
    public void HelpButton(string button)
    {
        switch (button)
        {
            case "Controls":
                helpPage[0].SetActive(true);
                helpPage[1].SetActive(false);
            break;
            case "Help":
                helpPage[0].SetActive(false);
                helpPage[1].SetActive(true);
                break;
        }

    }
}
