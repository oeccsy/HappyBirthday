using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour, IPointerDownHandler
{
    public GameObject player;
    Vector3 target;
    Vector3 zero = Vector3.zero;
    
    int isMove = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (player.transform.position == target)
            isMove = 0;

        if (isMove == 1)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, target, 0.1f);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left" && isMove == 0)
        {
            target = player.transform.position + new Vector3(-1.1f, 0, 0);
            Debug.Log("Left"+target);
        }

        if (gameObject.name == "Right")
        { 
            target = player.transform.position + new Vector3(1.1f, 0, 0);
            Debug.Log("Right" + target);
        }

        if (gameObject.name == "Up")
        {
            target = player.transform.position + new Vector3(0, 0, 1.1f);
            Debug.Log("Up" + target);
        }

        if (gameObject.name == "Down")
        {
            target = player.transform.position + new Vector3(0, 0, -1.1f);
            Debug.Log("Down" + target);
        }

        isMove = 1;
        player.transform.LookAt(target);
    }
}
