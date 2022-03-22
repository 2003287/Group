using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New bathroom Object", menuName = "Inventory System/Items/Bathroom")]
public class BathRoomObject : ItemObject
{
    public void Awake()
    {
        m_roomtype = RoomType.Bathroom;
        Debug.Log(m_roomtype);
    }
}
