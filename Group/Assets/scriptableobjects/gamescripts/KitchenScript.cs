using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Kitchen Object", menuName = "Inventory System/Items/Kitchen")]
public class KitchenScript : ItemObject
{
    public void Awake()
    {
        m_roomtype = RoomType.Kitchen;
        Debug.Log(m_roomtype);
    }
}
