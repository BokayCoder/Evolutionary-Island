using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{   
     float validTouchDistance;
     string layerName;
     public GameObject myCube;
     float speed;
     Vector3 hitpoint;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        TouchUpRightMouse();
        MoveToPoint();
    }
    private void Init()
    {
        validTouchDistance = 2000;
        layerName = "Ground";
        speed = 10.0f;
    }

    void TouchUpRightMouse()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if(Physics.Raycast(ray,out hitinfo,validTouchDistance,LayerMask.GetMask(layerName)))
            {   
                GameObject gameObject = hitinfo.collider.gameObject;
                Vector3 v3 = new Vector3(hitinfo.point.x,myCube.transform.position.y,hitinfo.point.z);
                hitpoint = v3;
                myCube.transform.LookAt(v3);
                // myCube.transform.Translate(Vector3.forward * speed*Time.deltaTime);
            }
        }
    }
    void MoveToPoint()
    {
            if (hitpoint != null)
        {
            myCube.transform.position = Vector3.MoveTowards(myCube.transform.position,hitpoint,speed*Time.deltaTime);
        }
    }

}
