using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameObject;
    private RectTransform m_canvas;
    public Vector3 movepos = new Vector3(3.0f,0.0f,0.0f);
    void Start()
    {
        
    }
    public void Testing(GameObject game)
    {
        Debug.Log("this ignore has been created");
        m_gameObject = game;
        Debug.Log("the objects name is"+ m_gameObject);
        RectTransform recttest = this.GetComponent<RectTransform>();
        Vector3 pos = new Vector3(m_gameObject.transform.position.x +movepos.x, m_gameObject.transform.position.y+movepos.y, m_gameObject.transform.position.z+ movepos.z);
        Vector2 canpos;
        Vector2 screen = Camera.main.WorldToScreenPoint(pos);
        Canvas can = this.GetComponentInParent<Canvas>();
        RectTransform canrect = can.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canrect,screen,null,out canpos);

        // recttest.localPosition = pos;
        this.transform.localPosition =canpos;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
