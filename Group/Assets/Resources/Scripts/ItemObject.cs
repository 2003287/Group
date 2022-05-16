using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//enum for the room type
public enum RoomType
{ 
    Bathroom,
    Bedroom,
    Kitchen,
    Default
}
//eneum for the object in teh scene
public enum ObjectType
{ 
  Shower,
  Razor,
  Hairdrier,
  toothbrush
}
//creates the itemscript for each item 
public abstract class ItemObject : ScriptableObject
{
    //object typing and holding th game objects
    public RoomType m_roomtype;
    public GameObject m_prefab;
    public GameObject gameObject;
    public ObjectType m_objectType;
    public Sprite m_sprite;
    public Image image;
    //the items values
    public int itemroom = 0;
    public float m_cost = 50.0f;
    public float m_energyRating = 50.0f;
    public int m_Behaviour = 0;

}
