using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SharedScoreVaribles
{
    public static float sharedFloat;
    public static float MoneyVarible;
    public static bool moneyset;
    public static float energyRating;
    public static float energyBand;
    public static float timerVarible;
    //have bools for grants and other items
    public static bool Finishedlevel;


    public static bool playerSetup;

    //setting up the varibles
    public static void Settingup()
    {
        MoneyVarible = 500.0f;
       // timerVarible = 1.0f;
        moneyset = true;
    }
}

public class Scoreboard : MonoBehaviour
{
    // Start is called before the first frame update
    private int scoretest = 0;
    private bool checkonce = false;
    private float scorecounter;

    //list of game objects for use
    private List<GameObject> objectsinScene;
    private int selectedobject;
    private Dictionary<GameObject, bool> m_dictionary;
    private List<GameObject> SwappedGameobjects;
    private List<GameObject> itemsBehaviour;
    //public texts for display
    public Text Score_text;
    public Text Money_text;
    public Text Money_earned_text;
    public Text scorescreen_time;
    public Text scorescreen_earnt;
    public Text scorescreen_rating;
    public Text scorescreen_score;

    //internal varibles
    private bool text_change;
    private float timerfloat;
    private float moneyEarnt;
    private float energyratingcalculater;
    public Button Endbutton;
    void Start()
    {
        //loading of the list and dictionary
        objectsinScene = new List<GameObject>();
        SwappedGameobjects = new List<GameObject>();
        m_dictionary = new Dictionary<GameObject, bool>();
        itemsBehaviour = new List<GameObject>();

        //shared varibles setup
        SharedScoreVaribles.sharedFloat = 0.0f;
        scorecounter = SharedScoreVaribles.sharedFloat;
        selectedobject = 0;
        
        //score stuff
        Score_text.text = scorecounter.ToString();
       
        text_change = false;
        energyratingcalculater = 0.0f;
       // SharedScoreVaribles.Settingup();
        if (!SharedScoreVaribles.moneyset)
        {
            SharedScoreVaribles.MoneyVarible = 400.0f;
            SharedScoreVaribles.moneyset = true;

        }
        if (SharedScoreVaribles.MoneyVarible < 150)
        {
            SharedScoreVaribles.MoneyVarible = 150.0f;
        }
        Money_text.text = SharedScoreVaribles.MoneyVarible.ToString();
        timerfloat =1.0f;
        moneyEarnt = 0.0f;
        Endbutton.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!checkonce)
        {
            //setup the items in the score screen
            testingvoid();
           // Debug.Log(scorecounter);
            checkonce = true;
        }
        if (text_change)
        {
            GetScore();
            Debug.Log(SharedScoreVaribles.sharedFloat);          
        }
        if (energyratingcalculater >= 61)
        {
            Endbutton.gameObject.SetActive(true);
        }

    }
    void testingvoid()
    {
        //find all the popable objects
        var listofgame = GameObject.FindGameObjectsWithTag("Clickable");
        //loop through them
        for (int i = 0; i < listofgame.Length; i++)
        {
            //check the number of objects
            scoretest++;
           // Debug.Log(listofgame[i].name);
            objectsinScene.Add(listofgame[i]);
            //check the behaviours of the objects
            if (listofgame[i].GetComponent<item>().m_item.m_Behaviour == 0)
            {
                Debug.Log("the dehaviour of the " + listofgame[i].name + "null");
            }
            else
            {
                Debug.Log("the dehaviour of the " + listofgame[i].name + "is active turn off the object");
                //randomally select the behaviour of the object
                listofgame[i].GetComponent<item>().m_item.m_Behaviour = Random.Range(1, 3);
                Debug.Log(listofgame[i].GetComponent<item>().m_item.m_Behaviour);
            }
           
           
               // energyratingcalculater += testing.m_item.m_energyRating;
        }
        //350/500
       // energyratingcalculater = energyratingcalculater / objectsinScene.Count;
        //Debug.Log(scoretest);
        //etup the objects that need to be found
        for (int i = 0; i <= 4; i++)
        {
            SetupObjects(i);
        }
        energyratingcalculater = energyratingcalculater / 5;
        GetScore();

    }

   private int Randomint()
    { 
      int i = Random.Range(0, objectsinScene.Count);
        return i;
    }
    private void SetupObjects(int i)
    {
        if (i >= 1)
        {
            selectedobject = Randomint();
            if (!m_dictionary.ContainsKey(objectsinScene[selectedobject]))
            {
                
                m_dictionary.Add(objectsinScene[selectedobject], false);
              //  Debug.Log(selectedobject);
              //  Debug.Log(energyratingcalculater);
                var testing = objectsinScene[selectedobject].GetComponent<item>();
                energyratingcalculater += testing.m_item.m_energyRating;
                objectsinScene[selectedobject].GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            else
            {
                SetupObjects(i);
            }
           
        }
        else
        {
            selectedobject = Randomint();
            m_dictionary.Add(objectsinScene[selectedobject], false);
           // Debug.Log(selectedobject);
           // Debug.Log(energyratingcalculater);
            var testing = objectsinScene[selectedobject].GetComponent<item>();
            energyratingcalculater += testing.m_item.m_energyRating;
            objectsinScene[selectedobject].GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

    //need to talk about the scoreing method i.e t0/(t0+t)  score/time  score/intialvalue/time so on and so on
    //same with energy rating calculations  effency = energyout/ energyin  get the mean of objects in the scene so on and so on
    public void GameObjectPopped(GameObject game)
    {
        
        for (int i = 0; i < objectsinScene.Count; i++)
        {
            if (game.name == objectsinScene[i].name)
            {
                //  Debug.Log("the object is" + objectsinScene[i].name+"index is"+i);
                Debug.Log(game.name);
                    if (m_dictionary.ContainsKey(game))
                    {
                        //Debug.Log("this is testing the dictionary value");
                        m_dictionary[game] = true;
                        scorecounter += 200.0f;
                    timerfloat -= 0.1f;
                    Debug.Log(timerfloat);
                    var item = game.GetComponent<item>();
                    moneyEarnt += item.m_item.m_cost;
                    Debug.Log("HURRAY" + game);
                    Debug.Log("THIS IS AS INTENDED");
                }
                    else
                    {
                        if (scorecounter > 50)
                        {
                            scorecounter -= 50.0f;

                        
                    }
                    var item = game.GetComponent<item>();
                    Debug.Log("Work damit as INTENDED");
                    moneyEarnt -= item.m_item.m_cost/2.0f;
                    timerfloat += 0.1f;
                    Debug.Log(timerfloat);
                }

               // Debug.Log(SharedScoreVaribles.timerVarible);
                text_change = true;
            }
        }

    }

    public void RemovalofObjects(GameObject game)
    {
        if (objectsinScene.Contains(game))
        {
            objectsinScene.Remove(game);
        }
        Debug.Log(objectsinScene.Count);
    }
    float Energycreater(GameObject game, GameObject item)
    {
        float testing = energyratingcalculater*5;
        Debug.Log("THE NEW ENERGY RATING" + testing.ToString());
        testing -= game.GetComponent<item>().m_item.m_energyRating;
        testing += item.GetComponent<item>().m_item.m_energyRating;

        testing = testing / 5;

        Debug.Log("THE NEW ENERGY RATING"+ testing.ToString());
        return testing;
    }

    public void Scoresetup(float timer)
    {
       // Debug.Log("testing this is running");
        //  scorescreen_score.text = scorecounter.ToString();
        scorescreen_time.text = timer.ToString() + " s";
        scorescreen_earnt.text = moneyEarnt.ToString();
        Scorecalc(timer);
        scorescreen_score.text = moneyEarnt.ToString();
        if (moneyEarnt > 0)
        {
            SharedScoreVaribles.MoneyVarible += moneyEarnt;
        }
      
    }
    public void GetScore()
    {
        Score_text.text = scorecounter.ToString();
        Money_text.text = SharedScoreVaribles.MoneyVarible.ToString();
        Money_earned_text.text = moneyEarnt.ToString();
        SharedScoreVaribles.sharedFloat = scorecounter;
        SharedScoreVaribles.timerVarible = timerfloat;
        SharedScoreVaribles.energyRating = energyratingcalculater;
      //  Debug.Log(timerfloat);
       // Debug.Log(SharedScoreVaribles.timerVarible);
       text_change = false;
    }
    public void NewInstance(GameObject game, GameObject item)
    {
       Debug.Log("THE SWAPPING HAS ACCURED");
        Debug.Log(game);
        if (objectsinScene.Contains(game))
        {
           // int pos = objectsinScene.IndexOf(game);

            if (m_dictionary.ContainsKey(game))
            {
              //  Debug.Log("THIS WAS TESTED OUT TO WORK");
                energyratingcalculater =Energycreater(game,item);
                SwappedGameobjects.Add(item);
            }

            if (SwappedGameobjects.Contains(game))
            {
                energyratingcalculater = Energycreater(game, item);

                SwappedGameobjects.Add(item);
                SwappedGameobjects.Remove(game);
            }
            objectsinScene.Remove(game);
           // Debug.Log("was removed from the list new size "+ objectsinScene.Count);
        }
        
        objectsinScene.Add(item.gameObject);
        GetScore();
        Debug.Log(item.gameObject);
      //  Debug.Log("was removed from the list new size " + objectsinScene.Count);
      //  Debug.Log("Unpressed");
    }

    public void Scorecalc(float timer)
    {
        float scoreamount = 0.0f;
        foreach (bool found in m_dictionary.Values)
        {
            Debug.Log(found);
            if (found)
            {
                scoreamount += 0.2f;
            }
           
        }
        Debug.Log(scoreamount);
        //money earned + time duration / timer modififyer
        if (timerfloat <= 90)
        {            
            moneyEarnt = (moneyEarnt + timer) / timerfloat;
        }
        else
        {
            moneyEarnt = (moneyEarnt) / timerfloat;
        }
        Debug.Log(moneyEarnt);

        if (energyratingcalculater >= 61)
        {
            moneyEarnt *= scoreamount;
        }
        else
        {
            if (scoreamount >= 0.2f)
            {
                moneyEarnt *= scoreamount;
            }            
            moneyEarnt *= 0.1f;
        }
        Debug.Log(moneyEarnt);


    }
}
