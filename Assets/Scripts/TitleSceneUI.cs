using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneUI : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private TMP_Text pressText;

    private WaitForSecondsRealtime blinkInterval;

    public Button StartButton => startButton;

    private void Awake()
    {
        startButton = GetComponentInChildren<Button>();
        pressText = GetComponentInChildren<TMP_Text>();
        blinkInterval = new WaitForSecondsRealtime(1.0f);
    }

    private void Start()
    {
        StartCoroutine(TextBlinkRoutine());
    }

    private IEnumerator TextBlinkRoutine()
    {
        while(true)
        {
            pressText.text = "";
            yield return blinkInterval;
            pressText.text = "Go Get Your Present";
            yield return blinkInterval;
        }
    }
}
