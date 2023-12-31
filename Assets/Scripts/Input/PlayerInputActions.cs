//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Settings/Input System/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""3e200e43-97d7-45ff-a804-ee10f54c5643"",
            ""actions"": [
                {
                    ""name"": ""Axes"",
                    ""type"": ""Value"",
                    ""id"": ""8600d84d-fe48-4503-b16d-743791f105ae"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""908ef70c-955c-4716-a8d1-24722ae65993"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""3b8295f2-8499-4359-892f-4a88510579f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""87ad170f-d38a-434f-b28c-795a80f8192d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DashDirection"",
                    ""type"": ""Value"",
                    ""id"": ""aef36bc1-a94a-4205-b5e0-2fc91abd8d6b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PrimaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""fb1abc36-3b08-4c65-99d7-930fd0715925"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondAttack"",
                    ""type"": ""Button"",
                    ""id"": ""6fde6fbd-7f05-4cf2-915a-e1c002e7c9aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenBag"",
                    ""type"": ""Button"",
                    ""id"": ""2ef425e9-7e27-4b22-a2b7-89d346d7879b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d7b988bf-16e0-4e42-ae32-4ea51c47aa24"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7339f357-01ce-477e-90cd-d58e6a6ad24b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""790fb4cd-b40b-4748-a0a6-f94e84fd4a2e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""837759ee-dd31-44f9-a9b9-a2ed684a180e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""18632afb-fe92-4a17-afb3-ab6fc48c3430"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aaaaf50a-cc1b-4c8c-a279-6b5041028320"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""688bfe16-57e4-4c60-a7c4-3e9ad34825b4"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc1913af-20e6-479a-a276-e9d59e5adf9b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7e5b63c-b259-472e-8cec-fc37ac4fcd6e"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6c9a6e8-3fad-4fcd-91cf-f1e34ec6807f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfde90a5-6752-483e-b5d5-2cfc4d7f7236"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f80eecc-35f1-4a0f-8ef2-43d91da735c3"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenBag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Axes = m_GamePlay.FindAction("Axes", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Grab = m_GamePlay.FindAction("Grab", throwIfNotFound: true);
        m_GamePlay_Dash = m_GamePlay.FindAction("Dash", throwIfNotFound: true);
        m_GamePlay_DashDirection = m_GamePlay.FindAction("DashDirection", throwIfNotFound: true);
        m_GamePlay_PrimaryAttack = m_GamePlay.FindAction("PrimaryAttack", throwIfNotFound: true);
        m_GamePlay_SecondAttack = m_GamePlay.FindAction("SecondAttack", throwIfNotFound: true);
        m_GamePlay_OpenBag = m_GamePlay.FindAction("OpenBag", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Axes;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Grab;
    private readonly InputAction m_GamePlay_Dash;
    private readonly InputAction m_GamePlay_DashDirection;
    private readonly InputAction m_GamePlay_PrimaryAttack;
    private readonly InputAction m_GamePlay_SecondAttack;
    private readonly InputAction m_GamePlay_OpenBag;
    public struct GamePlayActions
    {
        private @PlayerInputActions m_Wrapper;
        public GamePlayActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Axes => m_Wrapper.m_GamePlay_Axes;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Grab => m_Wrapper.m_GamePlay_Grab;
        public InputAction @Dash => m_Wrapper.m_GamePlay_Dash;
        public InputAction @DashDirection => m_Wrapper.m_GamePlay_DashDirection;
        public InputAction @PrimaryAttack => m_Wrapper.m_GamePlay_PrimaryAttack;
        public InputAction @SecondAttack => m_Wrapper.m_GamePlay_SecondAttack;
        public InputAction @OpenBag => m_Wrapper.m_GamePlay_OpenBag;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Axes.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAxes;
                @Axes.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAxes;
                @Axes.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAxes;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Grab.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnGrab;
                @Dash.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDash;
                @DashDirection.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDashDirection;
                @DashDirection.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDashDirection;
                @DashDirection.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDashDirection;
                @PrimaryAttack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPrimaryAttack;
                @SecondAttack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSecondAttack;
                @SecondAttack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSecondAttack;
                @SecondAttack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSecondAttack;
                @OpenBag.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenBag;
                @OpenBag.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenBag;
                @OpenBag.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnOpenBag;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Axes.started += instance.OnAxes;
                @Axes.performed += instance.OnAxes;
                @Axes.canceled += instance.OnAxes;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @DashDirection.started += instance.OnDashDirection;
                @DashDirection.performed += instance.OnDashDirection;
                @DashDirection.canceled += instance.OnDashDirection;
                @PrimaryAttack.started += instance.OnPrimaryAttack;
                @PrimaryAttack.performed += instance.OnPrimaryAttack;
                @PrimaryAttack.canceled += instance.OnPrimaryAttack;
                @SecondAttack.started += instance.OnSecondAttack;
                @SecondAttack.performed += instance.OnSecondAttack;
                @SecondAttack.canceled += instance.OnSecondAttack;
                @OpenBag.started += instance.OnOpenBag;
                @OpenBag.performed += instance.OnOpenBag;
                @OpenBag.canceled += instance.OnOpenBag;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnAxes(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnDashDirection(InputAction.CallbackContext context);
        void OnPrimaryAttack(InputAction.CallbackContext context);
        void OnSecondAttack(InputAction.CallbackContext context);
        void OnOpenBag(InputAction.CallbackContext context);
    }
}
