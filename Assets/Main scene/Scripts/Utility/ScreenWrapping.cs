using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GAME
{
    public class ScreenWrapping : MonoBehaviour
    {
        Transform[] ghosts = new Transform[8];

        Renderer[] renderers;
        private Camera cam;
        private Vector3 screenBottomLeft;
        private Vector3 screenTopRight;
        private bool isWrappingX;
        private bool isWrappingY;
        
        private float screenWidth;
        private float screenHeight;


        [SerializeField] private GameObject _prefabGhost;

        void Start()
        {
            renderers = GetComponentsInChildren<SpriteRenderer>();

            cam = Camera.main;

            screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
            screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

            screenWidth = screenTopRight.x - screenBottomLeft.x;
            screenHeight = screenTopRight.y - screenBottomLeft.y;

            CreateGhostShips();
        }

        private void Update()
        {
            //ScreenWrap();
            //
            SwapShips();
            PositionGhostShips();
        }

        bool CheckRenderers()
        {
            foreach (var renderer in renderers)
            {
                // If at least one render is visible, return true
                if (renderer.isVisible)
                {
                    return true;
                }
            }

            // Otherwise, the object is invisible
            return false;
        }

        void ScreenWrap()
        {
            var isVisible = CheckRenderers();

            if (isVisible)
            {
                isWrappingX = false;
                isWrappingY = false;
                return;
            }

            if (isWrappingX && isWrappingY)
            {
                return;
            }

            var viewportPosition = cam.WorldToViewportPoint(transform.position);
            var newPosition = transform.position;

            if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
            {
                newPosition.x = -newPosition.x;

                isWrappingX = true;
            }

            if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
            {
                newPosition.y = -newPosition.y;

                isWrappingY = true;
            }

            transform.position = newPosition;
        }

        void CreateGhostShips()
        {
            for (int i = 0; i < 8; i++)
            {
                ghosts[i] = Instantiate(_prefabGhost, transform).transform;
            }

            PositionGhostShips();
        }

        void PositionGhostShips()
        {
            // All ghost positions will be relative to the ships (this) transform,
            // so let's star with that.
            var ghostPosition = transform.position;

            // We're positioning the ghosts clockwise behind the edges of the screen.
            // Let's start with the far right.
            ghostPosition.x = transform.position.x + screenWidth;
            ghostPosition.y = transform.position.y;
            ghosts[0].position = ghostPosition;

            // Bottom-right
            ghostPosition.x = transform.position.x + screenWidth;
            ghostPosition.y = transform.position.y - screenHeight;
            ghosts[1].position = ghostPosition;

            // Bottom
            ghostPosition.x = transform.position.x;
            ghostPosition.y = transform.position.y - screenHeight;
            ghosts[2].position = ghostPosition;

            // Bottom-left
            ghostPosition.x = transform.position.x - screenWidth;
            ghostPosition.y = transform.position.y - screenHeight;
            ghosts[3].position = ghostPosition;

            // Left
            ghostPosition.x = transform.position.x - screenWidth;
            ghostPosition.y = transform.position.y;
            ghosts[4].position = ghostPosition;

            // Top-left
            ghostPosition.x = transform.position.x - screenWidth;
            ghostPosition.y = transform.position.y + screenHeight;
            ghosts[5].position = ghostPosition;

            // Top
            ghostPosition.x = transform.position.x;
            ghostPosition.y = transform.position.y + screenHeight;
            ghosts[6].position = ghostPosition;

            // Top-right
            ghostPosition.x = transform.position.x + screenWidth;
            ghostPosition.y = transform.position.y + screenHeight;
            ghosts[7].position = ghostPosition;

            // All ghost ships should have the same rotation as the main ship
            for (int i = 0; i < 8; i++)
            {
                ghosts[i].rotation = transform.rotation;
            }
        }

        void SwapShips()
        {
            foreach (var ghost in ghosts)
            {
                if (PointInRect(ghost.transform.position))
                {
                    transform.position = ghost.position;

                    break;
                }
            }
        }

        public bool PointInRect(Vector2 point)
        {
            return point.x > screenBottomLeft.x && point.y > screenBottomLeft.y
                && point.x < screenTopRight.x && point.y < screenTopRight.y;
        }
    }
}
