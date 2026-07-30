using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject SpawnedMonster;
    [SerializeField]private GameObject MonsterParent;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(SpawnedMonster, transform.position, transform.rotation, MonsterParent.transform);
            Debug.Log ("triggered");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
