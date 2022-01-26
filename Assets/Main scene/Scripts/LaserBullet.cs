using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class LaserBullet : Bullet
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _laserLenght = 10f;
        [SerializeField] private float _liveTime = 2f;
        [SerializeField] private LayerMask _layerMask;

        public override void Init(Vector3 direction)
        {
            transform.parent = null;
            CreateLine();
            Destroy(gameObject, _liveTime);
        }

        private void FixedUpdate()
        {
            CheckCollisions();
        }

        private void CreateLine()
        {
            Vector3[] positions = new Vector3[2];
            positions[0] = transform.position;
            positions[1] = transform.position + (transform.right * _laserLenght);

            _lineRenderer.SetPositions(positions);
        }


        private void CheckCollisions()
        {
            RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, transform.right, _laserLenght, _layerMask);

            foreach (var raycastHit in raycastHits)
            {
                DeadEvent deadEvent = raycastHit.collider.GetComponent<DeadEvent>();

                if (deadEvent != null) deadEvent.Trigger();
            }
        }
    }
}
