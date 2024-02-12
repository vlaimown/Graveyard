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

    public virtual void GetDamage(float damage)
    {
        if (_currentHealth - damage <= 0f)
            Death();
        else
            _currentHealth -= damage;

        Debug.Log(_currentHealth);
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
