using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalMoveTest : MonoBehaviour
{

    public GameObject go;
    public Animator anim;

    private Quaternion orgRot;

    void Start()
    {
        go = this.gameObject;
        anim = GetComponent<Animator>();
        orgRot = go.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion rot = go.transform.rotation;
            rot.y = 90;
            go.transform.SetPositionAndRotation(go.transform.position, rot);
            if(anim.GetBool("Move") == false)
            {
                anim.SetBool("Move", true);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Quaternion rot = go.transform.rotation;
            rot.y = -90;
            go.transform.SetPositionAndRotation(go.transform.position, rot);
            if (anim.GetBool("Move") == false)
            {
                anim.SetBool("Move", true);
            }
        }
        else if(!(Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.D))))
        {
            go.transform.SetPositionAndRotation(go.transform.position, orgRot);
            if (anim.GetBool("Move") == true)
            {
                anim.SetBool("Move", false);
            }
        }
    }
}
