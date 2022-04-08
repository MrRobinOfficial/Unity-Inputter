using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;
using UnityEngine.Events;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Inputter
{
    [Preserve]
    public struct LogitechG29State : IInputStateTypeInfo
    {
        [InputControl(name = "dpad", layout = "Dpad", usage = "Hatswitch", displayName = "D-Pad", format = "BIT", sizeInBits = 4, bit = 0)]
        [InputControl(name = "southButton", layout = "Button", bit = 6, usages = new string[]
        {
            "PrimaryAction",
            "Submit"
        }, aliases = new string[]
        {
            "a",
            "cross"
        }, displayName = "South Button", shortDisplayName = "A")]
        [InputControl(name = "westButton", layout = "Button", bit = 7, usage = "SecondaryAction", aliases = new string[]
        {
            "x",
            "square"
        }, displayName = "West Button", shortDisplayName = "X")]
        [InputControl(name = "northButton", layout = "Button", bit = 4, aliases = new string[]
        {
            "y",
            "triangle"
        }, displayName = "North Button", shortDisplayName = "Y")]
        [InputControl(name = "eastButton", layout = "Button", bit = 5, usages = new string[]
        {
            "Back",
            "Cancel"
        }, aliases = new string[]
        {
            "b",
            "circle"
        }, displayName = "East Button", shortDisplayName = "B")]
        [InputControl(name = "leftStickPress", layout = "Button", bit = 8, displayName = "Left Stick Press")]
        [InputControl(name = "rightStickPress", layout = "Button", bit = 9, displayName = "Right Stick Press")]
        [InputControl(name = "leftBumper", displayName = "Left Bumper", layout = "Button", bit = 10)]
        [InputControl(name = "rightBumper", displayName = "Right Bumper", layout = "Button", bit = 11)]
        [InputControl(name = "leftTrigger", displayName = "Left Trigger", layout = "Button", bit = 12)]
        [InputControl(name = "rightTrigger", displayName = "Right Trigger", layout = "Button", bit = 13)]
        [InputControl(name = "share", displayName = "Share", layout = "Button", bit = 14)]
        [InputControl(name = "options", displayName = "Options", layout = "Button", bit = 15)]
        [InputControl(name = "home", displayName = "Home", layout = "Button", bit = 16)]
        [InputControl(name = "plus", displayName = "Plus", shortDisplayName = "+", layout = "Button", bit = 17)]
        [InputControl(name = "minus", displayName = "Minus", shortDisplayName = "-", layout = "Button", bit = 18)]
        [InputControl(name = "leftSpin", displayName = "Left Spin", layout = "Button", bit = 19)]
        [InputControl(name = "rightSpin", displayName = "Right Spin", layout = "Button", bit = 20)]
        [InputControl(name = "enterSpin", displayName = "Enter Spin", layout = "Button", bit = 21)]
        public int buttons;

        [InputControl(name = "shifter1", displayName = "Shifter 1", layout = "Button", bit = 0)]
        [InputControl(name = "shifter2", displayName = "Shifter 2", layout = "Button", bit = 1)]
        [InputControl(name = "shifter3", displayName = "Shifter 3", layout = "Button", bit = 2)]
        [InputControl(name = "shifter4", displayName = "Shifter 4", layout = "Button", bit = 3)]
        [InputControl(name = "shifter5", displayName = "Shifter 5", layout = "Button", bit = 4)]
        [InputControl(name = "shifter6", displayName = "Shifter 6", layout = "Button", bit = 5)]
        [InputControl(name = "shifter7", displayName = "Shifter 7", layout = "Button", bit = 6)]
        public int shifter;

        [InputControl(name = "steerAxis", displayName = "Steering", layout = "Axis", parameters = "normalize,normalizeMin=-1,normalizeMax=1,normalizeZero=0,clamp,clampMin=-1,clampMax=1")]
        public short steering;

        [InputControl(name = "throttleAxis", displayName = "Throttle", layout = "Button", format = "SHRT", parameters = "normalize,normalizeMin=1,normalizeMax=-1,normalizeZero=0")]
        public short throttle;

        [InputControl(name = "brakeAxis", displayName = "Brake", layout = "Button", parameters = "normalize,normalizeMin=1,normalizeMax=-1,normalizeZero=0")]
        public short brake;

        [InputControl(name = "clutchAxis", displayName = "Clutch", layout = "Button", parameters = "normalize,normalizeMin=1,normalizeMax=-1,normalizeZero=0")]
        public short clutch;

        public static FourCC Format => new('H', 'I', 'D');

        public FourCC format => Format;

        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            builder.Append("{Data: ");
            builder.Append($"Steering: {steering}, ");
            builder.Append($"Throttle: {throttle}, ");
            builder.Append($"Brake: {brake}, ");
            builder.Append($"Clutch: {clutch}");
            builder.Append("}");
            return builder.ToString();
        }
    }

    [Preserve]
    [InputControlLayout(displayName = "Logitech G29", stateType = typeof(LogitechG29State), 
        description = "Logitech G29 Racing Wheel with Force Feedback")]
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public sealed class LogitechG29 : InputDevice, IInputUpdateCallbackReceiver
    {
        public static event UnityAction OnInitialized;
        public static event UnityAction OnShutdown;

#pragma warning disable IDE1006 // Naming Styles
        public static LogitechG29 current { get; private set; }

        public static new System.Collections.Generic.IReadOnlyList<LogitechG29> all => s_AllMyDevices;
        private static System.Collections.Generic.List<LogitechG29> s_AllMyDevices = new();

        #region Variables

        public bool IsPlayingSpringForce => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_SPRING);
        public bool IsPlayingDamperForce => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_DAMPER);
        public bool IsPlayingConstantForce => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_CONSTANT);
        public bool IsPlayingSurfaceEffect => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_SURFACE_EFFECT);
        public bool IsPlayingSoftstopForce => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_SOFTSTOP);
        public bool IsPlayingDirtRoadEffect => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_DIRT_ROAD);
        public bool IsPlayingBumpyRoadEffect => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_BUMPY_ROAD);
        public bool IsPlayingCarAirborne => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_CAR_AIRBORNE);
        public bool IsPlayingSlippyRoadEffect => LogitechGSDK.LogiIsPlaying(Index, LogitechGSDK.LOGI_FORCE_SLIPPERY_ROAD);

        public int Index { get; } = 0;
        public bool IsConnected => LogitechGSDK.LogiIsDeviceConnected(Index, LogitechGSDK.LOGI_DEVICE_TYPE_WHEEL);

        //public AnyKeyControl anyButton { get; private set; }
        public ButtonControl northButton { get; private set; }
        public ButtonControl southButton { get; private set; }
        public ButtonControl eastButton { get; private set; }
        public ButtonControl westButton { get; private set; }
        public ButtonControl rightBumper { get; private set; }
        public ButtonControl leftBumper { get; private set; }
        public ButtonControl rightTrigger { get; private set; }
        public ButtonControl leftTrigger { get; private set; }
        public ButtonControl share { get; private set; }
        public ButtonControl options { get; private set; }
        public ButtonControl home { get; private set; }
        public ButtonControl rightStickButton { get; private set; }
        public ButtonControl leftStickButton { get; private set; }
        public ButtonControl plus { get; private set; }
        public ButtonControl minus { get; private set; }
        public ButtonControl rightSpin { get; private set; }
        public ButtonControl leftSpin { get; private set; }
        public ButtonControl enterSpin { get; private set; }

        public DpadControl dpad { get; private set; }

        public ButtonControl shifter1 { get; private set; }
        public ButtonControl shifter2 { get; private set; }
        public ButtonControl shifter3 { get; private set; }
        public ButtonControl shifter4 { get; private set; }
        public ButtonControl shifter5 { get; private set; }
        public ButtonControl shifter6 { get; private set; }
        public ButtonControl shifter7 { get; private set; }

        public AxisControl steering { get; private set; }
        public ButtonControl throttle { get; private set; }
        public ButtonControl brake { get; private set; }
        public ButtonControl clutch { get; private set; }
        public ButtonControl triangleButton => northButton;
        public ButtonControl squareButton => westButton;
        public ButtonControl circleButton => eastButton;
        public ButtonControl crossButton => southButton;

