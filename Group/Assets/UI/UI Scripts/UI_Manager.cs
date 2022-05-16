using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;
    [SerializeField]
    private Text energyRatingText;
    [SerializeField]
    private GameObject HUD;

    private Scene currentScene;
    private string currentSceneName;

    public float moneyAmount;
    public float energyRating;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;
        Time.timeScale = 1;
        moneyAmount = SharedScoreVaribles.MoneyVarible;
        energyRating = SharedScoreVaribles.energyRating;
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyText)
        {
            moneyText.text = "£ " + moneyAmount.ToString();
        }
        if (energyRatingText)
        {
            energyRatingText.text = energyRating.ToString() + "/61"; 
        }
        if (moneyAmount != SharedScoreVaribles.MoneyVarible)
        {
            moneyAmount = SharedScoreVaribles.MoneyVarible;
        }

        if (energyRating != SharedScoreVaribles.energyRating)
        {
            energyRating = SharedScoreVaribles.energyRating;
        }
    }
    //open the menu
    public void OpenMenu(GameObject Menu)
    {
        Menu.SetActive(true);
        Time.timeScale = 0;

        if(Menu.name == "Codex_Menu")
        {
            HUD.SetActive(false);
        }
    }
    //close the pause menu
    public void close(GameObject button)
    {
        button.transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
        HUD.SetActive(true);
    }
    //check when the level is paused
    public void LevelPause()
    {
        if (SharedScoreVaribles.Finishedlevel)
        {
            SharedScoreVaribles.Finishedlevel = false;
        }
        else
        {
            SharedScoreVaribles.Finishedlevel = true;
        }
        
    }
    //when a button is pressed go to the correct scene
    public void ButtonPress(string buttonName)
    {
        switch(buttonName)
        {
            case "Home":
                SceneManager.LoadScene("Home");
                break;
            case "Restart":
                SceneManager.LoadScene(currentSceneName);
                break;
            case "EndLevel":
                SceneManager.LoadScene("Score_Screen");
                break;
            default:
                print("No Button Selected");
                break;
        }
    }
}
