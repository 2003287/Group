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
    private float maxTimer = 30;
    private float minutes;
    private float seconds;
    private float fillAmount;

    // Start is called before the first frame update
    void Start()
    {
        timerImage.fillAmount = maxTimer;
        currentTimer = maxTimer;
        endColour = new Color(1, 0, 0);
        startColour = timerImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer > 0)
        {
            currentTimer = currentTimer - 1 * Time.deltaTime;
            fillAmount = currentTimer / maxTimer;
            timerImage.fillAmount = fillAmount;

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            timerImage.color = Color.Lerp(endColour, startColour, fillAmount);     
        }

        if(currentTimer < 0)
        {
            Debug.Log("HJ");
            timesUp.SetActive(true);
            StartCoroutine(TimesUp());

        }
        minutes = Mathf.FloorToInt(currentTimer / 60);
        seconds = Mathf.FloorToInt(currentTimer % 60);

    }

    IEnumerator TimesUp()
    {
        yield return new WaitForSeconds(1);
        timesUp.SetActive(false);
        currentTimer = 0;
        SceneManager.LoadScene("Score_Screen");

    }
}
