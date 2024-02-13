using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform _target;

    [SerializeField] protected Transform _attackPoint;
    [SerializeField, Min(1f)] protected float _attackDistance;

    [SerializeField] protected LayerMask _attackLayer;

    protected override void Start()
    {
        base.Start();

        _agent = GetComponent<NavMeshAgent>();
        _target = FindFirstObjectByType<FirstPersonController>().transform;
    }

    protected override void Update()
    {
        Move();
    }

    protected override void Move()
    {
        _agent.destination = _target.position;

        transform.LookAt(_target);

        if (Vector3.Distance(transform.position, _target.position) <= _attackDistance)
        {
            _animator.SetTrigger("Attacking");
        }
    }

    protected override void Attack()
    {
        base.Attack();

        Collider[] colliders = Physics.OverlapSphere(_attackPoint.position, _attackDistance, _attackLayer);

        foreach (Collider collider in colliders)
        {
            collider.GetComponent<Player>().GetDamage(_attackForce);

            Debug.Log("Zombie attack");
        }
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
    }
}