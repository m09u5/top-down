using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 3f;
    public GameObject player;
    private bool hasLOS = false;
    private Rigidbody2D rb;

    private float distance;
    private Vector2 lastSeen;
    void Start()
    {
        lastSeen = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLOS == true)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            lastSeen = player.transform.position;
        
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, lastSeen, moveSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit  = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        
        if (hit.collider.name == player.name)
        {
            hasLOS = true;
        }
        else 
        {
            hasLOS = false;
        }
    }
}
