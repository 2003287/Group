using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RadialTimer : MonoBehaviour
{
    [SerializeField]
    private Image timerImage;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private GameObject timesUp;
    private Color endColour;
    private Color startColour;
    private float currentTimer;
    public float maxTimer = 120;
    private float minutes;
    private float seconds;
    private float fillAmount;
    private Scoreboard scoreboard;
    private float timer_var;
    [SerializeField]
    private GameObject scoreBase;
    [SerializeField]
    private GameObject[] hideHUD;

    // Start is called before the first frame update
    void Start()
    {
        timerImage.fillAmount = maxTimer;
        currentTimer = maxTimer;
        endColour = new Color(1, 0, 0);
        startColour = timerImage.color;
        SharedScoreVaribles.timerVarible = 1.0f;
       
        timer_var = SharedScoreVaribles.timerVarible;
        scoreboard = GameObject.FindObjectOfType<Scoreboard>();
      //Debug.Log(scoreboard);
    }

    // Update is called once per frame
    void Update()
    {
        //while the leve is still going decrease the value downwards towards 0
        if (currentTimer > 0&& !timesUp.activeSelf)
        {
            currentTimer = currentTimer - timer_var * Time.deltaTime;
            fillAmount = currentTimer / maxTimer;
            timerImage.fillAmount = fillAmount;

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            timerImage.color = Color.Lerp(endColour, startColour, fillAmount);     
        }
        //when the timer is over load the score screen
        if(currentTimer < 0)
        {
            timesUp.SetActive(true);
            StartCoroutine(TimesUp());
        }
        minutes = Mathf.FloorToInt(currentTimer / 60);
        seconds = Mathf.FloorToInt(currentTimer % 60);
        
        if (timer_var != SharedScoreVaribles.timerVarible)
        {
            timer_var = SharedScoreVaribles.timerVarible;
            Debug.Log(timer_var);
        }
        
    }


    public void EndLevel()
    {
        timesUp.SetActive(true);
        
        StartCoroutine(TimesUp());
    }
    //times up spaws the score screen after and displays a times up message
    public IEnumerator TimesUp()
    {
        yield return new WaitForSeconds(1.0f);
        //max time how much time you have 
        //current time is max time - number of seconds
        //max time -  current how 
        float timer = maxTimer- currentTimer;
        SharedScoreVaribles.Finishedlevel = true;
        scoreboard.Scoresetup(timer);
        currentTimer = 0;

        
        scoreBase.SetActive(true);

        foreach( GameObject UI in hideHUD)
        {
            UI.SetActive(false);
        }

    }
}
