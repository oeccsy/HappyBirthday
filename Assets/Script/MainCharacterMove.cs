using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainCharacterMove : MonoBehaviour, IPointerDownHandler
{
    public GameObject obj;

    MainCharacter mainCharacter;

    void Start()
    {
        mainCharacter = FindObjectOfType<MainCharacter>();
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Left" && mainCharacter.isMove == false)
        {
            mainCharacter.target = obj.transform.position + new Vector3(-1.1f, 0, 0);
            Debug.Log("Left" + mainCharacter.target);
        }

        if (gameObject.name == "Right" && mainCharacter.isMove == false)
        {
            mainCharacter.target = obj.transform.position + new Vector3(1.1f, 0, 0);
            Debug.Log("Up" + mainCharacter.target);
        }

        if (gameObject.name == "Up" && mainCharacter.isMove == false)
        {
            mainCharacter.target = obj.transform.position + new Vector3(0, 0, 1.1f);
            Debug.Log("Up" + mainCharacter.target);
        }

        if (gameObject.name == "Down" && mainCharacter.isMove == false)
        {
            mainCharacter.target = obj.transform.position + new Vector3(0, 0, -1.1f);
            Debug.Log("Down" + mainCharacter.target);
        }

        mainCharacter.isMove = true;
        obj.transform.LookAt(mainCharacter.target);
    }
}
