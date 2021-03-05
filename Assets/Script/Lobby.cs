using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    float time = 0;

    public Text txt;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;

        if ((int)time % 2 == 1)
        {
            Debug.Log(time);
            txt.text = "선물 받으러 가기";

        }

        if((int)time % 2 == 0)
        {
            txt.text = " ";
        }
            
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Scene1");
    }
}
