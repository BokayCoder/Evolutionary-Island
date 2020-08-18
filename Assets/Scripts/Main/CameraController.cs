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