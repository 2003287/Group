using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New inventory Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabase : ScriptableObject,ISerializationCallbackReceiver
{
    public ItemObject[] items;   
    public Dictionary<ItemObject,int> m_getid = new Dictionary<ItemObject,int>();
    public Dictionary< int,ItemObject> m_getItem = new Dictionary< int,ItemObject>();
    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        m_getid = new Dictionary<ItemObject, int>();
        m_getItem = new Dictionary<int, ItemObject>();
        for (int i = 0; i < items.Length; i++)
        {
            m_getid.Add(items[i], i);
            m_getItem.Add(i,items[i]);
          
        }
    }
}
