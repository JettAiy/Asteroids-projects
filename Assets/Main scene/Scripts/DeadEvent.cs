using System;
using UnityEngine;

namespace GAME
{
    public class DeadEvent : MonoBehaviour
    {

        [SerializeField] private int _point = -1;

        public event Action<GameObject, int> OnDeadEvent;


        private void OnDestroy()
        {
            OnDeadEvent?.Invoke(gameObject, _point);
        }

        public void Trigger()
        {
            Destroy(gameObject);
        }
    }
}
