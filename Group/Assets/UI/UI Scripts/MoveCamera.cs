using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private int currentPos;
    public int CameraChoice;
   
    // Start is called before the first frame update
    void Start()
    {
        if (CameraChoice == 0)
        {
            currentPos = 1;
        }
        else
        {
            currentPos = 4;
        }
        SwitchPos(currentPos);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Getpos()
    {
        return currentPos;
    }
    public void MoveCameraPos(int nextPos)
    {
        currentPos += nextPos;
        if (CameraChoice == 0)
        {
            if (currentPos >= 4)
            {
                currentPos = 1;
            }
            else if (currentPos <= 0)
            {
                currentPos = 3;
            }
        }
        else
        {
            if (currentPos >= 5)
            {
                currentPos = 1;
            }
            else if (currentPos <= 0)
            {
                currentPos = 3;
            }
        }
       

        SwitchPos(currentPos);
    }


    void SwitchPos(int Position)
    {
        switch (Position)
        {
            case 1:
                {
                    Vector3 pos = new Vector3(6.6f, 1, -2.0f);
                    this.transform.position = pos;
                    this.transform.rotation = Quaternion.Euler(0.0f, -30.0f, 0.0f);
                }
                break;
            case 2:
                {
                    //position 2 is vector3(3.65,1,-1.8);
                    //rotation 2 is Quaternion.Euler(0.0f,-60.0f,0.0f);
                    Vector3 pos = new Vector3(3.0f, 1, -1.8f);
                    this.transform.position = pos;
                    this.transform.rotation = Quaternion.Euler(0.0f, -60.0f, 0.0f);
                }
                break;
            case 3:
                {
                    //position3 is vector3(2,1.5,-1.5);
                    //rotation3 is Quaternion.Euler(0.0f,-135.0f,0.0f);
                    Vector3 pos = new Vector3(2, 1.5f, -1.5f);
                    this.transform.position = pos;
                    this.transform.rotation = Quaternion.Euler(0.0f, -135.0f, 0.0f);
                }
                break;
            case 4:
                {
                    //position3 is vector3(2,1.5,-1.5);
                    //rotation3 is Quaternion.Euler(0.0f,-135.0f,0.0f);
                    Vector3 pos = new Vector3(0, 11, -1.5f);
                    this.transform.position = pos;
                    this.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
                }
                break;
            default:
                Debug.Log("this shouldn't be happeing why is the camera position in defualt");
                break;

        }
    }
}
