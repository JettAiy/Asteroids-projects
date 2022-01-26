using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 15f;
        private float _rotationSpeed = 150f;

        [SerializeField]  private string _playerTag = "Player";
        private Transform _target;

        [SerializeField] private Weapon _weapon;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _target = GameObject.FindGameObjectWithTag(_playerTag).transform;
        }

        private void Update()
        {
            Move();
            Fire();
        }

        private void Move()
        {
            if (_target == null) return;

            Vector3 _direction = (_target.position - transform.position).normalized;

            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);

            Rotate(_direction);
        }

        private void Rotate(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);
        }

        private void Fire()
        {
            _weapon.Fire();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DeadEvent deadEvent = collision.GetComponent<DeadEvent>();

            if (deadEvent != null)
            {
                deadEvent.Trigger();
                Destroy(gameObject);
            }
        }
    }
}
