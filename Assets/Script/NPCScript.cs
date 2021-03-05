using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    MainCharacter mainCharacter;

    Animator anim;

    Vector3 target;
    Vector3 result;

    bool isMove = false;

    void Start()
    {
        mainCharacter = FindObjectOfType<MainCharacter>();
        anim = GetComponent<Animator>();
        target = new Vector3(2.1f, 0.5f, 2.1f);
    }

    void Update()
    {
        if (isMove == false && mainCharacter.isMove ==true)
        {
            do
            {
                target = RandomTarget();
            }
            while (target == mainCharacter.target || target.x > 3 || target.x < -3 || target.z > 3 || target.z < -3);
            anim.SetBool("isMove", true);
            isMove = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);
        transform.forward = transform.position - mainCharacter.transform.position;

        if (transform.position == target)
        {
            isMove = false;
            anim.SetBool("isMove", false);
        }
            




    }

    Vector3 RandomTarget()
    {
        int num;

        num = Random.Range(0, 4);    

        if (num == 0)
            result = transform.position + new Vector3(-1.1f, 0, 0);

        if (num == 1)
            result = transform.position + new Vector3(1.1f, 0, 0);

        if (num == 2)
            result = transform.position + new Vector3(0, 0, -1.1f);

        if (num == 3)
            result = transform.position + new Vector3(0, 0, 1.1f);

        return result;
        
    }
}
