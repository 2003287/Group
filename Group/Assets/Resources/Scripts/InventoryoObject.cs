using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory script", menuName = "Inventory System/Inventory")]
public class InventoryoObject :ScriptableObject,ISerializationCallbackReceiver
{
    public ItemDatabase m_database;
    public List<InventorySlot> m_container = new List<InventorySlot>();

    public void addItem(ItemObject item, int amount)
    {
        bool hasitem = false;

        for (int i = 0; i < m_container.Count; i++)
        {
            if (m_container[i].m_item == item)
            {
               // m_container[i].AddAmount(amount);
                hasitem = true;
                break;
            }
        }
        if (!hasitem)
        {
           
            m_container.Add(new InventorySlot(m_database.m_getid[item],item,amount));

        }
    }


    public void Setup()
    {
        for (int i = 0; i < m_database.items.Length; i++)
        {
            
            ItemObject item = m_database.m_getItem[i];
            var hasitem = false;
            for (int j = 0; j < m_container.Count; j++)
            {
                if (m_container[j].m_item == item)
                {
                    // m_container[i].AddAmount(amount);
                    hasitem = true;
                    break;
                }
            }
            if (!hasitem)
            {
                Debug.Log("Adding in a item");
                m_container.Add(new InventorySlot(m_database.m_getid[item], item, 1));
            }
           
        }
    }
    public void OnAfterDeserialize()
    {
        for (int i = 0; i < m_container.Count; i++)
        {
            m_container[i].m_item = m_database.m_getItem[m_container[i].m_id];
        }
    }

    public void SpawnObject(ItemObject item)
    {
        if (item)
        {
            for (int i = 0; i < m_container.Count; i++)
            {
                if (item.m_roomtype == m_container[i].m_item.m_roomtype)
                {
                    if (item.m_objectType == m_container[i].m_item.m_objectType)
                    {
                        Instantiate(m_container[i].m_item.gameObject);
                        Debug.Log("spawning" + m_container[i].m_item.gameObject);
                    }
                     
                   // Debug.Log("there is an item in the container" + m_container[i].m_item.gameObject);
                }
            }
        }
        
    }
    public void Itemcheck(ItemObject item)
    {
        if (item)
        {
            for (int i = 0; i < m_container.Count; i++)
            {
                if (item.m_roomtype == m_container[i].m_item.m_roomtype)
                {
                  //  if(item.m_objectType == m_container[i].m_item.m_objectType)
                   // Debug.Log("there is an item in the container"+ m_container[i].m_item.gameObject);
                }
            }

                      
        }
    }
    public void OnBeforeSerialize()
    {
        
    }
}

[System.Serializable]
public class InventorySlot
{
    public int m_id;
    public ItemObject m_item;
    public int m_amount;
    
    public InventorySlot(int id,ItemObject item, int amount) {

        m_item = item;
        m_amount = amount;
        m_id = id;
        
    }

    public void AddAmount(int value)
    {
        m_amount += value;
    }




}