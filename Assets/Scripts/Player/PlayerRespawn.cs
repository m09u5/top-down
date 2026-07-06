using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    public void Respawn()
    {
        transform.position = spawnPoint.position;
    }
    
}
