using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

public class NPC : MonoBehaviour
{
    enum State
    {
        Idle,
        Moving
    }

    [SerializeField]
    private Animator animator;

    [SerializeField]
    Vector2Int position;
    [SerializeField]
    private State state = State.Idle;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        position = new Vector2Int(3, 3);
    }

    public void RandomMove(Woodroom woodroom, PlayerCharacter playerCharacter)
    {
        Vector2Int dest;
        
        Vector2Int[] directions = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
        };

        do
        {
            int randomIndex = Random.Range(0, 4);
            dest = position + directions[randomIndex];
        } while (dest == playerCharacter.Dest || dest.x < 0 || dest.x > 3 || dest.y < 0 || dest.y > 3);

        StartCoroutine(Move(woodroom, dest, playerCharacter));
    }

    private IEnumerator Move(Woodroom woodroom, Vector2Int dest, PlayerCharacter playerCharacter)
    {
        if (state == State.Moving) yield break;

        Vector3 actualDest = woodroom.GetActualPosition(dest);
        state = State.Moving;
        animator.SetInteger("State", (int)state);

        while (transform.position != actualDest)
        {
            transform.position = Vector3.MoveTowards(transform.position, actualDest, 1f * Time.deltaTime);
            transform.forward = transform.position - playerCharacter.transform.position;
            yield return null;
        }

        position = dest;
        state = State.Idle;
        animator.SetInteger("State", (int)state);
    }
}
