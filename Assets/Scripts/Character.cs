using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField, Min(25f)] protected float _health;
    [SerializeField, Min(1f)] protected float _speed;
    [SerializeField, Min(1f)] protected float _attackForce;
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {

    }

    protected virtual void Move() { }
    protected virtual void Attack() { }
}
