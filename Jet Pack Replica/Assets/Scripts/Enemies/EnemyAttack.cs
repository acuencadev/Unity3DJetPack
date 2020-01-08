using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAttack : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        animator.SetTrigger("Shoot");
    }

    public void Attack()
    {
        Debug.Log("Attack!");
    }
}
