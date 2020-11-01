using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillXiaoKuLou : MonoBehaviour
{   
    public GameObject mesh;
     SkinnedMeshRenderer skin;
     Color color1;
     Color color2;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Skill();
    }
    IEnumerator CoroutineQ()
    {   
        Debug.Log("攻击力变为2倍");
        ChangeMeshColor(new Color(73/255,255/255,57/255,255/255),new Color(73/255,255/255,57/255,255/255));
        yield return new WaitForSeconds(3f);
        ChangeMeshColor(color1,color2);
        Debug.Log("攻击力还原");
        Debug.Log(color1+color2);
    }
    void Init()
    {   
        skin = mesh.GetComponent<SkinnedMeshRenderer>();
        color1 = skin.materials[0].color;
        color2 = skin.materials[1].color;
    }

    void ChangeMeshColor(Color c,Color b)
    {
        skin.materials[0].color = c;
        skin.materials[1].color = b;
    }
    void Skill()
    {   
        //QQQQQQQQQQQQQQQQQQQQQQQQQ
        if(Input.GetKey(KeyCode.Q))
        {
            
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {   
            StartCoroutine(CoroutineQ());
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {

        } 
        //WWWWWWWWWWWWWWWWWWWWWWWWWWW
        if(Input.GetKey(KeyCode.W))
        {

        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            
        }
        //EEEEEEEEEEEEEEEEEEEEEEEEEEEE  
        if(Input.GetKey(KeyCode.E))
        {

        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            
        }
        //RRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        if(Input.GetKey(KeyCode.R))
        {

        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            
        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            
        }
    } 
}
