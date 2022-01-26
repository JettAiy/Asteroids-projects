using UnityEngine;

namespace GAME
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _initUI;

        public void SwapUI(bool value)
        {
            ShowHideObject(_gameUI, value);
            ShowHideObject(_initUI, !value);
        }


        private void ShowHideObject(GameObject gameObject, bool value)
        {
            if (gameObject != null)
                gameObject.SetActive(value);
        }

    }
}
