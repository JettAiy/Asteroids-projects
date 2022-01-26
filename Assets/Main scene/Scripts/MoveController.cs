using System;
using UnityEngine;

namespace GAME
{
    public class MoveController : MonoBehaviour
    {

        public event Action<ShipMoveInfo> OnShipMoveInfoChange; 

        [SerializeField] private float _maxSpeed = 10.0f;
        [SerializeField] private float _acceleration = 3f;
        [SerializeField] private float _rotationSpeed = 100f;

        private PlayerInputControl _inputSystem;
        private Vector2 _velocity = Vector2.zero;

        private void Awake()
        {
            _inputSystem = new PlayerInputControl();
            _inputSystem.Enable();
        }


        private void Update()
        {
            Vector2 direction = _inputSystem.Player.Move.ReadValue<Vector2>();
            Move(direction);
            Rotate(direction);
            RiseEvent();
        }

        private void Move(Vector2 direction)
        {
            Vector2 dir = direction;
            dir.x = 0;

            if (dir.y > 0)
            {
                _velocity = Vector2.Lerp(_velocity, transform.right * _maxSpeed, _acceleration * Time.deltaTime);         
            }
            else
            {
                // diminishing velocity (air, engine drag what not)
                _velocity = Vector2.Lerp(_velocity, Vector2.zero, Time.deltaTime);
            }

            // move your transform velocity
            transform.Translate(_velocity* Time.deltaTime, Space.World);
   
        }

        private void Rotate(Vector2 direction)
        {

            if (direction.x == 0) return;

            Vector3 rotateTo = new Vector3(0, 0 , -direction.x);
            transform.Rotate(rotateTo * _rotationSpeed * Time.deltaTime);
        }
    
    
        private void RiseEvent()
        {
            ShipMoveInfo shipMoveInfo = new ShipMoveInfo(transform.position, _velocity.y, transform.eulerAngles.z);

            OnShipMoveInfoChange?.Invoke(shipMoveInfo);
        }
    }

    public struct ShipMoveInfo
    {
        public float speed;
        public float angle;
        public Vector2 coords;

        public ShipMoveInfo(Vector2 coords, float speed, float angle)
        {
            this.coords = coords;
            this.speed = speed;
            this.angle = angle;
        }
    }
}
