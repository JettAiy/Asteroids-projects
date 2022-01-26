using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class GameManager : MonoBehaviour
    {

        public event Action<int> OnScoreChange;

        [SerializeField] private UIManager _uiManager;

        [SerializeField] private Transform _enviromentContainer;

        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _asteroidPrefab;

        public int Score { get; private set; }

        private float _asteroidSpawnTime = 30f;
        private float _asteroidLastTimeSpawn;
        private bool isRunning;

        #region INIT
        private void Start()
        {
            _uiManager.SwapUI(false);
        }
        #endregion

        #region CORE

        private void ClearScene()
        {
            for (int i = 0; i < _enviromentContainer.childCount; i++)
            {
                Destroy(_enviromentContainer.GetChild(i).gameObject);
            }
        }

        public void StartGame()
        {
            ClearScene();

            SetScore(0);

            SpawnPlayer();

            SpawnAsteroids();

            _uiManager.SwapUI(true);

            isRunning = true;

        }

        private GameObject CreateObject(GameObject prefab)
        {
            return Instantiate(prefab, _enviromentContainer);
        }


        private void Update()
        {
            if (isRunning)
            {
                if (Time.time - _asteroidLastTimeSpawn >= _asteroidSpawnTime)
                {
                    _asteroidLastTimeSpawn = Time.time;
                    SpawnAsteroids();
                }     
            }
        }

        private void SpawnPlayer()
        {
            GameObject player = CreateObject(_playerPrefab);
            player.GetComponent<DeadEvent>().OnDeadEvent += GameManagerOnDeadEvent;
        }

        private void SpawnAsteroids()
        {
            

            Camera cam = Camera.main;

            Vector3 screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
            Vector3 screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));


            int asteroidCount = UnityEngine.Random.Range(3, 9);

            for (int i = 0; i < asteroidCount; i++)
            {
                GameObject asteroid = CreateObject(_asteroidPrefab);

                asteroid.GetComponent<DeadEvent>().OnDeadEvent += GameManagerOnDeadEvent;

                Vector3 position = GetRandomPointFromVectors(screenBottomLeft, screenTopRight);
                position.z = 0;
                asteroid.transform.position = position;
            }
            
        }
        #endregion

        #region EVENTS
        private void GameManagerOnDeadEvent(GameObject go, int points)
        {
            go.GetComponent<DeadEvent>().OnDeadEvent -= GameManagerOnDeadEvent;

            if (points == -1)
            {
                isRunning = false;
                ClearScene();
                //player dead
                _uiManager.SwapUI(false);

            }
            else
            {
                SetScore(Score +points);       
            }
            
        }
        #endregion

        #region UTILS

        private void SetScore(int value)
        {
            Score = value;
            OnScoreChange?.Invoke(Score);
        }

        public static Vector3 GetRandomPointFromVectors(Vector3 vector1, Vector3 vector2)
        {
            float x = UnityEngine.Random.Range(vector1.x, vector2.x);
            float y = UnityEngine.Random.Range(vector1.y, vector2.y);
            float z = UnityEngine.Random.Range(vector1.z, vector2.z);

            return new Vector3(x, y, z);
        }
        #endregion
    }
}
