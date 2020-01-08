using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private EnemyAttack enemyAttack;

    private void Awake()
    {
        enemyAttack = GetComponentInParent<EnemyAttack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (enemyAttack != null)
            {
                enemyAttack.Attack();
            }
        }
    }
}
