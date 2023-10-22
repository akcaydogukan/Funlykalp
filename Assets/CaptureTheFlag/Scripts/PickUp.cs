using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{   [HideInInspector]
    public bool iHaveFlag = false;
    [HideInInspector]
    public GameObject Flag=null;
    public GameObject FlagPosObj;
    public float castingTime;
    [HideInInspector]
    public  bool transitionTo =false;
    float timer=0;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Flag"))
        {
            other.transform.parent = FlagPosObj.transform;
            other.transform.localPosition = Vector3.zero;
            Flag = other.gameObject;
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Player") && Flag != null && iHaveFlag && other.transform.GetComponent<PickUp>().transitionTo == false)
        {
                
            var f = Flag;
            Flag = null;
            other.transform.GetComponent<PickUp>().Flag = f;
            f.transform.parent = other.transform.GetComponent<PickUp>().FlagPosObj.transform;
            f.transform.localPosition = Vector3.zero;
            other.transform.GetComponent<PickUp>().transitionTo = true;
            transitionTo = true;
            return;
               
        }

    }

    private void LateUpdate()
    {  
        if (Flag != null)
            iHaveFlag = true;
        if (Flag == null)
        {
            iHaveFlag = false;
        }
        if (transitionTo)
        {
            timer += Time.deltaTime;
            if (timer >= castingTime)
            {
                timer = 0f;
                transitionTo = false;
            }
        }
           
    }
}