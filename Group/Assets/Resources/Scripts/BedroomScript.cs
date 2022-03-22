using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New bathroom Object", menuName = "Inventory System/Items/Bedroom")]
public class BedroomScript : ItemObject
{
    public void Awake()
    {
        m_roomtype = RoomType.Bedroom;
        Debug.Log(m_roomtype);
    }
}
