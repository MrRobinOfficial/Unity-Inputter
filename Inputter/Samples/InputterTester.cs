using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Inputter.Samples
{
#if UNITY_EDITOR
    [CustomEditor(typeof(InputterTester))]
    public class InputterTesterEditor : UnityEditor.Editor
    {
        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            var data = (InputterTester)target;

            EditorGUI.BeginDisabledGroup(disabled: true);
            EditorGUILayout.Slider("Steering", data.Steering, leftValue: -1f, rightValue: 1f);
            EditorGUILayout.Slider("Throttle", data.Throttle, leftValue: 0f, rightValue: 1f);
            EditorGUILayout.Slider("Brake", data.Brake, leftValue: 0f, rightValue: 1f);
            EditorGUILayout.Slider("Clutch", data.Clutch, leftValue: 0f, rightValue: 1f);
            EditorGUILayout.Slider("Handbrake", data.Handbrake, leftValue: 0f, rightValue: 1f);
            EditorGUILayout.Toggle($"Gear Up", data.GearUp);
            EditorGUILayout.Toggle($"Gear Down", data.GearDown);
            EditorGUILayout.Vector2Field($"Dpad", data.Dpad);

            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();

            base.OnInspectorGUI();
        }
    }
#endif

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

        private void Awake() => input = GetComponent<PlayerInput>();

        private void Update()
        {
            Steering = input.actions["Steering"].ReadValue<float>();
            Throttle = input.actions["Throttle"].ReadValue<float>();
            Brake = input.actions["Brake"].ReadValue<float>();
            Clutch = input.actions["Clutch"].ReadValue<float>();
            Handbrake = input.actions["Handbrake"].ReadValue<float>();
            GearUp = input.actions["Gear up"].WasPerformedThisFrame();
            GearDown = input.actions["Gear Down"].WasPerformedThisFrame();

            const float MIN_RPM = 0f;
            const float MAX_RPM = 15000f;

            if (LogitechG29.current == null)
                return;

            LogitechG29.current.PlayLeds(Throttle * MAX_RPM, MIN_RPM, MAX_RPM);

            if (Keyboard.current[Key.Space].wasPressedThisFrame)
                LogitechG29.current.PlaySideCollisionForce(magnitude: 50);

            if (LogitechG29.current[LogitechG29.G29Button.Plus].wasReleasedThisFrame ||
                LogitechG29.current[LogitechG29.G29Button.LeftStick].wasReleasedThisFrame ||
                LogitechG29.current[LogitechG29.G29Button.RightSpin].wasReleasedThisFrame ||
                LogitechG29.current[LogitechG29.G29Button.EnterSpin].wasReleasedThisFrame ||
                LogitechG29.current[LogitechG29.G29Button.Options].wasReleasedThisFrame ||
                LogitechG29.current[LogitechG29.G29Button.RightBumper].wasReleasedThisFrame)
                Debug.Log("Button!");

            Dpad = LogitechG29.current.dpad.ReadValue();
        }
    } 
}
