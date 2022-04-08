//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Plugins/Inputter/Samples/NewVehicleControls.inputactions
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

public partial class @NewVehicleControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewVehicleControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NewVehicleControls"",
    ""maps"": [
        {
            ""name"": ""Car"",
            ""id"": ""cab8cc1c-7a5b-4961-b9a4-819c3c59a052"",
            ""actions"": [
                {
                    ""name"": ""Steering"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e12728df-71dc-4aab-9ff9-0c196104bcc2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4cf9542c-0068-4999-b449-ec5fd7a52dee"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""PassThrough"",
                    ""id"": ""925d7cd7-9132-45a7-a347-26d26cbd3791"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Clutch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""93bfd12e-4be3-458e-bf9f-658324f81f85"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Handbrake"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5dc57075-6792-4a0b-8de3-8e9ae8a72805"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gear Up"",
                    ""type"": ""Button"",
                    ""id"": ""b824b790-2bf1-4bf5-914b-b312218cbc0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gear Down"",
                    ""type"": ""Button"",
                    ""id"": ""09d8d063-e267-4ec6-8400-7c157714f644"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Startup"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6f7ff5fa-593a-4953-8f42-a0df0299db06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Test"",
                    ""type"": ""Button"",
                    ""id"": ""4bc17b9a-b3ab-469f-8bae-710816cc1b2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b8feb6ea-1106-4e19-af88-a16fa0d4de28"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": ""Extension(sensitivitySpeed=1,gravitySpeed=5)"",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2bcc43a-dd16-4c1d-a7d1-3c5f5d37fd2d"",
                    ""path"": ""<Racing Wheel>/brakeAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec73f4f8-2ed8-4aed-9246-fabc27c1b5c4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": ""Extension(sensitivitySpeed=5,gravitySpeed=5)"",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3abd3d78-8d94-4a94-8ff5-b22c20e8f88c"",
                    ""path"": ""<Logitech G29>/South Button"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5807112f-395e-420c-b214-3a323076290e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Gear Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""821beae4-c444-4b52-9461-9ab39da9220d"",
                    ""path"": ""<Racing Wheel>/rightBumper"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Gear Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e46295d7-6d1c-46b5-b68f-fed51369fed0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Gear Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7364a20-5c89-4e8a-b6b4-13a596ee3369"",
                    ""path"": ""<Racing Wheel>/leftBumper"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Gear Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e02fb2ba-a6f9-49f4-a1e1-ab977ac70294"",
                    ""path"": ""<Racing Wheel>/steerAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keys"",
                    ""id"": ""3166aa88-8fff-4ddb-a359-efe1423d4532"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Extension(sensitivitySpeed=1.5,gravitySpeed=5)"",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4ea226aa-f4b4-4b71-bbbd-2c79b10f0fe8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5d5778a1-4e11-48b3-92e7-1d1ade3771c8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d82268f6-ea0a-4b52-9efc-d979314cb6ce"",
                    ""path"": ""<Racing Wheel>/clutchAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Clutch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bac623d7-5a26-4ed9-bfbd-696c5bd934ee"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": ""Extension(sensitivitySpeed=1,gravitySpeed=1)"",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Clutch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bdef96e-b25f-42a4-9c4b-f065f62bc9ab"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Startup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48d4ecbc-c328-4610-87fa-bf619cfd4223"",
                    ""path"": ""<Racing Wheel>/enterSpin"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Startup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14bbbf46-8844-438b-9ccd-763cf52f3b84"",
                    ""path"": ""<Racing Wheel>/options"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Test"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dad97d4-81e3-43ab-a085-0f821bf6dba3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": ""Extension(sensitivitySpeed=1,gravitySpeed=5)"",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2932d752-5bff-483d-a3aa-c77591eeb1ad"",
                    ""path"": ""<Racing Wheel>/throttleAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse&Keyboard"",
            ""bindingGroup"": ""Mouse&Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Racing Wheel>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Steering = m_Car.FindAction("Steering", throwIfNotFound: true);
        m_Car_Throttle = m_Car.FindAction("Throttle", throwIfNotFound: true);
        m_Car_Brake = m_Car.FindAction("Brake", throwIfNotFound: true);
        m_Car_Clutch = m_Car.FindAction("Clutch", throwIfNotFound: true);
        m_Car_Handbrake = m_Car.FindAction("Handbrake", throwIfNotFound: true);
        m_Car_GearUp = m_Car.FindAction("Gear Up", throwIfNotFound: true);
        m_Car_GearDown = m_Car.FindAction("Gear Down", throwIfNotFound: true);
        m_Car_Startup = m_Car.FindAction("Startup", throwIfNotFound: true);
        m_Car_Test = m_Car.FindAction("Test", throwIfNotFound: true);
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

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Steering;
    private readonly InputAction m_Car_Throttle;
    private readonly InputAction m_Car_Brake;
    private readonly InputAction m_Car_Clutch;
    private readonly InputAction m_Car_Handbrake;
    private readonly InputAction m_Car_GearUp;
    private readonly InputAction m_Car_GearDown;
    private readonly InputAction m_Car_Startup;
    private readonly InputAction m_Car_Test;
    public struct CarActions
    {
        private @NewVehicleControls m_Wrapper;
        public CarActions(@NewVehicleControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steering => m_Wrapper.m_Car_Steering;
        public InputAction @Throttle => m_Wrapper.m_Car_Throttle;
        public InputAction @Brake => m_Wrapper.m_Car_Brake;
        public InputAction @Clutch => m_Wrapper.m_Car_Clutch;
        public InputAction @Handbrake => m_Wrapper.m_Car_Handbrake;
        public InputAction @GearUp => m_Wrapper.m_Car_GearUp;
        public InputAction @GearDown => m_Wrapper.m_Car_GearDown;
        public InputAction @Startup => m_Wrapper.m_Car_Startup;
        public InputAction @Test => m_Wrapper.m_Car_Test;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Steering.started -= m_Wrapper.m_CarActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnSteering;
                @Throttle.started -= m_Wrapper.m_CarActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnThrottle;
                @Brake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Clutch.started -= m_Wrapper.m_CarActionsCallbackInterface.OnClutch;
                @Clutch.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnClutch;
                @Clutch.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnClutch;
                @Handbrake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnHandbrake;
                @Handbrake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnHandbrake;
                @Handbrake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnHandbrake;
                @GearUp.started -= m_Wrapper.m_CarActionsCallbackInterface.OnGearUp;
                @GearUp.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnGearUp;
                @GearUp.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnGearUp;
                @GearDown.started -= m_Wrapper.m_CarActionsCallbackInterface.OnGearDown;
                @GearDown.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnGearDown;
                @GearDown.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnGearDown;
                @Startup.started -= m_Wrapper.m_CarActionsCallbackInterface.OnStartup;
                @Startup.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnStartup;
                @Startup.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnStartup;
                @Test.started -= m_Wrapper.m_CarActionsCallbackInterface.OnTest;
                @Test.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnTest;
                @Test.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnTest;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Clutch.started += instance.OnClutch;
                @Clutch.performed += instance.OnClutch;
                @Clutch.canceled += instance.OnClutch;
                @Handbrake.started += instance.OnHandbrake;
                @Handbrake.performed += instance.OnHandbrake;
                @Handbrake.canceled += instance.OnHandbrake;
                @GearUp.started += instance.OnGearUp;
                @GearUp.performed += instance.OnGearUp;
                @GearUp.canceled += instance.OnGearUp;
                @GearDown.started += instance.OnGearDown;
                @GearDown.performed += instance.OnGearDown;
                @GearDown.canceled += instance.OnGearDown;
                @Startup.started += instance.OnStartup;
                @Startup.performed += instance.OnStartup;
                @Startup.canceled += instance.OnStartup;
                @Test.started += instance.OnTest;
                @Test.performed += instance.OnTest;
                @Test.canceled += instance.OnTest;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse&Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface ICarActions
    {
        void OnSteering(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnClutch(InputAction.CallbackContext context);
        void OnHandbrake(InputAction.CallbackContext context);
        void OnGearUp(InputAction.CallbackContext context);
        void OnGearDown(InputAction.CallbackContext context);
        void OnStartup(InputAction.CallbackContext context);
        void OnTest(InputAction.CallbackContext context);
    }
}