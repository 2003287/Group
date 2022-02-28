using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    enum DirectionOFCam {North,South,East,West };
    // Start is called before the first frame update
    public float m_speed = 0.01f;
    
    private bool m_testing = false;
    private float m_test= 0.0f;
   
    float smmoth = 1.0f;

   // float tiltAngle = 90.0f;
    //public Transform m_camera;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            m_testing = true;
          
            Debug.Log("four");
           
        }
        if (m_testing == true)
        {
            /* while (m_test<1.0f)
             {

                 m_test = Mathf.Clamp(m_test+Time.deltaTime * m_speed,0,1) ;
                 Camera.main.transform.position = Vector3.Lerp(m_startpos,m_position,m_test);
              Camera.main.transform.rotation =   // transform.rotation = ;
                 if (transform.position == m_position)
                 {
                     Debug.Log("testing positions");
                     m_testing = false;
                 }
             }*/
            //east = 40.5 , west = -40.5 south = -57.3 or 57.3
            float testing = Camera.main.transform.rotation.y*180/Mathf.PI;
            if (testing<90.5)
            {
                float tiltAroundY = m_test * smmoth;

                tiltAroundY *= Time.deltaTime;

                Camera.main.transform.Rotate(0, tiltAroundY, 0);
                m_test -= 0.5f;
            }
           // Debug.Log(testing);
           
        }
       
    }
}
