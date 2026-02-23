using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField]
    private Button nwButton;
    [SerializeField]
    private Button neButton;
    [SerializeField]
    private Button swButton;
    [SerializeField]
    private Button seButton;

    public Button NwButton => nwButton;
    public Button NeButton => neButton;
    public Button SwButton => swButton;
    public Button SeButton => seButton;

    private void Awake()
    {
        nwButton = transform.Find("Canvas/NWButton").GetComponent<Button>();
        neButton = transform.Find("Canvas/NEButton").GetComponent<Button>();
        swButton = transform.Find("Canvas/SWButton").GetComponent<Button>();
        seButton = transform.Find("Canvas/SEButton").GetComponent<Button>();
    }
}
