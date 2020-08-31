using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    float validTouchDistance;
    string layerName;
    public GameObject myCharacter;

    Animator myCharacterAnimator;
    public Texture2D hand1;

    public Texture2D hand2;
    float speed;
    Vector3 hitpoint;

    bool isWalking = false;

    bool isIdling = false;

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
        ChangeCursor();
        AnimatorMapping();
    }
    private void Init()
    {
        validTouchDistance = 2000;
        layerName = "Ground";
        speed = 10.0f;
        Cursor.SetCursor(hand1, Vector2.zero, CursorMode.Auto);
        isIdling = true;
        myCharacterAnimator = myCharacter.GetComponent<Animator>();

    }
    void ChangeCursor()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(hand2, Vector2.zero, CursorMode.Auto);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.SetCursor(hand1, Vector2.zero, CursorMode.Auto);
        }
    }
    void TouchUpRightMouse()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, validTouchDistance, LayerMask.GetMask(layerName)))
            {
                GameObject gameObject = hitinfo.collider.gameObject;
                Vector3 v3 = new Vector3(hitinfo.point.x, myCharacter.transform.position.y, hitinfo.point.z);
                hitpoint = v3;
                myCharacter.transform.LookAt(v3);
                if (hitpoint != myCharacter.transform.position)
                {
                    isWalking = true;
                    isIdling = false;
                }
                // myCube.transform.Translate(Vector3.forward * speed*Time.deltaTime);
            }
        }
    }
    void MoveToPoint()
    {
        if (isWalking)
        {
            if (hitpoint != null)
            {
                myCharacter.transform.position = Vector3.MoveTowards(myCharacter.transform.position, hitpoint, speed * Time.deltaTime);
                if (myCharacter.transform.position == hitpoint)
                {
                    isWalking = false;
                    isIdling = true;
                }
            }
        }
    }

    void AnimatorMapping()
    {
        myCharacterAnimator.SetBool("isWalking", isWalking);
        myCharacterAnimator.SetBool("isIdling", isIdling);
    }

}
