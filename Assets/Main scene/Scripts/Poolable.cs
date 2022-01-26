using System.Collections.Generic;
using UnityEngine;

namespace GAME.CORE
{
    public abstract class Poolable<T>: MonoBehaviour where T: Component
    {
        [SerializeField] private Transform _poolbaleContainer;
        [SerializeField] private T _poolbalePrefab;
        [SerializeField] private int _startCount = 5;

        private Queue<T> _queue = new Queue<T>();

        protected virtual void Start()
        {
            for (int i = 0; i < _startCount; i++)
            {
                AddObject();
            }
        }

        private void AddObject()
        {
            var poolableObject = Instantiate(_poolbalePrefab, _poolbaleContainer);
            poolableObject.gameObject.SetActive(false);
            _queue.Enqueue(poolableObject);
        }

        public T Get()
        {
            if (_queue.Count == 0)
            {
                AddObject();
            }
            return _queue.Dequeue();
        }

        public void Return(T poolableObject)
        {
            _queue.Enqueue(poolableObject);
        }
    
    }
}
