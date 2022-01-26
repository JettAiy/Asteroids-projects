using UnityEngine;
using UnityEngine.InputSystem;

namespace GAME
{
    public class AtackController : MonoBehaviour
    {
        private PlayerInputControl _inputSystem;

        [SerializeField] private Weapon _firstWeapon;
        [SerializeField] private Weapon _secondWeapon;

        private void Awake()
        {
            _inputSystem = new PlayerInputControl();
            _inputSystem.Enable();
        }
   
        private void Update()
        {
            bool fire1 = false;
            bool fire2 = false;

            if (_inputSystem.Player.FireButton.activeControl != null)
            {
                fire1 = _inputSystem.Player.FireButton.activeControl.IsPressed();           
            }

            if (_inputSystem.Player.Fire2Button.activeControl != null)
            {
                fire2 = _inputSystem.Player.Fire2Button.activeControl.IsPressed();
            }

            if (fire1) FireWeaponFirst();
            if (fire2) FireWeaponSecond();

        }


        private void FireWeaponFirst()
        {
            if (_firstWeapon != null)
                _firstWeapon.Fire();
        }

        private void FireWeaponSecond()
        {
            if (_secondWeapon != null)
                _secondWeapon.Fire();
        }


    }
}
