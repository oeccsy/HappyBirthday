using System.Collections;
using System.Data;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    enum State
    {
        Idle,
        Moving
    }

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    Vector2Int position;
    [SerializeField]
    Vector2Int dest;
    [SerializeField]
    private State state = State.Idle;
    [SerializeField]
    private WaitForSeconds lookAroundInterval = new WaitForSeconds(5f);

    public Vector2Int Position => position;
    public Vector2Int Dest => dest;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Sound/Walk");

        position = new Vector2Int(0, 0);
        dest = position;
    }
    private void Start()
    {
        StartCoroutine(LookAroundRoutine());
    }

    public void MoveUp(Woodroom woodroom)
    {
        if (position.y >= woodroom.EndPosition.y) return; 
        StartCoroutine(Move(woodroom, position + Vector2Int.up));
    }

    public void MoveDown(Woodroom woodroom)
    {
        if (position.y <= woodroom.BeginPosition.y) return;
        StartCoroutine(Move(woodroom, position + Vector2Int.down));
    }

    public void MoveLeft(Woodroom woodroom)
    {
        if (position.x <= woodroom.BeginPosition.x) return;
        StartCoroutine(Move(woodroom, position + Vector2Int.left));
    }

    public void MoveRight(Woodroom woodroom)
    {
        if (position.x >= woodroom.EndPosition.x) return;
        StartCoroutine(Move(woodroom, position + Vector2Int.right));
    }

    private IEnumerator Move(Woodroom woodroom, Vector2Int dest)
    {
        if(state == State.Moving) yield break;

        Vector3 actualDest = woodroom.GetActualPosition(dest);
        state = State.Moving;
        animator.SetInteger("State", (int)state);
        this.dest = dest;

        transform.LookAt(actualDest);
        audioSource.Play();

        while (transform.position != actualDest)
        {
            transform.position = Vector3.MoveTowards(transform.position, actualDest, 1f * Time.deltaTime);    
            yield return null;
        }

        position = dest;
        state = State.Idle;
        animator.SetInteger("State", (int)state);
    }

    private IEnumerator LookAroundRoutine()
    {
        while(true)
        {
            yield return lookAroundInterval;
            animator.SetBool("LookAround", true);
            yield return lookAroundInterval;
            animator.SetBool("LookAround", false);
        }
    }
}
