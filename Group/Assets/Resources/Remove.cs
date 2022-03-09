using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject m_gameobject;
    public Vector3 movepos = new Vector3(0.0f, 0.0f, 0.0f);
    void Start()
    {
        
        Debug.Log("remove has spawned in yoo");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Testing(GameObject game)
    {
        m_gameobject = game;
        Debug.Log("the objects name is" + m_gameobject);
        RectTransform recttest = this.GetComponent<RectTransform>();
        Vector3 pos = new Vector3(m_gameobject.transform.position.x + movepos.x, m_gameobject.transform.position.y + movepos.y, m_gameobject.transform.position.z + movepos.z);
        Vector2 canpos;
        Vector2 screen = Camera.main.WorldToScreenPoint(pos);
        Canvas can = this.GetComponentInParent<Canvas>();
        RectTransform canrect = can.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canrect, screen, null, out canpos);

        // recttest.localPosition = pos;
        this.transform.localPosition = canpos;
    }

    public void testing()
    {
        Debug.Log("this is testing");
        m_gameobject.SendMessage("Delete");
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
}
