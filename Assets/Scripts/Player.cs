using UnityEngine;

public class Player : Character
{
    [SerializeField] private bool _enableAttack = false;

    [SerializeField, Min(5f)] private float _attackDistance = 1.0f;

    [SerializeField] private LayerMask _attackLayerMask;
    protected override void Update()
    {
        if (_enableAttack && Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        //Debug.Log("Attack");

        Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = Camera.main.ScreenPointToRay(Ray_start_position);
        //Vector3 dir = Camera.main.ScreenToWorldPoint(Ray_start_position);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * _attackDistance, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, _attackDistance, _attackLayerMask))
        {
            //hit.transform.GetComponent<Enemy>().GetDamage(_attackForce);
            Debug.Log(hit.transform.gameObject.name);
        }
    }
}