#pragma warning restore IDE1006 // Naming Styles

        #endregion

        public enum G29Button : byte
        {
            South = 0,
            West = 1,
            East = 2,
            North = 3,

            Cross = South,
            Triangle = North,
            Circle = East,
            Square = West,

            RightBumper = 4,
            LeftBumper = 5,
            RightTrigger = 6,
            LeftTrigger = 7,
            Share = 8,
            Options = 9,
            RightStick = 10,
            LeftStick = 11,

            Shifter1 = 12,
            Shifter2 = 13,
            Shifter3 = 14,
            Shifter4 = 15,
            Shifter5 = 16,
            Shifter6 = 17,
            Shifter7 = 18,

            Plus = 19,
            Minus = 20,

            RightSpin = 21,
            LeftSpin = 22,
            EnterSpin = 23,

            Home = 24,

            DpadUp,
            DpadDown,
            DpadLeft,
            DpadRight,
        }

        public ButtonControl this[G29Button button] => button switch
        {
            G29Button.Cross => southButton,
            G29Button.North => northButton,
            G29Button.East => eastButton,
            G29Button.West => westButton,

            G29Button.RightBumper => rightBumper,
            G29Button.LeftBumper => leftBumper,
            G29Button.Options => options,
            G29Button.Share => share,
            G29Button.Home => home,
            G29Button.LeftStick => leftStickButton,
            G29Button.RightStick => rightStickButton,
            G29Button.LeftTrigger => leftTrigger,
            G29Button.RightTrigger => rightTrigger,
            G29Button.Plus => plus,
            G29Button.Minus => minus,

            G29Button.Shifter1 => shifter1,
            G29Button.Shifter2 => shifter2,
            G29Button.Shifter3 => shifter3,
            G29Button.Shifter4 => shifter4,
            G29Button.Shifter5 => shifter5,
            G29Button.Shifter6 => shifter6,
            G29Button.Shifter7 => shifter7,

            G29Button.LeftSpin => leftSpin,
            G29Button.RightSpin => rightSpin,
            G29Button.EnterSpin => enterSpin,

            G29Button.DpadUp => dpad.up,
            G29Button.DpadDown => dpad.down,
            G29Button.DpadLeft => dpad.left,
            G29Button.DpadRight => dpad.right,

            _ => throw new System.ComponentModel.InvalidEnumArgumentException("button", (int)button, typeof(G29Button))
        };

        #region Force Feedback

        public void StopAllForceFeedback()
        {
            if (IsPlayingConstantForce)
                StopConstantForce();
            
            if (IsPlayingDamperForce)
                StopDamperForce();

            if (IsPlayingBumpyRoadEffect)
                StopBumpyRoadEffect();

            if (IsPlayingCarAirborne)
               StopCarAirborne();

            if (IsPlayingDirtRoadEffect)
                StopDirtRoadEffect();

            if (IsPlayingSlippyRoadEffect)
                StopSlipperyRoadEffect();

            if (IsPlayingSoftstopForce)
                StopSoftstopForce();

            if (IsPlayingSpringForce)
                StopSpringForce();

            if (IsPlayingSurfaceEffect)
                StopSurfaceEffect();
        }

        ///<summary>
        /// The dynamic spring force gets played on the X axis. 
        /// If a joystick is connected, all forces generated by the Steering Wheel SDK will be played on the X axis. 
        /// And in addition there will be a constant spring on the Y axis.
        /// </summary>
        /// <param name="offset">Specifies the center of the spring force effect. Valid range is -100 to 100. 
        /// Specifying 0 centers the spring. Any values outside this range are silently clamped.</param>
        /// <param name="saturation">Specify the level of saturation of the spring force effect. 
        /// The saturation stays constant after a certain deflection from the center of the spring. 
        /// It is comparable to a magnitude. Valid ranges are 0 to 100. 
        /// Any value higher than 100 is silently clamped.</param>
        /// <param name="coefficient">Specify the slope of the effect strength increase relative 
        /// to the amount of deflection from the center of the condition. 
        /// Higher values mean that the saturation level is reached sooner. 
        /// Valid ranges are -100 to 100. Any value outside the valid range is silently clamped.</param>
        public bool PlaySpringForce(int offset, int saturation, int coefficient)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlaySpringForce(Index, offset, saturation, coefficient);
        }

        /// <summary>
        /// Stop current spring force
        /// </summary>
        /// <returns></returns>
        public bool StopSpringForce()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopSpringForce(Index);
        }

        /// <summary>
        /// A constant force works best when continuously updated with a value tied to the physics engine. 
        /// Tie the steering wheel/joystick to the car's physics engine via a vector force. 
        /// This will create a centering spring effect, a sliding effect, a feeling for the car's inertia, 
        /// and depending on the physics engine it should also give side collisions 
        /// (wheel/joystick jerks in the opposite way of the wall the car just touched). 
        /// The vector force could for example be calculated from the lateral force measured at the front tires. 
        /// This vector force should be 0 when at a stop or driving straight. 
        /// When driving through a turn or when driving on a banked surface the vector force 
        /// should have a magnitude that grows in a proportional way.
        /// </summary>
        /// <param name="magnitude">Specifies the magnitude of the constant force effect. 
        /// A negative value reverses the direction of the force. 
        /// Valid ranges for magnitudePercentage are -100 to 100. 
        /// Any values outside the valid range are silently clamped.</param>
        /// <returns></returns>
        public bool PlayConstantForce(int magnitude)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlayConstantForce(Index, magnitude);
        }

        /// <summary>
        /// Stop current constant force
        /// </summary>
        /// <returns></returns>
        public bool StopConstantForce()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopConstantForce(Index);
        }

        /// <summary>
        /// Simulate surfaces that are hard to turn on (mud, car at a stop) or slippery surfaces (snow, ice)
        /// </summary>
        /// <param name="coefficient">Specify the slope of the effect strength increase relative 
        /// to the amount of deflection from the center of the condition. 
        /// Higher values mean that the saturation level is reached sooner. 
        /// Valid ranges are -100 to 100. Any value outside the valid range is silently clamped. 
        /// -100 simulates a very slippery effect, +100 makes the wheel/joystick very hard to move, 
        /// simulating the car at a stop or in mud.</param>
        /// <returns></returns>
        public bool PlayDamperForce(int coefficient)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlayDamperForce(Index, coefficient);
        }

        /// <summary>
        /// Stop current damper force
        /// </summary>
        /// <returns></returns>
        public bool StopDamperForce()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopDamperForce(Index);
        }

        /// <summary>
        /// </summary>
        /// <param name="magnitude">: specifies the magnitude of the frontal collision force effect. 
        /// Valid ranges for magnitudePercentage are 0 to 100. 
        /// Values higher than 100 are silently clamped.</param>
        /// <returns></returns>
        public bool PlayFontalCollisionForce(int magnitude)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlayFrontalCollisionForce(Index, magnitude);
        }

        /// <summary>
        /// If you are already using a constant force tied to a vector force from the physics engine, 
        /// then you may not need to add side collisions since depending on your physics 
        /// engine the side collisions may automatically be taken care of by the constant force.
        /// </summary>
        /// <param name="magnitude">Specifies the magnitude of the side collision force effect. 
        /// A negative value reverses the direction of the force. 
        /// Valid ranges for magnitudePercentage are -100 to 100.
        /// Any values outside the valid range are silently clamped.</param>
        /// <returns></returns>
        public bool PlaySideCollisionForce(int magnitude)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlaySideCollisionForce(Index, magnitude);
        }

        /// <summary>
        /// </summary>
        /// <param name="magnitude">Specifies the magnitude of the dirt road effect. 
        /// Valid ranges for magnitudePercentage are 0 to 100. 
        /// Values higher than 100 are silently clamped.</param>
        /// <returns></returns>
        public bool PlayDirtRoadEffect(int magnitude)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlayDirtRoadEffect(Index, magnitude);
        }

        /// <summary>
        /// Stop current dirt-road effect
        /// </summary>
        /// <returns></returns>
        public bool StopDirtRoadEffect()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopDirtRoadEffect(Index);
        }

        /// <summary>
        /// </summary>
        /// <param name="magnitude">Specifies the magnitude of the bumpy road effect. 
        /// Valid ranges for magnitudePercentage are 0 to 100. 
        /// Values higher than 100 are silently clamped.</param>
        /// <returns></returns>
        public bool PlayBumpyRoadEffect(int magnitude)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlayBumpyRoadEffect(Index, magnitude);
        }

        /// <summary>
        /// Stop current bumpy-road effect
        /// </summary>
        /// <returns></returns>
        public bool StopBumpyRoadEffect()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopBumpyRoadEffect(Index);
        }

        /// <summary>
        /// </summary>
        /// <param name="magnitude">Specifies the magnitude of the slippery road effect. 
        /// Valid ranges for magnitudePercentage are 0 to 100. 
        /// 100 corresponds to the most slippery effect.</param>
        /// <returns></returns>
        public bool PlaySlipperyRoadEffect(int magnitude)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlaySideCollisionForce(Index, magnitude);
        }

        /// <summary>
        /// Stop current slippery-road effect
        /// </summary>
        /// <returns></returns>
        public bool StopSlipperyRoadEffect()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopSlipperyRoadEffect(Index);
        }

        public enum SurfaceType
        {
            Sine = 0,
            Square = 1,
            Triangle = 2,
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Specifies the type of force effect.</param>
        /// <param name="magnitude">Specifies the magnitude of the surface effect. 
        /// Valid ranges for magnitudePercentage are 0 to 100. 
        /// Values higher than 100 are silently clamped.</param>
        /// <param name="period">Specifies the period of the periodic force effect. 
        /// The value is the duration for one full cycle of the periodic function measured in milliseconds. 
        /// A good range of values for the period is 20 ms (sand) to 120 ms (wooden bridge or cobblestones). 
        /// For a surface effect the period should not be any bigger than 150 ms.</param>
        /// <returns></returns>
        public bool PlaySurfaceEffect(SurfaceType type, int magnitude, int period)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlaySurfaceEffect(Index, (int)type, magnitude, period);
        }

        /// <summary>
        /// Stop current surface effect
        /// </summary>
        /// <returns></returns>
        public bool StopSurfaceEffect()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopSurfaceEffect(Index);
        }

        public bool PlayCarAirborne()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlayCarAirborne(Index);
        }

        /// <summary>
        /// Stop current airborne effect
        /// </summary>
        /// <returns></returns>
        public bool StopCarAirborne()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopCarAirborne(Index);
        }

        /// <summary>
        /// </summary>
        /// <param name="usableRange">Specifies the deadband in percentage of the softstop force effect.</param>
        /// <returns></returns>
        public bool PlaySoftstopForce(int usableRange)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlaySoftstopForce(Index, usableRange);
        }

        /// <summary>
        /// Stop current soft-stop force
        /// </summary>
        /// <returns></returns>
        public bool StopSoftstopForce()
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiStopSoftstopForce(Index);
        }

        #endregion

        #region Methods

        ///// <summary>
        ///// Set current Logitech Controller's settings
        ///// </summary>
        ///// <param name="propertiesData"></param>
        ///// <returns></returns>
        //public bool SetControllerProperties(LogitechGSDK.LogiControllerPropertiesData propertiesData)
        //{
        //    if (!IsConnected)
        //        return false;

        //    return LogitechGSDK.LogiSetPreferredControllerProperties(propertiesData);
        //}

        ///// <summary>
        ///// Get current Logitech Controller's settings
        ///// </summary>
        ///// <param name="propertiesData"></param>
        ///// <returns></returns>
        //public bool GetControllerProperties(ref LogitechGSDK.LogiControllerPropertiesData propertiesData)
        //{
        //    if (!IsConnected)
        //        return false;

        //    return LogitechGSDK.LogiGetCurrentControllerProperties(Index, ref propertiesData);
        //}

        public enum ShiftType
        {
            Unknown,
            Sequential,
            Gated,
        }

        public ShiftType GetShiftType()
        {
            if (!IsConnected)
                return ShiftType.Unknown;

            int value = LogitechGSDK.LogiGetShifterMode(Index);

            return value switch
            {
                -1 => ShiftType.Unknown,
                0 => ShiftType.Sequential,
                1 => ShiftType.Gated,
                _ => ShiftType.Unknown,
            };
        }

        public string GetDisplayName()
        {
            if (!IsConnected)
                return string.Empty;

            var deviceName = new System.Text.StringBuilder(256);
            LogitechGSDK.LogiGetFriendlyProductName(Index, deviceName, 256);
            return deviceName.ToString();
        }

        /// <summary>
        /// Set current steering wheel range. Prefer (900° degrees)
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool SetOperatingRange(int range)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiSetOperatingRange(Index, range);
        }

        /// <summary>
        /// Get current steering wheel range.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool GetOperatingRange(ref int range)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiGetOperatingRange(Index, ref range);
        }

        /// <summary>
        /// Set current LEDS with RPM parameters
        /// </summary>
        /// <param name="currentRPM"></param>
        /// <param name="rpmMin"></param>
        /// <param name="rpmMax"></param>
        public bool PlayLeds(float currentRPM, float rpmMin, float rpmMax)
        {
            if (!IsConnected)
                return false;

            return LogitechGSDK.LogiPlayLeds(Index, currentRPM, rpmMin, rpmMax);
        }

        #endregion

