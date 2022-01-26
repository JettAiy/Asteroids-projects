using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class LaserWeapon : Weapon
    {
        public event Action<LaserInfoData> OnLaserWeaponChange;

        [SerializeField] private List<Transform> _muzzlePointList;
        [SerializeField] private Bullet _prefabBullet;
        [SerializeField] private float _atackSpeed = 5f;

        [SerializeField] private float _laserAmmoRestoreTime = 3f;
        [SerializeField] private int _laserAmmoMax;
        private int _laserAmmo;
        private float _lastTimeRestoreLaserAmmo;

        private float _lastTimeShoot;

        private float _reloadTimeLeft
        {
            get
            {
                return Time.time - _lastTimeRestoreLaserAmmo;
            }
        }

        private void Start()
        {
            _lastTimeRestoreLaserAmmo = Time.time;
            _laserAmmo = _laserAmmoMax;
        }

        private void Update()
        {
            if (_reloadTimeLeft > _laserAmmoRestoreTime)
            {
                _lastTimeRestoreLaserAmmo = Time.time;

                _laserAmmo++;

                _laserAmmo = Mathf.Clamp(_laserAmmo, 0, _laserAmmoMax);
            }

            RiseEvent();
        }

        public override void Fire()
        {
            if (Time.time - _lastTimeShoot >= _atackSpeed)
            {
                if (_laserAmmo < 1) return;

                _laserAmmo--;

                _lastTimeShoot = Time.time;
                CreateBullet();
            }
        }

        private void CreateBullet()
        {
            foreach (var _muzzlePoint in _muzzlePointList)
            {
                Bullet bullet = Instantiate(_prefabBullet, _muzzlePoint.position, _muzzlePoint.rotation);
                bullet.Init(_muzzlePoint.InverseTransformDirection(_muzzlePoint.right));
            }
        }

        private void RiseEvent()
        {
            LaserInfoData laserInfoData = new LaserInfoData(_laserAmmo, _laserAmmoMax, _laserAmmoRestoreTime - _reloadTimeLeft);

            OnLaserWeaponChange?.Invoke(laserInfoData);
        }
    }

    public struct LaserInfoData
    {
        public int laserAmmoCount;
        public int laserAmmoCountMax;
        public float reloadTimeLeft;

        public LaserInfoData(int laserAmmoCount, int laserAmmoCountMax, float reloadTimeLeft) : this()
        {
            this.laserAmmoCount = laserAmmoCount;
            this.laserAmmoCountMax = laserAmmoCountMax;
            this.reloadTimeLeft = reloadTimeLeft;
        }


    }
}
