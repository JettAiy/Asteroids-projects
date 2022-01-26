using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GAME
{
    public class StartNewGameButton : MonoBehaviour
    {

        [SerializeField] private GameManager _gameManager;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _gameManager.StartGame();
        }
    }
}
