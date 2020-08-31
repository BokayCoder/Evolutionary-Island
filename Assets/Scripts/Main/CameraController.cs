using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float scaleSpeed;
    float minZ;
    float maxZ;

    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        CameraScaler();
        MoveCamera();
    }
    void Init()
    {
        scaleSpeed = 1.0f;
        minZ = -10.0f;
        maxZ = -1.5f;
        moveSpeed = 10.0f;

    }
        void MoveCamera()
    {
        if(Input.mousePosition.x >= Screen.width)
        {   
            Camera.main.transform.Translate(1 * moveSpeed*Time.deltaTime, 0, 0,Space.World);
            Debug.Log("right");
        }
        if(Input.mousePosition.x <= 0)
        {   
            Camera.main.transform.Translate(-1 * moveSpeed*Time.deltaTime, 0, 0,Space.World);
            Debug.Log("left");
        }
        if(Input.mousePosition.y >= Screen.height)
        {   
            Camera.main.transform.Translate(0,0,1 * moveSpeed*Time.deltaTime,Space.World);

             Debug.Log("up");
        }
        if(Input.mousePosition.y <= 0)
        {
            Camera.main.transform.Translate(0,0,-1 * moveSpeed*Time.deltaTime,Space.World);
           
            Debug.Log("down");
            
        }
    }
    void CameraScaler()
    {

        if (Camera.main.transform.position.z > minZ)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Camera.main.transform.Translate(0, 0, -1 * scaleSpeed);
                Debug.Log(Camera.main.name);
            }

        }
        if (Camera.main.transform.position.z < maxZ)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Camera.main.transform.Translate(0, 0, 1 * scaleSpeed);
            }
        }
    }
}