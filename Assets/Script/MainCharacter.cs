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
        target = new Vector3(-2.3f, 0.5f, -2.3f);
    }

    void Update()
    {
        time += Time.deltaTime;

        anim.SetFloat("Time", time);

        if(time >14)
        {
            time = 0;
        }

        if (isMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
            anim.SetBool("isMove", true);
            time = 0;

        }

        if (transform.position == target)
        {
            isMove = false;
            anim.SetBool("isMove", false);
        }


    }
}
