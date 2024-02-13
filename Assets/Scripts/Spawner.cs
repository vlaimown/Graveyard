using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Enemy> _spawnableEnemies;
    [SerializeField, Min(1f)] private float _maxCooldown;

    private float _currentCooldown;

    private System.Random random = new System.Random();
    private void Start()
    {
        _currentCooldown = _maxCooldown;
    }

    private void Update()
    {
        if (_currentCooldown > 0f)
        {
            _currentCooldown -= Time.deltaTime;
        }
        else
        {
            int randNum = random.Next(0, _spawnableEnemies.Count);
            Instantiate(_spawnableEnemies[randNum], _spawnPoint.position, Quaternion.identity);
            _currentCooldown = _maxCooldown;
        }
    }
}
