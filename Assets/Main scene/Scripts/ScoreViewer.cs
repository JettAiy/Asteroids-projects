using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GAME
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;

        [SerializeField] private TextMeshProUGUI _text;
        
        private void Awake()
        {
            _gameManager.OnScoreChange += GameManagerOnScoreChange;
        }

        private void OnDestroy()
        {
            _gameManager.OnScoreChange -= GameManagerOnScoreChange;
        }

        private void GameManagerOnScoreChange(int score)
        {
            _text.text = $"Score: {score}";
        }
    }
}
