using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Inputter.Samples
{
    [AddComponentMenu("Inputter/Samples/Inputter Tester"), DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerInput))]
    public class InputterTester : MonoBehaviour
    {
        public float Steering { get; private set; }
        public float Throttle { get; private set; }
        public float Brake { get; private set; }
        public float Clutch { get; private set; }
        public float Handbrake { get; private set; }
        public bool GearUp { get; private set; }
        public bool GearDown { get; private set; }
        public Vector2 Dpad { get; private set; }

        private PlayerInput input;
        private Vector3 angles;

        private void Awake() => input = GetComponent<PlayerInput>();

        private void Start()
        {
            if (LogitechG29.current == null)
                Debug.LogError($"{nameof(LogitechG29)} is null!");
        }

        private void Update()
        {
            if (LogitechG29.current == null)
                return;

            Steering = input.actions["Steering"].ReadValue<float>();
            Throttle = input.actions["Throttle"].ReadValue<float>();
            Brake = input.actions["Brake"].ReadValue<float>();
            Clutch = input.actions["Clutch"].ReadValue<float>();
            Handbrake = input.actions["Handbrake"].ReadValue<float>();
            GearUp = input.actions["Gear up"].WasPerformedThisFrame();
            GearDown = input.actions["Gear Down"].WasPerformedThisFrame();

            angles.Set((Throttle - Brake) * 45f, Steering * 450f, Clutch * 45f); // Use .Set method instead making new Vector3 struct every single frame. Not much performance benefits, but nonetheless performance overall!

            transform.localEulerAngles = angles;

            if (Keyboard.current != null)
            {
                if (Keyboard.current[Key.A].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingCarAirborne)
                        LogitechG29.current.PlayCarAirborne();
                    else
                        LogitechG29.current.StopCarAirborne();
                }

                if (Keyboard.current[Key.C].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingConstantForce)
                        LogitechG29.current.PlayConstantForce(magnitude: 50);
                    else
                        LogitechG29.current.StopConstantForce();
                }

                if (Keyboard.current[Key.S].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingSpringForce)
                        LogitechG29.current.PlaySpringForce(offset: 0, 
                            saturation: 100, coefficient: 50);
                    else
                        LogitechG29.current.StopSpringForce();
                }

                if (Keyboard.current[Key.D].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingDamperForce)
                        LogitechG29.current.PlayDamperForce(coefficient: 50);
                    else
                        LogitechG29.current.StopDamperForce();
                }

                if (Keyboard.current[Key.F].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingSlippyRoadEffect)
                        LogitechG29.current.PlaySoftstopForce(usableRange: 50);
                    else
                        LogitechG29.current.StopSoftstopForce();
                }

                if (Keyboard.current[Key.Q].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingBumpyRoadEffect)
                        LogitechG29.current.PlayBumpyRoadEffect(magnitude: 50);
                    else
                        LogitechG29.current.StopBumpyRoadEffect();
                }

                if (Keyboard.current[Key.W].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingDirtRoadEffect)
                        LogitechG29.current.PlayDirtRoadEffect(magnitude: 50);
                    else
                        LogitechG29.current.StopDirtRoadEffect();
                }

                if (Keyboard.current[Key.E].wasPressedThisFrame)
                {
                    if (LogitechG29.current.IsPlayingSlippyRoadEffect)
                        LogitechG29.current.PlaySlipperyRoadEffect(magnitude: 50);
                    else
                        LogitechG29.current.StopSlipperyRoadEffect();
                }

                if (Keyboard.current[Key.P].wasPressedThisFrame)
                    LogitechG29.current.PlaySideCollisionForce(magnitude: 50);

                if (Keyboard.current[Key.O].wasPressedThisFrame)
                    LogitechG29.current.PlayFontalCollisionForce(magnitude: 50);
            }

            const float MIN_RPM = 0f;
            const float MAX_RPM = 15000f;

            LogitechG29.current.PlayLeds(Throttle * MAX_RPM, MIN_RPM, MAX_RPM);

            if (LogitechG29.current[LogitechG29.G29Button.Plus].wasReleasedThisFrame)
                Debug.Log("Plus!");

            if (LogitechG29.current[LogitechG29.G29Button.LeftStick].wasReleasedThisFrame)
                Debug.Log("LeftStick!");

            if (LogitechG29.current[LogitechG29.G29Button.RightSpin].wasReleasedThisFrame)
                Debug.Log("RightSpin!");

            if (LogitechG29.current[LogitechG29.G29Button.EnterSpin].wasReleasedThisFrame)
                Debug.Log("EnterSpin!");

            if (LogitechG29.current[LogitechG29.G29Button.Options].wasReleasedThisFrame)
                Debug.Log("Options!");

            if (LogitechG29.current[LogitechG29.G29Button.RightBumper]
                .wasReleasedThisFrame)
                Debug.Log("RightBumper!");

            if (LogitechG29.current[LogitechG29.G29Button.North].wasReleasedThisFrame)
                Debug.Log("North!");

            if (LogitechG29.current[LogitechG29.G29Button.East].wasReleasedThisFrame)
                Debug.Log("East!");

            if (LogitechG29.current[LogitechG29.G29Button.West].wasReleasedThisFrame)
                Debug.Log("West!");

            if (LogitechG29.current[LogitechG29.G29Button.South].wasReleasedThisFrame)
                Debug.Log("South!");

            Dpad = LogitechG29.current.hatSwitch.ReadValue();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(InputterTester))]
    public class InputterTesterEditor : UnityEditor.Editor
    {
        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            var data = (InputterTester)target;

            var label = new GUIStyle(EditorStyles.label)
            {
                wordWrap = true,
            };

            EditorGUI.BeginDisabledGroup(disabled: true);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("A [Keyboard] = CarAirborne (Effect)", label);
            EditorGUILayout.LabelField("S [Keyboard] = SpringForce (Effect)", label);
            EditorGUILayout.LabelField("D [Keyboard] = DamperForce (Effect)", label);

            EditorGUILayout.LabelField("C [Keyboard] = ConstantForce (Effect)", label);

            EditorGUILayout.LabelField("F [Keyboard] = SoftstopForce (Effect)", label);

            EditorGUILayout.LabelField("P [Keyboard] = SideCollisionForce (Effect)", label);

            EditorGUILayout.LabelField("O [Keyboard] = FontalCollisionForce (Effect)", label);

            EditorGUILayout.LabelField("Q [Keyboard] = BumpyRoadEffect (Effect)", label);

            EditorGUILayout.LabelField("W [Keyboard] = DirtRoadEffect (Effect)", label);

            EditorGUILayout.LabelField("E [Keyboard] = SlipperyRoadEffect (Effect)", label);

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.Slider("Steering", data.Steering, 
                leftValue: -1f, rightValue: 1f);

            EditorGUILayout.Slider("Throttle", data.Throttle, 
                leftValue: 0f, rightValue: 1f);

            EditorGUILayout.Slider("Brake", data.Brake, 
                leftValue: 0f, rightValue: 1f);

            EditorGUILayout.Slider("Clutch", data.Clutch, 
                leftValue: 0f, rightValue: 1f);

            EditorGUILayout.Slider("Handbrake", data.Handbrake, 
                leftValue: 0f, rightValue: 1f);

            EditorGUILayout.Toggle($"Gear Up", data.GearUp);
            EditorGUILayout.Toggle($"Gear Down", data.GearDown);
            EditorGUILayout.Vector2Field($"Dpad", data.Dpad);

            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();

            base.OnInspectorGUI();
        }
    }
#endif
}
