using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{

    Vector3 moveVec;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.MoveFlag == true)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
            
        }
        if (chair.sit == true)
        {
            anim.SetBool("sit", true);

        }
        else
        {
            anim.SetBool("sit", false);

        }
    }
}
