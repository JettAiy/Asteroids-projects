using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GAME
{
    public class LaserWeaponInfoViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _playerTag = "Player";
        private GameObject _player;

        private void Update()
        {
            if (_player == null) FindPlayer();
        }

        private void ShowInfo(LaserInfoData data)
        {
            _text.text = $"laser ammo: {data.laserAmmoCount}/{data.laserAmmoCountMax} reload: {data.reloadTimeLeft.ToString("N1")}";
        }

        private void FindPlayer()
        {
            _player = GameObject.FindGameObjectWithTag(_playerTag);

            if (_player != null)
            {
                LaserWeapon laserWeapon = _player.GetComponentInChildren<LaserWeapon>();

                if (laserWeapon != null) laserWeapon.OnLaserWeaponChange += OnLaserWeaponChange;
            }
        }


        #region EVENTS
        private void OnLaserWeaponChange(LaserInfoData data)
        {
            ShowInfo(data);
        }
        #endregion
    }
}
