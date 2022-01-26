using UnityEngine;

namespace GAME
{
    public class BlasterBullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 15f;
        [SerializeField] private float _liveTime = 4f;
        private Vector3 _direction;

        public void Init(Vector3 direction)
        {
            transform.parent = null;
            _direction = direction;
        }

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);

            _liveTime -= Time.deltaTime;

            if (_liveTime <= 0)
            {
                Destroy(gameObject);
            }
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
