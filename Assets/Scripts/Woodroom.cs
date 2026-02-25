using UnityEngine;

public class Woodroom : MonoBehaviour
{
    [SerializeField]
    private Vector2Int beginPosition;
    [SerializeField]
    private Vector2Int endPosition;
    [SerializeField]
    private Vector3 actualBeginPosition;
    [SerializeField]
    private Vector3 actualEndPosition;

    public Vector2Int BeginPosition => beginPosition;
    public Vector2Int EndPosition => endPosition;

    private void Awake()
    {
        beginPosition = new Vector2Int(0, 0);
        endPosition = new Vector2Int(3, 3);
        actualBeginPosition = new Vector3(-2.3f, 0.5f, -2.3f);
        actualEndPosition = new Vector3(2.1f, 0.5f, 2.1f);
    }

    public Vector3 GetActualPosition(Vector2Int position)
    {
        float xUnit = (actualEndPosition.x - actualBeginPosition.x) / (endPosition.x - beginPosition.x);
        float yUnit = (actualEndPosition.z - actualBeginPosition.z) / (endPosition.y - beginPosition.y);
        return actualBeginPosition + new Vector3(xUnit * position.x, 0f, yUnit * position.y);
    }
}
