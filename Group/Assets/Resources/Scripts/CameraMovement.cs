using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    enum Cameraposition {POSITION1, POSITION2,POSITION3 };
    // Start is called before the first frame update
    public float m_speed = 0.01f;
    
    private bool m_testing = false;
    private float m_test= 0.0f;
    private Cameraposition m_camposState;
    float smmoth = 1.0f;

    // float tiltAngle = 90.0f;
    //public Transform m_camera;

    void Switchstate(Cameraposition cam)
    {
        switch (cam)
        {
            case Cameraposition.POSITION1:
                if (!m_testing)
                {
                    Vector3 pos = new Vector3(10,1,-3.5f);
                    this.transform.position = pos;
                    this.transform.rotation = Quaternion.Euler(0.0f,-30.0f,0.0f);
                    m_testing = true;
                }
                break;
            case Cameraposition.POSITION2:
                if (!m_testing)
                {
                    //position 2 is vector3(3.65,1,-1.8);
                    //rotation 2 is Quaternion.Euler(0.0f,-60.0f,0.0f);
                    Vector3 pos = new Vector3(3.65f, 1, -1.8f);
                    this.transform.position = pos;
                    this.transform.rotation = Quaternion.Euler(0.0f, -60.0f, 0.0f);
                    m_testing = true;
                }
                break;
            case Cameraposition.POSITION3:
                if (!m_testing)
                {
                    //position3 is vector3(2,1.5,-1.5);
                    //rotation3 is Quaternion.Euler(0.0f,-135.0f,0.0f);
                    Vector3 pos = new Vector3(2, 1.5f, -1.5f);
                    this.transform.position = pos;
                    this.transform.rotation = Quaternion.Euler(0.0f, -135.0f, 0.0f);
                    m_testing = true;
                }
                break;
            default:
                Debug.Log("this shouldn't be happeing why is the camera position in defualt");
                break;

        }
    }
    void Start()
    {
        m_camposState = Cameraposition.POSITION1;
        m_testing = false;
        Switchstate(m_camposState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            m_testing = false;
          
           
           
        }

      
        if (!m_testing == true)
        {
            m_camposState = CamereSet(m_camposState);
            Debug.Log(m_camposState);
            Switchstate(m_camposState);
           // m_testing = true;
            //position one is vector3(10,1,-3.5)
            //rotation one is Quaternion.Euler(0.0f,-30.0f,0.0f);
            //position 2 is vector3(3.65,1,-1.8);
            //rotation 2 is Quaternion.Euler(0.0f,-60.0f,0.0f);
            //position3 is vector3(2,1.5,-1.5);
            //rotation3 is Quaternion.Euler(0.0f,-135.0f,0.0f);
            //east = 40.5 , west = -40.5 south = -57.3 or 57.3
            /* float testing = Camera.main.transform.rotation.y*180/Mathf.PI;
             if (testing>-40.5)
             {
                 float tiltAroundY = m_test * smmoth;

                 tiltAroundY *= Time.deltaTime;

                 Camera.main.transform.Rotate(0, tiltAroundY, 0);
                 m_test -= 0.5f;
             }*/       
           
        }
       
    }


    Cameraposition CamereSet(Cameraposition came)
    {
        Cameraposition localposition = Cameraposition.POSITION1;

        if (came == Cameraposition.POSITION1)
        {
            localposition = Cameraposition.POSITION2;
        }
        else if (came == Cameraposition.POSITION2)
        {
            localposition = Cameraposition.POSITION3;
        }
        else if (came == Cameraposition.POSITION3)
        {
            localposition = Cameraposition.POSITION1;
        }
        Debug.Log(localposition);
        return localposition;
    }
}
