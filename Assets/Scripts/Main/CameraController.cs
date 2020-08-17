using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    float scaleSpeed;
    float minZ;
    float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        CameraScaler();
    }
    void Init()
    {
        scaleSpeed = 1.0f;
        minZ = -10.0f;
        maxZ = -1.5f;

    }

    void CameraScaler()
    {   

        if (Camera.main.transform.position.z < minZ)
        {
            Camera.main.transform.position = new Vector3(-0.3f, 30.4f, -10.0f);
            return;
        }
        if (Camera.main.transform.position.z > maxZ)
        {
            Camera.main.transform.position = new Vector3(-0.4f, 6.9f, -1.5f);
            return;
        }
        if (Input.GetAxis("Mouse ScrollWheel")<0)
        {
            Camera.main.transform.Translate(0,0,-1*scaleSpeed);   
            Debug.Log(Camera.main.name);
        }
         if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            Camera.main.transform.Translate(0,0,1*scaleSpeed);   
        }
        Debug.Log(Camera.main.transform.position);
    }
}