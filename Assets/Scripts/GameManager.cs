using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
        Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/TitleScene"));
    }
}
