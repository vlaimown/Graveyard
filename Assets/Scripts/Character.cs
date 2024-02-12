using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _attackForce;
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {

    }

    protected virtual void Move() { }
    protected virtual void Attack() { }
}
