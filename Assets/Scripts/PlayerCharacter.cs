using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
enum State
{
    Idle,
    Moving
}

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    Vector2Int position;
    [SerializeField]
    private State state = State.Idle;

    public Vector2Int Position => position;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        position = new Vector2Int(0, 0);
    }

    public void MoveUp(Woodroom woodroom)
    {
        StartCoroutine(Move(woodroom, position + Vector2Int.up));
    }

    public void MoveDown(Woodroom woodroom)
    {
        StartCoroutine(Move(woodroom, position + Vector2Int.down));
    }

    public void MoveLeft(Woodroom woodroom)
    {
        StartCoroutine(Move(woodroom, position + Vector2Int.left));
    }

    public void MoveRight(Woodroom woodroom)
    {
        StartCoroutine(Move(woodroom, position + Vector2Int.right));
    }

    public IEnumerator Move(Woodroom woodroom, Vector2Int dest)
    {
        Debug.Log("Move");
        if(state == State.Moving) yield break;

        Vector3 actualDest = woodroom.GetActualPosition(dest);
        state = State.Moving;

        Debug.Log(actualDest);

        while (transform.position != actualDest)
        {
            transform.position = Vector3.MoveTowards(transform.position, actualDest, 1f * Time.deltaTime);    
            yield return null;
        }

        position = dest;
        state = State.Idle;
    }
}
