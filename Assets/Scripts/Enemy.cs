using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform _target;

    protected override void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected override void Update()
    {
        Move();
    }

    protected override void Move()
    {
        _agent.destination = _target.position;
    }

    protected override void GetDamage(float damage)
    {
        base.GetDamage(damage);
    }
}