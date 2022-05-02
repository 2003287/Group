using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour, IDragHandler, IEndDragHandler
{
    //variables for the HUD drop down animation
    [SerializeField]
    private GameObject HUD;
    private Animator HUDAnimator;
    private bool HUDopen;

    //variables for the level select animation
    [SerializeField]
    private GameObject levelSelect;
    private Animator levelAnimator;
    private bool levelOpen;

    //variables for the difficulty selection menu
    [SerializeField]
    private GameObject difficultySelect;
    private Animator difficultyAnimator;
    private bool difficultyOpen;
    bool openDifficulty = false;
    [SerializeField]
    private GameObject difficultyBackground;
    [SerializeField]
    private Text levelName; 
    [SerializeField]
    private Image levelPic;
    [SerializeField]
    private Sprite[] levelPics;

    //varibles for opening the coex
    [SerializeField]
    private GameObject codex;
    [SerializeField]
    private GameObject[] hideItems;

    //variables for HUD elemets
    [SerializeField]
    private Text billAmountTxt;
    private float billAmount;
    [SerializeField]
    private Text energyRatingTxt;
    private float energyRating;
    [SerializeField]
    private Text moneyAmountTxt;
    private float moneyAmount;

    //star ratings
    [SerializeField]
    private GameObject[] environmentStars;
    public float environmentValue;
    [SerializeField]
    private GameObject[] energyStars;
    public float energyValue;
    [SerializeField]
    private GameObject[] comfortStars;
    public float comfortValue;

    [SerializeField]
    private GameObject grantsButtons;
    bool openGrants = false;
    [SerializeField]
    private GameObject grantOverlay;
    [SerializeField]
    private Text[] descriptions;
    [SerializeField]
    private Text grantNameLbl;

    //bool to allow the player to drag the option at the top
    private bool dragAllow; 
    void Start()
    {
        HUDAnimator = HUD.GetComponent<Animator>();
        levelAnimator = levelSelect.GetComponent<Animator>();
        difficultyAnimator = difficultySelect.GetComponent<Animator>();
        Time.timeScale = 1;
        if (!SharedScoreVaribles.moneyset)
        {
            SharedScoreVaribles.MoneyVarible = 400.0f;
            SharedScoreVaribles.moneyset = true;

        }
        dragAllow = false;
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountTxt.text = "£ " + SharedScoreVaribles.MoneyVarible.ToString();
        energyRatingTxt.text = energyRating.ToString() + "/61";
        billAmountTxt.text = "£ " + billAmount.ToString();

        EnvironmentStars();
        EconomicStars();

       // print(levelOpen);
    }
    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }

    public void DragAllow()
    {
        Debug.Log("this is to allow the drag to happen");
        if(!dragAllow)
        dragAllow = true;
    }
   
    public void DragExit()
    {
        
        if (dragAllow)
        {
            Debug.Log("this Happens when teh drag ends");
            HUDopen = HUDAnimator.GetBool("Open");
            HUDAnimator.SetBool("Open", !HUDopen);
            dragAllow = false;
        }
    }
    public void PressPlay()
    {
        levelOpen = levelAnimator.GetBool("Open");
        levelAnimator.SetBool("Open", !levelOpen);
    }

    public void Difficulty(string Level)
    {
        difficultyOpen = difficultyAnimator.GetBool("Open");
        difficultyAnimator.SetBool("Open", !difficultyOpen);

        switch (Level)
        {
            case "Level1":
                levelName.text = "Studio Flat";
                levelPic.sprite = levelPics[0];
                break;
            case "Level2":
                levelName.text = "Flat";
                levelPic.sprite = levelPics[1];
                break;
            case "Level3":
                levelName.text = "Maisonette";
                levelPic.sprite = levelPics[2];
                break;
            case "Level4":
                levelName.text = "House";
                levelPic.sprite = levelPics[3];
                break;
            case "Close":
                difficultyBackground.SetActive(false);
                break;
            default:
                print("No Button Selected");
                break;
        }
    }

    public void OpenDifficulty()
    {

        openDifficulty = !openDifficulty;

        if (openDifficulty == true)
        {
            difficultyBackground.SetActive(true);
        }
        else if (openDifficulty == false)
        {
            difficultyBackground.SetActive(false);
        }
    }

    public void ButtonPress(string buttonName)
    {
        switch (buttonName)
        {
            case "Level1":
                SceneManager.LoadScene("ss");
                break;
            case "Level2":
                SceneManager.LoadScene("ss");
                break;
            case "Level3":
                SceneManager.LoadScene("ss");
                break;
            case "Level4":
                SceneManager.LoadScene("ss");
                break;
            default:
                print("No Button Selected");
                break;
        }
    }

    public void OpenCodex()
    {
        codex.SetActive(true);

        foreach(GameObject UI in hideItems)
        {
            UI.SetActive(false);
        }
    }
    public void OpenGrants()
    {

        openGrants = !openGrants;
        
        print(openGrants);
        if (openGrants == true)
        {
            grantsButtons.SetActive(true);
        }
        else if(openGrants == false)
        {
            grantsButtons.SetActive(false);
        }
    }

    //for issue from opening codex or levels while the grants are open
    public void CloseGrants()
    {
        if (grantOverlay.activeSelf)
        {
            grantOverlay.SetActive(false);
            foreach (Text text in descriptions)
            {
                text.gameObject.SetActive(false);
            }
        }
        if (openGrants)
        {
            grantsButtons.SetActive(false);
            openGrants = false;
        }
        Debug.Log("When");
    }

    public void GrantOpen(string grantName)
    {
        grantsButtons.SetActive(false);
        grantOverlay.SetActive(true);
        openGrants = false;
        
        switch (grantName)
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

    public void Close(GameObject button)
    {
        button.transform.parent.gameObject.SetActive(false);
        difficultyBackground.SetActive(false);
        foreach (Text text in descriptions)
        {
            text.gameObject.SetActive(false);
        }

        foreach (GameObject UI in hideItems)
        {
            UI.SetActive(true);
        }

    } 
    private void EnvironmentStars()
    {
        switch(environmentValue)
        {
            case 0:
                environmentStars[0].SetActive(false);
                environmentStars[1].SetActive(false);
                environmentStars[2].SetActive(false);
                environmentStars[3].SetActive(false);
                environmentStars[4].SetActive(false);
                break;
            case 100:
                environmentStars[0].SetActive(true);
                environmentStars[1].SetActive(false);
                environmentStars[2].SetActive(false);
                environmentStars[3].SetActive(false);
                environmentStars[4].SetActive(false);
                break;
            case 200:
                environmentStars[1].SetActive(true);
                environmentStars[2].SetActive(false);
                environmentStars[3].SetActive(false);
                environmentStars[4].SetActive(false);
                break;
            case 300:
                environmentStars[2].SetActive(true);
                environmentStars[3].SetActive(false);
                environmentStars[4].SetActive(false);
                break;
            case 400:
                environmentStars[3].SetActive(true);
                environmentStars[4].SetActive(false);
                break;
            case 500:
                environmentStars[4].SetActive(true);
                break;
            default:
                print("No New Stars");
                break;
        }
    }

    private void EconomicStars()
    {
        switch (energyValue)
        {
            case 0:
                energyStars[0].SetActive(false);
                energyStars[1].SetActive(false);
                energyStars[2].SetActive(false);
                energyStars[3].SetActive(false);
                energyStars[4].SetActive(false);
                break;
            case 100:
                energyStars[0].SetActive(true);
                energyStars[1].SetActive(false);
                energyStars[2].SetActive(false);
                energyStars[3].SetActive(false);
                energyStars[4].SetActive(false);
                break;
            case 200:
                energyStars[1].SetActive(true);
                energyStars[2].SetActive(false);
                energyStars[3].SetActive(false);
                energyStars[4].SetActive(false);
                break;
            case 300:
                energyStars[2].SetActive(true);
                energyStars[3].SetActive(false);
                energyStars[4].SetActive(false);
                break;
            case 400:
                energyStars[3].SetActive(true);
                energyStars[4].SetActive(false);
                break;
            case 500:
                energyStars[4].SetActive(true);
                break;
            default:
                print("No New Stars");
                break;
        }
    }
    public void stars(float newValue)
    {
        environmentValue += newValue;
        energyValue += newValue;
    }    
}
