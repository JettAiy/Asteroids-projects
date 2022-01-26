using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class BlasterWeapon : Weapon
    {

        [SerializeField] private Transform _muzzlePoint;
        [SerializeField] private BlasterBullet _prefabBullet;
        [SerializeField] private float _atackSpeed = 5f;


        private float _lastTimeShoot;

        public override void Fire()
        {
            if (Time.time - _lastTimeShoot >= _atackSpeed)
            {
                _lastTimeShoot = Time.time;
                CreateBullet();
            }
        }



        private void CreateBullet()
        {
            BlasterBullet bullet = Instantiate(_prefabBullet, _muzzlePoint.position, _muzzlePoint.rotation);
            bullet.Init(_muzzlePoint.InverseTransformDirection(_muzzlePoint.right));
        }
    }
}