#if UNITY_EDITOR

        private const string DEBUG_PATH = "Tools/Inputter/Enable Debug Mode";

        [MenuItem(DEBUG_PATH)]
        private static void EnableDebugMode()
        {
            var value = !EditorPrefs.GetBool(DEBUG_PATH);
            EditorPrefs.SetBool(DEBUG_PATH, value);
            Menu.SetChecked(DEBUG_PATH, value);
        }

#endif

        private const bool IGNORE_XINPUT_CONTROLLERS = false;

        public override void MakeCurrent()
        {
            base.MakeCurrent();
            current = this;
        }

        protected override void OnAdded()
        {
            base.OnAdded();
            s_AllMyDevices.Add(this);
        }

        protected override void OnRemoved()
        {
            base.OnRemoved();

            if (current == this)
                current = null;

            s_AllMyDevices.Remove(this);
        }

        protected override void FinishSetup()
        {
            steering = GetChildControl<AxisControl>("steerAxis");
            throttle = GetChildControl<ButtonControl>("throttleAxis");
            brake = GetChildControl<ButtonControl>("brakeAxis");
            clutch = GetChildControl<ButtonControl>("clutchAxis");

            northButton = GetChildControl<ButtonControl>("northButton");
            southButton = GetChildControl<ButtonControl>("southButton");
            eastButton = GetChildControl<ButtonControl>("eastButton");
            westButton = GetChildControl<ButtonControl>("westButton");
            rightBumper = GetChildControl<ButtonControl>("rightBumper");
            leftBumper = GetChildControl<ButtonControl>("leftBumper");
            rightTrigger = GetChildControl<ButtonControl>("rightTrigger");
            leftTrigger = GetChildControl<ButtonControl>("leftTrigger");
            rightStickButton = GetChildControl<ButtonControl>("rightStickPress");
            leftStickButton = GetChildControl<ButtonControl>("leftStickPress");
            share = GetChildControl<ButtonControl>("share");
            options = GetChildControl<ButtonControl>("options");
            home = GetChildControl<ButtonControl>("home");
            plus = GetChildControl<ButtonControl>("plus");
            minus = GetChildControl<ButtonControl>("minus");
            rightSpin = GetChildControl<ButtonControl>("rightSpin");
            leftSpin = GetChildControl<ButtonControl>("leftSpin");
            enterSpin = GetChildControl<ButtonControl>("enterSpin");

            dpad = GetChildControl<DpadControl>("dpad");

            shifter1 = GetChildControl<ButtonControl>("shifter1");
            shifter2 = GetChildControl<ButtonControl>("shifter2");
            shifter3 = GetChildControl<ButtonControl>("shifter3");
            shifter4 = GetChildControl<ButtonControl>("shifter4");
            shifter5 = GetChildControl<ButtonControl>("shifter5");
            shifter6 = GetChildControl<ButtonControl>("shifter6");
            shifter7 = GetChildControl<ButtonControl>("shifter7");

            base.FinishSetup();
        }


