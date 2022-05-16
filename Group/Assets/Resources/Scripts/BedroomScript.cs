using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New bathroom Object", menuName = "Inventory System/Items/Bedroom")]
//for a bedrrom object set the room type
public class BedroomScript : ItemObject
{
    public void Awake()
    {
        m_roomtype = RoomType.Bedroom;
        Debug.Log(m_roomtype);
    }
}


