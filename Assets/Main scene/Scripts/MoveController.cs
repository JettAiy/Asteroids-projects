using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class MoveController : MonoBehaviour
    {
        private PlayerInputControl _inputSystem;

        private Vector2 velocity = Vector2.zero;
        private float maxSpeed = 10.0f;
        private float Acceleration = 3f;

        private float rotationSpeed = 100f;

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
        }

        private void Move(Vector2 direction)
        {
            Vector2 dir = direction;
            dir.x = 0;

            if (dir.y > 0)
            {
                velocity = Vector2.Lerp(velocity, transform.right * maxSpeed, Acceleration * Time.deltaTime);         
            }
            else
            {
                // diminishing velocity (air, engine drag what not)
                velocity = Vector2.Lerp(velocity, Vector2.zero, Time.deltaTime);
            }

            // move your transform velocity
            transform.Translate(velocity* Time.deltaTime, Space.World);
   
        }

        private void Rotate(Vector2 direction)
        {

            if (direction.x == 0) return;

            Vector3 rotateTo = new Vector3(0, 0 , -direction.x);
            transform.Rotate(rotateTo * rotationSpeed * Time.deltaTime);
        }
    }
}
