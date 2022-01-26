using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _speed = 15f;
        private Vector3 _direction;

        private void Start()
        {
            _speed = Random.Range(5f, 15f);
            _direction = GetRandomVector();
            _direction.z = 0;
        }

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }


        public static Vector3 GetRandomVector()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);

            return new Vector3(x, y, z).normalized;
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