#if UNITY_EDITOR
        static LogitechG29() => Init();
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            InputSystem.RegisterLayout<LogitechG29>
            (
                name: "Racing Wheel",
                matches: new InputDeviceMatcher()
                    .WithInterface("HID")
                    .WithManufacturer("Logitech")
                    .WithProduct("G29 Driving Force Racing Wheel")
                    .WithCapability("vendorId", 0x46D)
                    .WithCapability("productId", 0xC24F)
                    .WithCapability("usagePage", 1)
                    //.WithCapability("usage", 4)
                    //.WithVersion("35072")
                    //.WithCapability("usagePage", "GenericDesktop")
            );

            if (!Application.isPlaying)
                return;

            var init = LogitechGSDK.LogiSteeringInitialize(IGNORE_XINPUT_CONTROLLERS);
            Application.quitting += OnQuit;

#if UNITY_EDITOR
            if (EditorPrefs.GetBool(DEBUG_PATH))
                Debug.Log($"Logitech G29 {(init ? "has" : "has not")} been initialized");
#endif

            OnInitialized?.Invoke();
        }

        private static void OnQuit()
        {
            Application.quitting -= OnQuit;

            if (LogitechG29.current != null)
                LogitechG29.current.StopAllForceFeedback();

            LogitechGSDK.LogiSteeringShutdown();

#if UNITY_EDITOR
            if (EditorPrefs.GetBool(DEBUG_PATH))
                Debug.Log("Logitech G29 has been shutdown");
#endif

            OnShutdown?.Invoke();
        }

        public void OnUpdate()
        {
            if (!Application.isPlaying ||
                !LogitechGSDK.LogiIsConnected(Index) ||
                !LogitechGSDK.LogiUpdate())
                return;

            var state = new LogitechG29State();
            var logiState = LogitechGSDK.LogiGetStateCSharp(Index);

            foreach (G29Button key in System.Enum.GetValues(typeof(G29Button)))
                HandleInput(ref state, key);

            const uint DPAD_UP = 0u;
            const uint DPAD_DOWN = 18000u;
            const uint DPAD_LEFT = 27000u;
            const uint DPAD_RIGHT = 9000u;
            const uint DPAD_UP_LEFT = 31500u;
            const uint DPAD_UP_RIGHT = 4500u;
            const uint DPAD_DOWN_LEFT = 22500u;
            const uint DPAD_DOWN_RIGHT = 13500u;

            switch (logiState.rgdwPOV[0])
            {
                case DPAD_UP:
                    state.buttons = SetBit(state.buttons, 0, state: true);
                    break;

                case DPAD_DOWN:
                    state.buttons = SetBit(state.buttons, 1, state: true);
                    break;

                case DPAD_LEFT:
                    state.buttons = SetBit(state.buttons, 2, state: true);
                    break;

                case DPAD_RIGHT:
                    state.buttons = SetBit(state.buttons, 3, state: true);
                    break;

                case DPAD_UP_LEFT:
                    state.buttons = SetBit(state.buttons, 0, state: true);
                    state.buttons = SetBit(state.buttons, 2, state: true);
                    break;

                case DPAD_UP_RIGHT:
                    state.buttons = SetBit(state.buttons, 0, state: true);
                    state.buttons = SetBit(state.buttons, 3, state: true);
                    break;

                case DPAD_DOWN_LEFT:
                    state.buttons = SetBit(state.buttons, 1, state: true);
                    state.buttons = SetBit(state.buttons, 2, state: true);
                    break;

                case DPAD_DOWN_RIGHT:
                    state.buttons = SetBit(state.buttons, 1, state: true);
                    state.buttons = SetBit(state.buttons, 3, state: true);
                    break;
            }

            state.steering = (short)logiState.lX;
            state.throttle = (short)logiState.lY;
            state.brake = (short)logiState.lRz;
            state.clutch = (short)logiState.rglSlider[0];

            InputSystem.QueueStateEvent(this, state);

            //InputState.Change(steering, logiState.lX);
            //InputState.Change(throttle, logiState.lY);
            //InputState.Change(brake, logiState.lRz);
            //InputState.Change(clutch, logiState.rglSlider[0]);

            void HandleInput(ref LogitechG29State state, G29Button button)
            {
                switch (button)
                {
                    case G29Button.North:
                        state.buttons = SetBit(state.buttons, position: 4, LogitechGSDK.LogiButtonReleased(Index, (int)button));
                        break;

                    case G29Button.West:
                        state.buttons = SetBit(state.buttons, position: 7, LogitechGSDK.LogiButtonReleased(Index, (int)button));
                        break;

                    case G29Button.East:
                        state.buttons = SetBit(state.buttons, position: 5, LogitechGSDK.LogiButtonReleased(Index, (int)button));
                        break;

                    case G29Button.South:
                        state.buttons = SetBit(state.buttons, position: 6, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.LeftBumper:
                        state.buttons = SetBit(state.buttons, position: 10, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.RightBumper:
                        state.buttons = SetBit(state.buttons, position: 11, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.LeftTrigger:
                        state.buttons = SetBit(state.buttons, position: 12, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.RightTrigger:
                        state.buttons = SetBit(state.buttons, position: 13, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.LeftStick:
                        state.buttons = SetBit(state.buttons, position: 8, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.RightStick:
                        state.buttons = SetBit(state.buttons, position: 9, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.LeftSpin:
                        state.buttons = SetBit(state.buttons, position: 19, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.RightSpin:
                        state.buttons = SetBit(state.buttons, position: 20, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.EnterSpin:
                        state.buttons = SetBit(state.buttons, position: 21, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Plus:
                        state.buttons = SetBit(state.buttons, position: 17, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Minus:
                        state.buttons = SetBit(state.buttons, position: 18, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Share:
                        state.buttons = SetBit(state.buttons, position: 14, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Options:
                        state.buttons = SetBit(state.buttons, position: 15, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Home:
                        state.buttons = SetBit(state.buttons, position: 16, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Shifter1:
                        state.shifter = SetBit(state.shifter, position: 0, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Shifter2:
                        state.shifter = SetBit(state.shifter, position: 1, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Shifter3:
                        state.shifter = SetBit(state.shifter, position: 2, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Shifter4:
                        state.shifter = SetBit(state.shifter, position: 3, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Shifter5:
                        state.shifter = SetBit(state.shifter, position: 4, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Shifter6:
                        state.shifter = SetBit(state.shifter, position: 5, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;

                    case G29Button.Shifter7:
                        state.shifter = SetBit(state.shifter, position: 6, LogitechGSDK.LogiButtonIsPressed(Index, (int)button));
                        break;
                }
            }

            static int SetBit(int value, int position, bool state) => state ? (value |= (1 << position)) : value & ~(1 << position);
#pragma warning disable CS8321 // Local function is declared but never used
            static int SetBitTo1(int value, int position) => value |= (1 << position);
            static int SetBitTo0(int value, int position) => value & ~(1 << position);
#pragma warning restore CS8321 // Local function is declared but never used
        }
    }
}