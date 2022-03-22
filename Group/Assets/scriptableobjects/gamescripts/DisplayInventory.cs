using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public InventoryoObject m_inventory;
    public int x_start;
    public int y_start;
    public int x_space;
    public int NUM_of_col;
    public int y_space;

    Dictionary<InventorySlot, GameObject> ItemsDisplay = new Dictionary<InventorySlot, GameObject>();
    void Start()
    {
        CreateDisplay();


    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < m_inventory.m_container.Count; i++)
        {
            if (ItemsDisplay.ContainsKey(m_inventory.m_container[i]))
            {
                ItemsDisplay[m_inventory.m_container[i]].GetComponentInChildren<TextMeshProUGUI>().text = m_inventory.m_container[i].m_amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(m_inventory.m_container[i].m_item.m_prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPos(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = m_inventory.m_container[i].m_amount.ToString("n0");
                ItemsDisplay.Add(m_inventory.m_container[i],obj);
            }
        }
    }
    public void CreateDisplay()
    {
        for (int i = 0; i < m_inventory.m_container.Count; i++)
        {
            var obj = Instantiate(m_inventory.m_container[i].m_item.m_prefab, Vector3.zero,Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition = GetPos(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = m_inventory.m_container[i].m_amount.ToString("n0");
            ItemsDisplay.Add(m_inventory.m_container[i], obj);
        }
    }

    public Vector3 GetPos(int i)
    {
        return new Vector3(x_start+(x_space*(i%NUM_of_col)),y_start +(-y_space*(i/NUM_of_col)),0.0f);
    }
}
