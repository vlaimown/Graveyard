using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField, Min(25f)] protected float _maxHealth;
    [SerializeField, Min(1f)] protected float _speed;
    [SerializeField, Min(1f)] protected float _attackForce;

    protected float _currentHealth;
    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    protected virtual void Update() { }

    protected virtual void Move() { }
    protected virtual void Attack() { }

    protected virtual void GetDamage(float damage)
    {
        _currentHealth -= damage;
    }
}
