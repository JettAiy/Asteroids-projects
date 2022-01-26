using UnityEngine;

namespace GAME
{
    public abstract class Bullet : MonoBehaviour
    {
        public abstract void Init(Vector3 direction);

        protected virtual void OnTriggerEnter2D(Collider2D collision)
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
