using System;
using UnityEngine;
using GAME.CORE;

namespace GAME
{
    public class DeadEvent : MonoBehaviour
    {
        private PoolableGameObject _poolDeadEffect;
        [SerializeField] private int _point = 0;
        public int Point => _point;

        public event Action<DeadEvent> OnDeadEvent;


        [SerializeField] private DeadObjectType _objectType;
        public DeadObjectType ObjectType => _objectType;

        private void Awake()
        {
            _poolDeadEffect = FindObjectOfType<PoolableGameObject>();
        }

        private void OnDestroy()
        {
            CreateEffect();
            OnDeadEvent?.Invoke(this);
        }

        public void Trigger()
        {
            Destroy(gameObject);
        }

        private void CreateEffect()
        {
            GameObject effect = _poolDeadEffect.Get();
            effect.transform.position = transform.position;
            _poolDeadEffect.ReturnByTime(effect, 3f);
        }
    }

    public enum DeadObjectType
    {
        PLAYER,
        ENEMY,
        ASTEROID,
        DEBRIS
    }
}
