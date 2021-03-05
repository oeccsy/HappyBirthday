using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainCharacterMove : MonoBehaviour, IPointerDownHandler
{
    public GameObject obj;

    MainCharacter mainCharacter;

    AudioSource walksound;

    void Start()
    {
        mainCharacter = FindObjectOfType<MainCharacter>();
        walksound = mainCharacter.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Left" && mainCharacter.isMove == false && mainCharacter.target.x > -2)
        {
            mainCharacter.target = obj.transform.position + new Vector3(-1.1f, 0, 0);
            Debug.Log("Left" + mainCharacter.target);
            mainCharacter.isMove = true;
            obj.transform.LookAt(mainCharacter.target);
            walksound.Play();
        }

        if (gameObject.name == "Right" && mainCharacter.isMove == false && mainCharacter.target.x < 2)
        {
            mainCharacter.target = obj.transform.position + new Vector3(1.1f, 0, 0);
            Debug.Log("Right" + mainCharacter.target);
            mainCharacter.isMove = true;
            obj.transform.LookAt(mainCharacter.target);
            walksound.Play();
        }

        if (gameObject.name == "Up" && mainCharacter.isMove == false && mainCharacter.target.z < 2)
        {
            mainCharacter.target = obj.transform.position + new Vector3(0, 0, 1.1f);
            Debug.Log("Up" + mainCharacter.target);
            mainCharacter.isMove = true;
            obj.transform.LookAt(mainCharacter.target);
            walksound.Play();
        }

        if (gameObject.name == "Down" && mainCharacter.isMove == false && mainCharacter.target.z > -2)
        {
            mainCharacter.target = obj.transform.position + new Vector3(0, 0, -1.1f);
            Debug.Log("Down" + mainCharacter.target);
            mainCharacter.isMove = true;
            obj.transform.LookAt(mainCharacter.target);
            walksound.Play();
        }

       
    }
}
