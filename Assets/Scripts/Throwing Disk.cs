using UnityEngine;

public class ThrowingDisk : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _damage;
    [SerializeField, Min(5f)] private float _speed;
    private void Update()
    {
        Vector3 Ray_start_position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = Camera.main.ScreenPointToRay(Ray_start_position);

        transform.position += ray.direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}
