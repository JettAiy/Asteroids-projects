// GENERATED AUTOMATICALLY FROM 'Assets/Main scene/Scripts/Control scheme/PlayerInputControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GAME
{
    public class @PlayerInputControl : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputControl()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputControl"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""56f16d2a-4c5b-42c2-9312-577e9ff63836"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a39b4ed0-c0ff-4041-b57a-e7702d9fa6b4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireButton"",
                    ""type"": ""Button"",
                    ""id"": ""5cd05daa-5626-4b7b-b495-725dea0c3506"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire2Button"",
                    ""type"": ""Button"",
                    ""id"": ""66f025b0-27de-40ee-af41-59867f15a4ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7c8c123b-bd9a-43db-90e8-e8cbca976d09"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b109cd21-1579-47f3-bb39-fc43a5140972"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""613d8a3b-05e8-40c8-841e-9ae8fdc21aa9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""60a131bf-4c5e-4a05-878f-34839e3f4c18"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7860f366-5fbc-4bcb-9222-1d7507edf0a7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a6aafb9b-88f9-4bb5-bfde-a6fe361aec6a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""FireButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee21cf45-dd25-4d40-a610-ca11b21af9fa"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire2Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_FireButton = m_Player.FindAction("FireButton", throwIfNotFound: true);
            m_Player_Fire2Button = m_Player.FindAction("Fire2Button", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_FireButton;
        private readonly InputAction m_Player_Fire2Button;
        public struct PlayerActions
        {
            private @PlayerInputControl m_Wrapper;
            public PlayerActions(@PlayerInputControl wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @FireButton => m_Wrapper.m_Player_FireButton;
            public InputAction @Fire2Button => m_Wrapper.m_Player_Fire2Button;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @FireButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireButton;
                    @FireButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireButton;
                    @FireButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFireButton;
                    @Fire2Button.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire2Button;
                    @Fire2Button.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire2Button;
                    @Fire2Button.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire2Button;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @FireButton.started += instance.OnFireButton;
                    @FireButton.performed += instance.OnFireButton;
                    @FireButton.canceled += instance.OnFireButton;
                    @Fire2Button.started += instance.OnFire2Button;
                    @Fire2Button.performed += instance.OnFire2Button;
                    @Fire2Button.canceled += instance.OnFire2Button;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnFireButton(InputAction.CallbackContext context);
            void OnFire2Button(InputAction.CallbackContext context);
        }
    }
}
