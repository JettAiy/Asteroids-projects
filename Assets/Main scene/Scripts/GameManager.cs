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
        [SerializeField] private GameObject _debrisPrefab;
        [SerializeField] private GameObject _enemyPrefab;

        Vector3 screenBottomLeft;
        Vector3 screenTopRight;

        public int Score { get; private set; }

        [Space]
        [Header("SETTINGS")]
        [SerializeField] private float _asteroidSpawnTime = 10f;
        private float _asteroidLastTimeSpawn;


        [SerializeField] private float _enemySpawnTime = 20f;
        private float _enemyLastTimeSpawn;

        private bool isRunning;
        private bool isQuitting;

        [Space]
        [Header("DEBUG")]
        [SerializeField] private int _asteroidSpawnMin = 3;
        [SerializeField] private int _asteroidSpawnMax = 8;

        [SerializeField] private int _enemySpawnMin = 1;
        [SerializeField] private int _enemySpawnMax = 4;

        private Coroutine _endGameCoroutine;

        #region INIT
        private void Start()
        {
            _uiManager.SwapUI(false);

            Camera cam = Camera.main;

            screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
            screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

            Application.quitting += ApplicationQuitting;
        }

        private void ApplicationQuitting()
        {
            if (_endGameCoroutine != null) StopCoroutine(_endGameCoroutine);

            isQuitting = true;
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

            _asteroidLastTimeSpawn = 0;
            _enemyLastTimeSpawn = 0;
            SetScore(0);

            SpawnPlayer();

            _uiManager.SwapUI(true);

            isRunning = true;

        }

        IEnumerator EndGame()
        {
            isRunning = false;
            ClearScene();
            
            yield return new WaitForSeconds(3f);

            _uiManager.SwapUI(false);
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

                if (Time.time - _enemyLastTimeSpawn >= _enemySpawnTime)
                {
                    _enemyLastTimeSpawn = Time.time;
                    SpawnEnemy();
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
            
            int asteroidCount = UnityEngine.Random.Range(_asteroidSpawnMin, _asteroidSpawnMax);

            for (int i = 0; i < asteroidCount; i++)
            {
                GameObject asteroid = CreateObject(_asteroidPrefab);

                asteroid.GetComponent<DeadEvent>().OnDeadEvent += GameManagerOnDeadEvent;

                Vector3 position = GetRandomPointFromVectors(screenBottomLeft, screenTopRight);
                position.z = 0;
                asteroid.transform.position = position;
            }          
        }

        private void SpawnDebris(GameObject asteroid)
        {
            int debrisCount = UnityEngine.Random.Range(1, 4);

            Vector3 scale = asteroid.transform.localScale / 2;

            for (int i = 0; i < debrisCount; i++)
            {
                GameObject debris = Instantiate(_debrisPrefab, asteroid.transform.parent);
                debris.transform.position = asteroid.transform.position;
                debris.transform.localScale = scale;

                debris.GetComponent<DeadEvent>().OnDeadEvent += GameManagerOnDeadEvent;
            }
        }
        
        private void SpawnEnemy()
        {
            int enemyCount = UnityEngine.Random.Range(_enemySpawnMin, _enemySpawnMax);

            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = CreateObject(_enemyPrefab);

                enemy.GetComponent<DeadEvent>().OnDeadEvent += GameManagerOnDeadEvent;

                Vector3 position = GetRandomPointFromVectors(screenBottomLeft, screenTopRight);
                position.z = 0;
                enemy.transform.position = position;
            }
        }

        #endregion

        #region EVENTS
        private void GameManagerOnDeadEvent(DeadEvent deadEvent)
        {
            if (isQuitting) return;

            deadEvent.OnDeadEvent -= GameManagerOnDeadEvent;

            if (!isRunning) return;

            if (deadEvent.ObjectType == DeadObjectType.PLAYER)
            {
                _endGameCoroutine = StartCoroutine(EndGame());
            }
            else if (deadEvent.ObjectType == DeadObjectType.ASTEROID)
            {
                SpawnDebris(deadEvent.gameObject);
            }

            SetScore(Score + deadEvent.Point);
            
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
