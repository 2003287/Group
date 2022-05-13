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
    public static int firsttimeint;
    public static bool firsttime;
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
    private List<GameObject> energyItems;
    //public texts for display
    public Text Score_text;
    public Text Money_text;
    public Text Money_earned_text;
    public Text scorescreen_time;
    public Text scorescreen_earnt;
    public Text scorescreen_rating;
    public Text scorescreen_score;
    [SerializeField]
    private Text scorescreen_mod;
    [SerializeField]
    private Font textfont;
    //for the content
    [SerializeField]
    private Transform m_contentcontainer;

    //list of values for the content
    private List<string> contentText;
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
        energyItems = new List<GameObject>();
        contentText = new List<string>();
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
            SharedScoreVaribles.MoneyVarible = 700.0f;
            SharedScoreVaribles.firsttime = false;
            SharedScoreVaribles.firsttimeint = 0;
            SharedScoreVaribles.moneyset = true;
           



        }

       

        if (SharedScoreVaribles.MoneyVarible < 500)
        {
            SharedScoreVaribles.MoneyVarible = 500.0f;
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
            //Debug.Log(SharedScoreVaribles.sharedFloat);          
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
            Debug.Log(listofgame[i].name + i);
            //check the behaviours of the objects
            if (listofgame[i].GetComponent<item>().m_item.m_Behaviour == 0)
            {
              //Debug.Log("the dehaviour of the " + listofgame[i].name + "null");
            }
            else
            {
                Debug.Log("the dehaviour of the " + listofgame[i].name + "is active turn off the object");
                //randomally select the behaviour of the object
                listofgame[i].GetComponent<item>().m_item.m_Behaviour = Random.Range(1, 3);
                itemsBehaviour.Add(listofgame[i]);
                Debug.Log(listofgame[i].GetComponent<item>().m_item.m_Behaviour);
                //text test
                

            }
           
           
               // energyratingcalculater += testing.m_item.m_energyRating;
        }
        //350/500
        // energyratingcalculater = energyratingcalculater / objectsinScene.Count;
        //Debug.Log(scoretest);
        //etup the objects that need to be found

        if (SharedScoreVaribles.firsttime)
        {
            for (int i = 0; i <= 4; i++)
            {
                SetupObjects(i);
            }
        }
        else
        {
            // 1 games console 4 radioalarm, kettle 7, 6 razor, 2
            //games
            m_dictionary.Add(objectsinScene[1], false);
            energyItems.Add(objectsinScene[1]);
            objectsinScene[1].GetComponent<MeshRenderer>().material.color = Color.yellow;
            //alarm
            m_dictionary.Add(objectsinScene[4], false);
            energyItems.Add(objectsinScene[4]);
            objectsinScene[4].GetComponent<MeshRenderer>().material.color = Color.yellow;
            //kettle
            m_dictionary.Add(objectsinScene[7], false);
            energyItems.Add(objectsinScene[7]);
            objectsinScene[7].GetComponent<MeshRenderer>().material.color = Color.yellow;
            //razor
            m_dictionary.Add(objectsinScene[6], false);
            energyItems.Add(objectsinScene[6]);
            objectsinScene[6].GetComponent<MeshRenderer>().material.color = Color.yellow;
            //iron
            m_dictionary.Add(objectsinScene[0], false);
            energyItems.Add(objectsinScene[0]);
            objectsinScene[0].GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        
        energyratingcalculater = EnergyCalcNorm();
        GetScore();

    }

   private float EnergyCalcNorm()
    {
        float testing = 0.0f;
        float badbehaviour = 0.8f;
        Debug.Log(testing);
        Debug.Log(energyItems.Count);
       
        for (int i = 0; i < energyItems.Count; i++)
        {
           // Debug.Log(i);
         //   Debug.Log(energyItems[i].name);
            if (energyItems[i].GetComponent<item>().m_item.m_Behaviour == 2)
            {
                testing += (energyItems[i].GetComponent<item>().m_item.m_energyRating*badbehaviour);
                //Debug.Log(energyItems[i].GetComponent<item>().m_item.m_energyRating * badbehaviour);
              
            }
            else
            {
                testing += energyItems[i].GetComponent<item>().m_item.m_energyRating;
               // Debug.Log(energyItems[i]);
            }

           // Debug.Log(energyItems[i]);
        }
        Debug.Log(testing);
        testing /= energyItems.Count;

        float text = testing;
        contentText.Add("swapped item new energy rating " + text.ToString());
        Debug.Log(testing);
        return testing;
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
                var multi = 1.0f;
                if (testing.m_item.m_Behaviour == 2)
                {
                    multi = 0.8f;
                }
               // Debug.Log(multi);
                energyratingcalculater += (testing.m_item.m_energyRating * multi);
                energyItems.Add(objectsinScene[selectedobject]);
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
            var multi = 1.0f;
            if (testing.m_item.m_Behaviour == 2)
            {
                multi = 0.8f;
            }
           // Debug.Log(multi);
            energyratingcalculater += (testing.m_item.m_energyRating*multi);
            energyItems.Add(objectsinScene[selectedobject]);
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
                    contentText.Add(game.name+ "was found +"+ item.m_item.m_cost.ToString());
                }
                    else
                    {
                    var item = game.GetComponent<item>();
                    if (!itemsBehaviour.Contains(game))
                    {
                        if (scorecounter > 50)
                        {
                            scorecounter -= 50.0f;
                        }
                        
                        Debug.Log("Work damit as INTENDED");
                        moneyEarnt -= item.m_item.m_cost / 2.0f;
                        timerfloat += 0.1f;
                        float text = item.m_item.m_cost / 2.0f;
                        contentText.Add(game.name + "wrong popped item -" + text.ToString());
                    }
                    else
                    {
                        if (item.m_item.m_Behaviour == 1)
                        {
                            if (scorecounter > 50)
                            {
                                scorecounter -= 50.0f;
                            }

                            Debug.Log("Work damit as INTENDED");
                            moneyEarnt -= item.m_item.m_cost / 2.0f;
                            timerfloat += 0.1f;
                            float text = item.m_item.m_cost / 2.0f;
                            contentText.Add(game.name + "wrong popped item -" + text.ToString());
                        }                        
                    }
                    
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
        float testing = 0.0f;
        Debug.Log(game);
        energyItems.Remove(game);
        energyItems.Add(item);

        //behaviour check
        if (game.GetComponent<item>().m_item.m_Behaviour != 0)
        {
            item.GetComponent<item>().m_item.m_Behaviour = game.GetComponent<item>().m_item.m_Behaviour;
            Debug.Log(item.GetComponent<item>().m_item.m_Behaviour);
        }
        Debug.Log(game.name);
        Debug.Log(item.name);
        testing = EnergyCalcNorm();
       // Debug.Log("THE NEW ENERGY RATING" + testing.ToString());
        //testing -= game.GetComponent<item>().m_item.m_energyRating;
        //testing += item.GetComponent<item>().m_item.m_energyRating;

       // testing = testing / 5;

        //Debug.Log("THE NEW ENERGY RATING"+ testing.ToString());
        return testing;
    }

    public void Scoresetup(float timer)
    {
       // Debug.Log("testing this is running");
        //  scorescreen_score.text = scorecounter.ToString();
        scorescreen_time.text = timer.ToString() + " s";
        scorescreen_earnt.text = moneyEarnt.ToString();
        scorescreen_mod.text = timerfloat.ToString();
        scorescreen_rating.text = energyratingcalculater.ToString();
        SharedScoreVaribles.firsttime = true;
        SharedScoreVaribles.firsttimeint = 1;
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

    public void BehaviourChange(GameObject game)
    {
        if (game)
        {
            if (itemsBehaviour.Contains(game))
            {
                if (game.GetComponent<item>().m_item.m_Behaviour == 1)
                {
                    moneyEarnt += 30;
                    Debug.Log("offff");
                    float text = 30.0f;
                    contentText.Add(game.name + "turned off +" + text.ToString());
                }
                else
                {
                    moneyEarnt -= 30;
                    Debug.Log("onnnn");
                    float text = 30.0f;
                    contentText.Add(game.name + "turned on -" + text.ToString());
                }
                energyratingcalculater = EnergyCalcNorm();
                GetScore();
            }
        }
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

                if (itemsBehaviour.Contains(game))
                {                   
                    itemsBehaviour.Add(item);
                    itemsBehaviour.Remove(game);
                }
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
        Debug.Log(item.gameObject.GetComponent<item>().m_item.m_Behaviour);
        GetScore();
        Debug.Log(item.gameObject);
      //  Debug.Log("was removed from the list new size " + objectsinScene.Count);
      //  Debug.Log("Unpressed");
    }

    public void ItemRemoved(GameObject game)
    {
        Debug.Log("The item was Removed from the game");
        Debug.Log(game);
        if (objectsinScene.Contains(game))
        {
            // int pos = objectsinScene.IndexOf(game);

            if (m_dictionary.ContainsKey(game))
            {
                  Debug.Log("THIS WAS TESTED OUT TO WORK");
                // energyratingcalculater = Energycreater(game, item);
                energyratingcalculater = EnergyCalcNorm();

                if (itemsBehaviour.Contains(game))
                {
                   
                 itemsBehaviour.Remove(game);
                }
            }

            if (SwappedGameobjects.Contains(game))
            {
                //  energyratingcalculater = Energycreater(game, item);

                energyratingcalculater = EnergyCalcNorm();
                SwappedGameobjects.Remove(game);
            }

            if (energyItems.Contains(game))
            {
                energyItems.Remove(game);
                energyratingcalculater = EnergyCalcNorm();
            }
            objectsinScene.Remove(game);
            // Debug.Log("was removed from the list new size "+ objectsinScene.Count);
        }

      
        GetScore();
       
    }
    private void calcfounditems(float found)
    {
        switch (found)
        {
            case 0.0f:
                contentText.Add(" found no objects score *=" + 0.0f  );
                break;
            case 1.0f:
                contentText.Add(" found one objects score *=" + 0.2f);
                break;
            case 2.0f:
                contentText.Add(" found two objects score *=" + 0.4f);
                break;
            case 3.0f:
                contentText.Add(" found three objects score *=" + 0.6f);
                break;
            case 4.0f:
                contentText.Add(" found four objects score *=" + 0.8f);
                break;
           case 5.0f:
                contentText.Add(" found all objects score *=" + 1.0f);
                break;
            default:
                Debug.Log("broke");
                break;
        }
    }
    public void Scorecalc(float timer)
    {
        
        float scoreamount = 0.0f;
        float textfloat = 0.0f;
        foreach (bool found in m_dictionary.Values)
        {
            Debug.Log(found);
            if (found)
            {
                scoreamount += 0.2f;
                textfloat += 1.0f;
            }
           
        }
        
       

        float behaviourfloat = 1.0f;
        foreach (GameObject game in itemsBehaviour)
        {
            if (game.GetComponent<item>().m_item.m_Behaviour != 1)
            {
                Debug.Log(game.name);
                behaviourfloat -= 0.05f;
                contentText.Add(game.name   +"was left on -" + behaviourfloat.ToString());
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
        if (moneyEarnt <= 0)
        {
            moneyEarnt = 0.0f;
        }
        if (energyratingcalculater >= 61)
        {
            moneyEarnt *= scoreamount;
            contentText.Add("energy rating was above 61 score *=" +scoreamount);

        }
        else
        {
            if (scoreamount >= 0.2f)
            {
                moneyEarnt *= scoreamount;
                contentText.Add("energy rating was below 61 score *=" + scoreamount);
            }
            else
            {
                moneyEarnt *= 0.1f;
                contentText.Add("energy rating was below 61 score *=" + 0.1f);
            }
           
        }
        moneyEarnt *= behaviourfloat;


        for (int i = 0; i < contentText.Count; i++)
        {
            DefaultControls.Resources uires = new DefaultControls.Resources();
            GameObject text = DefaultControls.CreateText(uires);
            text.GetComponentInChildren<Text>().text = contentText[i];
            text.GetComponentInChildren<Text>().font = textfont;
            text.transform.SetParent(m_contentcontainer);
            text.transform.position = new Vector3(m_contentcontainer.position.x + 100, m_contentcontainer.position.y - (30 + (i * 30)), m_contentcontainer.position.z); 
        }
        /* DefaultControls.Resources uires = new DefaultControls.Resources();
            GameObject text = DefaultControls.CreateText(uires);
            text.GetComponentInChildren<Text>().text = listofgame[i].name;
            text.GetComponentInChildren<Text>().font = textfont;
            text.transform.SetParent(m_contentcontainer);
            text.transform.position = new Vector3(m_contentcontainer.position.x +00, m_contentcontainer.position.y -(20+(i*20)), m_contentcontainer.position.z);*/
        Debug.Log(moneyEarnt);


    }
}
