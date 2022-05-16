using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory script", menuName = "Inventory System/Inventory")]
public class InventoryoObject :ScriptableObject,ISerializationCallbackReceiver
{
    //create a dictionary database and a container of items
    public ItemDatabase m_database;
    public List<InventorySlot> m_container = new List<InventorySlot>();
    //add a item to the container
    public void addItem(ItemObject item, int amount)
    {
        bool hasitem = false;
        //check to see if the object is in the container already
        for (int i = 0; i < m_container.Count; i++)
        {
            if (m_container[i].m_item == item)
            {
               // m_container[i].AddAmount(amount);
                hasitem = true;
                break;
            }
        }
        //if it isnt add the item
        if (!hasitem)
        {
           
            m_container.Add(new InventorySlot(m_database.m_getid[item],item,amount));

        }
    }

    //setup the databse for the container of the items
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
            //add the to teh container for use in the level to spawn items
            if (!hasitem)
            {
                //Debug.Log("Adding in a item");
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

    //spawn teh objects
    public void SpawnObject(ItemObject item)
    {
        if (item)
        {
            //loop through the container
            for (int i = 0; i < m_container.Count; i++)
            {
                //find the room type of the object
                if (item.m_roomtype == m_container[i].m_item.m_roomtype)
                {
                    //find teh object type
                    if (item.m_objectType == m_container[i].m_item.m_objectType)
                    {
                        //sapwn the game object of the item
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
//inventory slot for holding the 
public class InventorySlot
{
    public int m_id;
    public ItemObject m_item;
    public int m_amount;
    //keep a record of teh irem amount of the object and the id
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