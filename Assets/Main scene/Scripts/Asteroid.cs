using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _speedMin = 5f;
        [SerializeField] private float _speedMax = 15f;

        private Vector3 _direction;
        private float _speed;
        private float _rotationSpeed;

        #region INIT
        private void Start()
        {
            Init();
        }

        private void Init()
        {

            float mass = transform.localScale.x;

            _speed = Random.Range(_speedMin, _speedMax);
            _rotationSpeed = Random.Range(15f/ mass, 60f/ mass);
            _direction = GetRandomVector();
            _direction.z = 0;
        }

        #endregion

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);

            //transform.RotateAround(transform.position, new Vector3(0, 0, -1), _rotationSpeed * Time.deltaTime);
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

        #region UTILS

        

        private Vector3 GetRandomVector()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);

            return new Vector3(x, y, z).normalized;
        }

        #endregion
    }
}
