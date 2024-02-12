using UnityEngine;

public class Player : Character
{
    public bool enableAttack = false;

    protected override void Update()
    {
        if (enableAttack && Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        Debug.Log("Attack");
    }
}
