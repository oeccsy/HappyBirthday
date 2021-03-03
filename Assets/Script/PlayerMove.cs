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
        if (isMove == 1)
            player.transform.position = Vector3.MoveTowards(player.transform.position, target, 0.1f);

        if (player.transform.position == target)
            isMove = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left" && isMove == 0)
        {
            isMove = 1;
            target = player.transform.position + new Vector3(-1, 0, 0);
            Debug.Log("Left"+target);
        }
        if (gameObject.name == "Right")
        {
            isMove = 1;
            target = player.transform.position + new Vector3(1f, 0, 0);
            Debug.Log("Right" + target);
        }
        if (gameObject.name == "Up")
        {
            isMove = 1;
            target = player.transform.position + new Vector3(0, 0, 1);
            Debug.Log("Up" + target);
        }
        if (gameObject.name == "Down")
        {
            isMove = 1;
            target = player.transform.position + new Vector3(0, 0, -1);
            Debug.Log("Down" + target);
        }
    }
}
