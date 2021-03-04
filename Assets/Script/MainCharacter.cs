using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    Animator anim;
    float time = 0;

    public bool isMove = false;
    public Vector3 target;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        time += UnityEngine.Time.deltaTime;

        anim.SetFloat("Time", time);

        if(time >14)
        {
            time = 0;
        }


        if (transform.position == target)
        {
            isMove = false;
            anim.SetBool("isMove", false);
        }
            

        if(isMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.03f);
            anim.SetBool("isMove", true);
            time = 0;
        }
    }
}
