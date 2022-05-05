using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum RoomType
{ 
    Bathroom,
    Bedroom,
    Kitchen,
    Default
}
public enum ObjectType
{ 
  Shower,
  Razor,
  Hairdrier,
  toothbrush
}
public abstract class ItemObject : ScriptableObject
{
    public RoomType m_roomtype;
    public GameObject m_prefab;
    public GameObject gameObject;
    public ObjectType m_objectType;
    public Sprite m_sprite;
    public Image image;
    public int itemroom = 0;
    public float m_cost = 50.0f;
    public float m_energyRating = 50.0f;
    public int m_Behaviour = 0;

}
