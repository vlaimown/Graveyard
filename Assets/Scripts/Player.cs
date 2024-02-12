using UnityEngine;

public class Player : Character
{
    [SerializeField] private bool _enableAttack = false;

    [SerializeField, Min(5f)] private float _attackDistance = 1.0f;

    protected override void Update()
    {
        if (_enableAttack && Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        Debug.Log("Attack");

        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.forward * _attackDistance, Color.red, 100000);

        if (Physics.Raycast(ray, out hit, _attackDistance))
        {
            Debug.Log(hit.transform.gameObject);
        }
    }
}
