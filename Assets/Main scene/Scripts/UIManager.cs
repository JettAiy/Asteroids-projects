using UnityEngine;

namespace GAME
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField] private GameObject _startNewGameButton;
        [SerializeField] private GameObject _scoreText;

        public void SwapUI(bool value)
        {
            ShowHideObject(_startNewGameButton, !value);
            ShowHideObject(_scoreText, value);
        }


        private void ShowHideObject(GameObject gameObject, bool value)
        {
            if (gameObject != null)
                gameObject.SetActive(value);
        }

    }
}
