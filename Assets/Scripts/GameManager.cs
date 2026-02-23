using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/TitleScene"));
    }
}
