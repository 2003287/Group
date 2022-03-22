using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grants : MonoBehaviour
{
    [SerializeField]
    private Text[] descriptions;
    [SerializeField]
    private Text[] levelDescriptions;


    [SerializeField]
    private GameObject grants;
    [SerializeField]
    private GameObject levelSelect;
    [SerializeField]
    private GameObject difficulty;

    [SerializeField]
    private Text grantNameLbl;
    [SerializeField]
    private Text levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GrantOpen(string grantName)
    {
        levelSelect.SetActive(false);
        grants.SetActive(true);

        switch(grantName)
        {
            case "WHS":
                descriptions[0].gameObject.SetActive(true);
                descriptions[1].gameObject.SetActive(true);
                grantNameLbl.text = "Warmer Homes Scotland";
                break;
            case "Heat_Fund":
                descriptions[2].gameObject.SetActive(true);
                descriptions[3].gameObject.SetActive(true);
                grantNameLbl.text = "Social Housing Net Zero Heat Fund";
                break;
            case "Home_Energy":
                descriptions[4].gameObject.SetActive(true);
                descriptions[5].gameObject.SetActive(true);
                grantNameLbl.text = "Home Energy Scotland Loan";
                break;
            default:

                break;
        }
            
    }
    public void DifficultySelect(string diffcultyName)
    {
        levelSelect.SetActive(false);
        difficulty.SetActive(true);

        switch (diffcultyName)
        {
            case "Level1":
                levelDescriptions[0].gameObject.SetActive(true);
                levelName.text = "Studio Flat";
                break;
            case "Level2":
                levelDescriptions[1].gameObject.SetActive(true);
                levelName.text = "Flat";
                break;
            case "Level3":
                levelDescriptions[2].gameObject.SetActive(true);
                levelName.text = "Maisonette";
                break;
            case "Level4":
                levelDescriptions[3].gameObject.SetActive(true);
                levelName.text = "House";
                break;
            default:

                break;
        }

    }
    public void Close(GameObject button)
    {
        button.transform.parent.gameObject.SetActive(false);
        foreach(Text text in descriptions)
        {
            text.gameObject.SetActive(false);
        }

        foreach (Text text in levelDescriptions)
        {
            text.gameObject.SetActive(false);
        }
        levelSelect.SetActive(true);
    }

}
