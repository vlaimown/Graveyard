using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    #region Attack
    [SerializeField] private bool _enableAttack = false;
    [SerializeField, Min(3f)] private float _attackDistance = 1.0f;
    [SerializeField] private LayerMask _attackLayerMask;
    #endregion

    #region Block
    [SerializeField] private bool _enableBlock;
    [SerializeField, Min(1f)] private float _maxBlockStamina;

    [SerializeField, Min(0.1f)] private float _blockTime;
    [SerializeField, Min(0.1f)] private float _cooldownBlockSpeed;

    [SerializeField] private Image _blockStaminaImg;

    [SerializeField] private Sprite _blockFullSprite;
    [SerializeField] private Sprite _blockBrokenSprite;
    
    private float _currentBlockStamina;

    private bool _isBlocking;
    private bool _blockBroken;
    #endregion

    protected override void Start()
    {
        base.Start();

        _currentBlockStamina = _maxBlockStamina;
    }

    protected override void Update()
    {
        if (_enableAttack && Input.GetButtonDown("Attack"))
        {
            _animator.SetTrigger("Attacking");
        }

        if (_enableBlock && Input.GetButton("Block") && !_blockBroken)
        {
            Block();
        }

        if (Input.GetButtonUp("Block"))
        {
            _isBlocking = false;
            _dontHit = false;
        }

        else if (_enableBlock && !_isBlocking)
        {
            RecoverBlock();
        }

        float sprintRemainingPercent = _currentBlockStamina / _maxBlockStamina;
        _blockStaminaImg.transform.localScale = new Vector3(sprintRemainingPercent, 1f, 1f);
    }

    protected override void Attack()
    {
        Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = Camera.main.ScreenPointToRay(Ray_start_position);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * _attackDistance, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, _attackDistance, _attackLayerMask))
        {
            hit.transform.GetComponent<Enemy>().GetDamage(_attackForce);
        }
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);

        if (!_dontHit)
        {
            _healthBar.fillAmount = _currentHealth / _maxHealth;
        }

        if (_isBlocking)
        {
            _currentBlockStamina -= damage;
        }
    }

    private void Block()
    {
        if (_currentBlockStamina > 0f)
        {
            _isBlocking = true;
            _dontHit = true;
            _currentBlockStamina -= Time.deltaTime * _blockTime;
        }
        else
        {
            _isBlocking = false;
            _blockBroken = true;
            _dontHit = false;
            _currentBlockStamina = 0f;

            _blockStaminaImg.sprite = _blockBrokenSprite;
        }

        Debug.Log($"block : {_currentBlockStamina}");
    }

    private void RecoverBlock()
    {
        if (_currentBlockStamina < _maxBlockStamina)
        {
            _currentBlockStamina += Time.deltaTime * _cooldownBlockSpeed;
        }
        else
        {
            _currentBlockStamina = _maxBlockStamina;

            if (_blockBroken)
            {
                _blockBroken = false;
                _blockStaminaImg.sprite = _blockFullSprite;
            }
        }

        Debug.Log($"recover block : {_currentBlockStamina}");
    }
}
