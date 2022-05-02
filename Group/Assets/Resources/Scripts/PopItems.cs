using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopItems : MonoBehaviour
{
    public RoomType roomType;
    public ObjectType objectType;
    public Image m_image;
    private GameObject m_game;
    // Start is called before the first frame update
    void Start()
    {
        var games = GameObject.FindObjectsOfType<item>();

        for (int i = 0; i < games.Length; i++)
        {
            if (games[i].m_item.m_roomtype == roomType && games[i].m_item.m_objectType == objectType)
            {
                m_game = games[i].gameObject;
                break;
            }
        }

        Debug.Log(m_game);
        if (m_game)
        {
            if(m_game.GetComponent<item>().m_item.m_sprite)
                m_image.sprite = m_game.GetComponent<item>().m_item.m_sprite;
            
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
