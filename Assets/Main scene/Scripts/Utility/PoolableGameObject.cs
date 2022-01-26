using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME.CORE
{
    public class PoolableGameObject : MonoBehaviour
    {
        [SerializeField] private Transform _poolbaleContainer;
        [SerializeField] private GameObject _poolbalePrefab;
        [SerializeField] private int _startCount = 5;

        private Queue<GameObject> _queue = new Queue<GameObject>();

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

        public GameObject Get()
        {
            if (_queue.Count == 0)
            {
                AddObject();
            }

            GameObject gameObject = _queue.Dequeue();
            gameObject.SetActive(true);
            return gameObject;
        }

        public void Return(GameObject poolableObject)
        {
            poolableObject.SetActive(false);
            _queue.Enqueue(poolableObject);
        }


        public void ReturnByTime(GameObject poolableObject, float time)
        {
            StartCoroutine(WaitToReturn(poolableObject, time));
        }

        IEnumerator WaitToReturn(GameObject poolableObject, float time)
        {
            yield return new WaitForSeconds(time);
            Return(poolableObject);
        }
    }

}