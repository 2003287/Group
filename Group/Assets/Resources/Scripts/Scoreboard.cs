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

       
        //give the player a higher amount of money when performing badly for the prottype
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
        //when the text changes change the value on the screen
        if (text_change)
        {
            GetScore();
                
        }
        //the rating is above 61 allow the player to leave
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
  
        //after the first play through get the random items
        if (SharedScoreVaribles.firsttime)
        {
            for (int i = 0; i <= 4; i++)
            {
                SetupObjects(i);
            }
        }
        //specific worst items in the scene
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
        //calculate adn upadte the scoreing
        energyratingcalculater = EnergyCalcNorm();
        GetScore();

    }
    //calculate the energy rating
   private float EnergyCalcNorm()
    {
        float testing = 0.0f;
        float badbehaviour = 0.8f;
        Debug.Log(testing);
        Debug.Log(energyItems.Count);
        //when there is no items the score is 0
        if (energyItems.Count == 0)
        {
            testing = 0.0f;
        }
        //when there are items
        else
        {
            //loop through all the energy items
            for (int i = 0; i < energyItems.Count; i++)
            {
               //of the item has a h#behaviour that is on make teh energy rating lower
                if (energyItems[i].GetComponent<item>().m_item.m_Behaviour == 2)
                {
                    testing += (energyItems[i].GetComponent<item>().m_item.m_energyRating * badbehaviour);                

                }
                //add the normal energy value to teh item
                else
                {
                    testing += energyItems[i].GetComponent<item>().m_item.m_energyRating;                    
                }
              
            }
            Debug.Log(testing);
            //divide the rating by 5 to get the average
            testing /= energyItems.Count;

            float text = testing;
            contentText.Add("swapped item new energy rating " + text.ToString());
            Debug.Log(testing);
        }
      
        return testing;
    }
    //find a random int for the game objects in the scene
   private int Randomint()
    { 
      int i = Random.Range(0, objectsinScene.Count);
        return i;
    }

    //randomall;y settup the objects
    private void SetupObjects(int i)
    {
        if (i >= 1)
        {
            //select a random object 
            selectedobject = Randomint();
            //add it to the dictionary if it not already there
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

                //update the energy rating add to the energy rating list adm change the colour
                energyratingcalculater += (testing.m_item.m_energyRating * multi);
                energyItems.Add(objectsinScene[selectedobject]);
                objectsinScene[selectedobject].GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            //fins another object
            else
            {
                SetupObjects(i);
            }
           
        }
        //get the first object to find
        else
        {
            //get the random object in teh scene
            selectedobject = Randomint();
            m_dictionary.Add(objectsinScene[selectedobject], false);
         
            var testing = objectsinScene[selectedobject].GetComponent<item>();
            var multi = 1.0f;
            if (testing.m_item.m_Behaviour == 2)
            {
                multi = 0.8f;
            }
           
            //update the energy rating add to the energy rating list adm change the colour
            energyratingcalculater += (testing.m_item.m_energyRating*multi);
            energyItems.Add(objectsinScene[selectedobject]);
            objectsinScene[selectedobject].GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }

  //when the object has been touched or pressed
    public void GameObjectPopped(GameObject game)
    {
        //loop through the object in the scene check teh object is valid
        for (int i = 0; i < objectsinScene.Count; i++)
        {
            if (game.name == objectsinScene[i].name)
            {
               
                    //when object is in the dictionary reward teh player ofr finding it
                    if (m_dictionary.ContainsKey(game))
                    {
                       
                        m_dictionary[game] = true;
                        scorecounter += 200.0f;
                    timerfloat -= 0.1f;
                    Debug.Log(timerfloat);
                    var item = game.GetComponent<item>();
                    //add the money value to teh player
                    moneyEarnt += item.m_item.m_cost;
                  
                    contentText.Add(game.name+ "was found +"+ item.m_item.m_cost.ToString());
                    }
                    //if the item isnt in teh dictionary punish the player
                    else
                    {
                    var item = game.GetComponent<item>();
                    //negative when the item has no behaviour
                    if (!itemsBehaviour.Contains(game))
                    {
                        if (scorecounter > 50)
                        {
                            scorecounter -= 50.0f;
                        }
                        
                        //punish teh players money earned
                        moneyEarnt -= item.m_item.m_cost / 2.0f;
                        timerfloat += 0.1f;
                        float text = item.m_item.m_cost / 2.0f;
                        contentText.Add(game.name + "wrong popped item -" + text.ToString());
                    }
                    //when the object has a behaviour
                    else
                    {
                        //the player has touched a object with the behaviour off
                        if (item.m_item.m_Behaviour == 1)
                        {
                            if (scorecounter > 50)
                            {
                                scorecounter -= 50.0f;
                            }                         
                            moneyEarnt -= item.m_item.m_cost / 2.0f;
                            timerfloat += 0.1f;
                            float text = item.m_item.m_cost / 2.0f;
                            contentText.Add(game.name + "wrong popped item -" + text.ToString());
                        }                        
                    }
                    
                }
               //the text needs to be updated
                text_change = true;
            }
        }

    }
    //removal of objects fromt eh objects in th scene
    public void RemovalofObjects(GameObject game)
    {
        if (objectsinScene.Contains(game))
        {
            objectsinScene.Remove(game);
        }
        Debug.Log(objectsinScene.Count);
    }
    //swapping teh game and items in the energy items list
    float Energycreater(GameObject game, GameObject item)
    {
        float testing = 0.0f;
        Debug.Log(game);
        //sawp object and items in the energy items list
        energyItems.Remove(game);
        energyItems.Add(item);

        //behaviour check to see if teh item needs to be set up
        if (game.GetComponent<item>().m_item.m_Behaviour != 0)
        {
            item.GetComponent<item>().m_item.m_Behaviour = game.GetComponent<item>().m_item.m_Behaviour;
            Debug.Log(item.GetComponent<item>().m_item.m_Behaviour);
        }
        Debug.Log(game.name);
        Debug.Log(item.name);
        //calculate the energy rating
        testing = EnergyCalcNorm();
      
        return testing;
    }
    //sets up the scorescreen varibles
    public void Scoresetup(float timer)
    {
        //the score screen varibles 
        scorescreen_time.text = timer.ToString() + " s";
        scorescreen_earnt.text = moneyEarnt.ToString();
        scorescreen_mod.text = timerfloat.ToString();
        scorescreen_rating.text = energyratingcalculater.ToString();
        SharedScoreVaribles.firsttime = true;
        SharedScoreVaribles.firsttimeint = 1;
        //calculate the money earnt
        Scorecalc(timer);
        scorescreen_score.text = moneyEarnt.ToString();
        //apply money to the players money
        if (moneyEarnt > 0)
        {
            SharedScoreVaribles.MoneyVarible += moneyEarnt;
        }
      
    }
    //setts up the varibles for score while the level is still beign played
    public void GetScore()
    {
        //level varibles
        Score_text.text = scorecounter.ToString();
        Money_text.text = SharedScoreVaribles.MoneyVarible.ToString();
        Money_earned_text.text = moneyEarnt.ToString();
        //shared values for home screen in later iterations
        SharedScoreVaribles.sharedFloat = scorecounter;
        SharedScoreVaribles.timerVarible = timerfloat;
        SharedScoreVaribles.energyRating = energyratingcalculater;          
        text_change = false;
    }
    //if the game object has its behaviour swapped
    public void BehaviourChange(GameObject game)
    {
        if (game)
        {
            //check if the behviour is in the behaviour list
            if (itemsBehaviour.Contains(game))
            {
                //the behavhoiur has been turned off
                if (game.GetComponent<item>().m_item.m_Behaviour == 1)
                {
                    moneyEarnt += 30;
                    Debug.Log("offff");
                    float text = 30.0f;
                    contentText.Add(game.name + "turned off +" + text.ToString());
                }
                //the behavour if left on
                else
                {
                    moneyEarnt -= 30;
                    Debug.Log("onnnn");
                    float text = 30.0f;
                    contentText.Add(game.name + "turned on -" + text.ToString());
                }
                //recalcuate the score
                energyratingcalculater = EnergyCalcNorm();
                //update the score
                GetScore();
            }
        }
    }
    //when the player sawpps an item
    public void NewInstance(GameObject game, GameObject item)
    {
       Debug.Log("THE SWAPPING HAS ACCURED");
        Debug.Log(game);
        if (objectsinScene.Contains(game))
        {
           // int pos = objectsinScene.IndexOf(game);
           //if the game object is in the midctionary
            if (m_dictionary.ContainsKey(game))
            {
              //  Debug.Log("THIS WAS TESTED OUT TO WORK");
              //swapes the energy list and recalculates the score
                energyratingcalculater =Energycreater(game,item);
                SwappedGameobjects.Add(item);
                //swapps the items in the behaviour list
                if (itemsBehaviour.Contains(game))
                {                   
                    itemsBehaviour.Add(item);
                    itemsBehaviour.Remove(game);
                }
            }
            //swap the game object to the item object for the swapped item list
            if (SwappedGameobjects.Contains(game))
            {
                energyratingcalculater = Energycreater(game, item);

                SwappedGameobjects.Add(item);
                SwappedGameobjects.Remove(game);
            }

           //remove the old game object from teh list
            objectsinScene.Remove(game);
         
        }
        //add the item to objects in the scene
        objectsinScene.Add(item.gameObject);
        Debug.Log(item.gameObject.GetComponent<item>().m_item.m_Behaviour);
        GetScore();
        Debug.Log(item.gameObject);
    }

    //if the item is removed
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
                //remove the item from the item from the item ebhaviour list
                if (itemsBehaviour.Contains(game))
                {                   
                 itemsBehaviour.Remove(game);
                }
            }
            //remove the item from the item from the swapped gameobjectlist list
            if (SwappedGameobjects.Contains(game))
            {
                //  energyratingcalculater = Energycreater(game, item);
                SwappedGameobjects.Remove(game);
                energyratingcalculater = EnergyCalcNorm();
                
            }

            //remove the item from the item from the energyitem list
            if (energyItems.Contains(game))
            {
                energyItems.Remove(game);
                energyratingcalculater = EnergyCalcNorm();
            }
            //remove the item from the item from the objects in scene list
            objectsinScene.Remove(game);
            // Debug.Log("was removed from the list new size "+ objectsinScene.Count);
        }

      
        GetScore();
       
    }
    //obsolete
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
        //check how many of the objects have been found
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
        //check the item behaviour count is not 0
        if (itemsBehaviour.Count != 0)
        {
            //find each object to make sure the object is not 0
            foreach (GameObject game in itemsBehaviour)
            {
                if (game.GetComponent<item>().m_item.m_Behaviour != 1)
                {
                    Debug.Log(game.name);
                    behaviourfloat -= 0.05f;
                    contentText.Add(game.name + "was left on -" + behaviourfloat.ToString());
                }
            }
        }

        Debug.Log(scoreamount);
        //Timer is below or above 90
        if (timerfloat <= 90)
        {   
            //formula for the money of the player
            moneyEarnt = (moneyEarnt + timer) / timerfloat;
        }
        else
        {
            //formula for the money of the player
            moneyEarnt = (moneyEarnt) / timerfloat;
        }
        Debug.Log(moneyEarnt);
        //make sure the money isn't negative
        if (moneyEarnt <= 0)
        {
            moneyEarnt = 0.0f;
        }
        //if the player was successful
        if (energyratingcalculater >= 61)
        {
            moneyEarnt *= scoreamount;
            contentText.Add("energy rating was above 61 score *=" +scoreamount);

        }
        //if the player is not successfull
        else
        {
            if (scoreamount >= 0.2f)
            {
                //if the player found a object
                moneyEarnt *= scoreamount;
                contentText.Add("energy rating was below 61 score *=" + scoreamount);
            }
            else
            {
                //if the player did not find an object
                moneyEarnt *= 0.1f;
                contentText.Add("energy rating was below 61 score *=" + 0.1f);
            }
           
        }
        //moeny time behavioural float
        moneyEarnt *= behaviourfloat;

        //punish player for just removing items
        if (energyItems.Count == 0)
        {
            moneyEarnt = -500.0f;
            contentText.Add("As there are no Items the score are negative");
        }
        //screate the score text
        for (int i = 0; i < contentText.Count; i++)
        {
            DefaultControls.Resources uires = new DefaultControls.Resources();
            GameObject text = DefaultControls.CreateText(uires);
            text.GetComponentInChildren<Text>().text = contentText[i];
            text.GetComponentInChildren<Text>().font = textfont;
            text.transform.SetParent(m_contentcontainer);
            text.transform.position = new Vector3(m_contentcontainer.position.x + 100, m_contentcontainer.position.y - (30 + (i * 30)), m_contentcontainer.position.z); 
        }
      
        Debug.Log(moneyEarnt);


    }
}
