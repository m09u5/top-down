using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 3f;
    public GameObject player;
    private bool hasLOS = false;
    private Rigidbody2D rb;
    public enum EnemyState
    {
        Idle,
        Chase,
        Return,
        LastSeen,
    }

    [SerializeField] private EnemyState CurrentState;

    [SerializeField]private float rangeDistance = 5f;
    private float distance;
    private Vector2 lastSeen;
    private Vector3 spawnLocation;
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        spawnLocation = transform.position;
        lastSeen = transform.position;
        CurrentState = EnemyState.Idle;
    }

    
    void Update()
    {
        Debug.DrawRay(
            transform.position,
            (player.transform.position - transform.position).normalized * rangeDistance,
            Color.red
        );
        switch (CurrentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.LastSeen:
                LastSeen();
                break;
        }
    }

    private void MoveTowardsTarget(Vector2 target)
    {
        
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        // animator.SetFloat("MoveX",  direction.x);
        // animator.SetFloat("MoveY", direction.y);
    }

    void CanSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, rangeDistance);
        hasLOS = hit.collider != null && hit.collider.CompareTag("Player");
    }

    private void Idle()
    {
        CanSeePlayer();
        if (hasLOS)
        {
            lastSeen = player.transform.position;
            CurrentState = EnemyState.Chase;
        }
    }

    private void Chase()
    {
        CanSeePlayer();
        if (hasLOS)
        {
            lastSeen = player.transform.position;
            MoveTowardsTarget(player.transform.position);
        }
        else
        {
            CurrentState = EnemyState.LastSeen;
        }
    }

    private void LastSeen()
    {
        CanSeePlayer();
        if (hasLOS)
        {
            CurrentState = EnemyState.Chase;
            return;
        }

        if (Vector2.Distance(transform.position, lastSeen) > 0.05f)
        {
            Debug.Log("going to last seen");
            MoveTowardsTarget(lastSeen);
        }
        else
        {
            CurrentState = EnemyState.Return;
        }
    }

    private void Return()
        {
            CanSeePlayer();
            if (hasLOS)
            {
                CurrentState = EnemyState.Chase;
                return;
            }

            if (Vector2.Distance(transform.position, spawnLocation) > 0.05f)
            {
                Debug.Log("returning to spawn location");
                MoveTowardsTarget(spawnLocation);
            }
            else
            {
                CurrentState = EnemyState.Idle;
            }
        }
}
