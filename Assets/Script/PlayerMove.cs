using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour, IPointerDownHandler
{
    public GameObject mainCharacter;

    Player player;

    Vector3 target;
    Vector3 zero = Vector3.zero;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
      //  if (mainCharacter.transform.position == target)
           // player.isMove == 0;

        if (player.isMove == 1)
        {
            mainCharacter.transform.position = Vector3.SmoothDamp(mainCharacter.transform.position, target, ref zero, 0.1f);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left" && player.isMove == 0)
        {
            target = mainCharacter.transform.position + new Vector3(-1.1f, 0, 0);
            Debug.Log("Left"+target);
        }

        if (gameObject.name == "Right" && player.isMove == 0)
        { 
            target = mainCharacter.transform.position + new Vector3(1.1f, 0, 0);
            Debug.Log("Right" + target);
        }

        if (gameObject.name == "Up" && player.isMove == 0)
        {
            target = mainCharacter.transform.position + new Vector3(0, 0, 1.1f);
            Debug.Log("Up" + target);
        }

        if (gameObject.name == "Down" && player.isMove == 0)
        {
            target = mainCharacter.transform.position + new Vector3(0, 0, -1.1f);
            Debug.Log("Down" + target);
        }

      //  player.isMove == 1;
        mainCharacter.transform.LookAt(target);
    }
}
