using TMPro;
using UnityEngine;

namespace GAME
{
    public class ShipMovementInfoViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _playerTag = "Player";
        private GameObject _player;

        private void Update()
        {
            if (_player == null) FindPlayer();
        }

        private void ShowInfo(ShipMoveInfo data)
        {
            string speedText = Mathf.Abs(data.speed).ToString("N1");

            _text.text = $"X: {data.coords.x.ToString("N1")} Y: {data.coords.y.ToString("N1")} speed: {speedText} angle: {data.angle.ToString("N0")}";
        }

        private void FindPlayer()
        {
            _player = GameObject.FindGameObjectWithTag(_playerTag);

            if (_player != null)
            {
                MoveController moveController = _player.GetComponent<MoveController>();
                moveController.OnShipMoveInfoChange += MoveControllerOnShipMoveInfoChange;
            }
        }

        #region EVENTS
        private void MoveControllerOnShipMoveInfoChange(ShipMoveInfo data)
        {
            ShowInfo(data);
        }

        #endregion
    }
}
