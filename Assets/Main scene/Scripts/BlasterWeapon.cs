using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class BlasterWeapon : Weapon
    {

        [SerializeField] private List<Transform> _muzzlePointList;
        [SerializeField] private Bullet _prefabBullet;
        [SerializeField] private float _atackSpeed = 5f;
        [SerializeField] private List<ParticleSystem> _fireEffectList;

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
            foreach (var _muzzlePoint in _muzzlePointList)
            {
                Bullet bullet = Instantiate(_prefabBullet, _muzzlePoint.position, _muzzlePoint.rotation);
                bullet.Init(_muzzlePoint.InverseTransformDirection(_muzzlePoint.right));
            }

            foreach (var _fireEffect in _fireEffectList)
            {
                _fireEffect.Play();
            }
        }
    }
}
