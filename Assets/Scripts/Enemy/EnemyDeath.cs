using UnityEngine;

public class EnemyDeath : DeathHandler
{
    public override void  HandleDeath()
    {
        Debug.Log("dropped loot");
        DestroyMonster();
    }

    private void DestroyMonster()
    {
        Destroy(gameObject);
    }


}
