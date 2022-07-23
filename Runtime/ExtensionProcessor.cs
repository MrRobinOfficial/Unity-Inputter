#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;

namespace Inputter
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    [Preserve]
    public class ExtensionProcessor: InputProcessor<float>
    {
        [Tooltip("Sensitivity Speed")]
        public float sensitivitySpeed = 0;

        [Tooltip("Gravity Speed")]
        public float gravitySpeed = 0;

        [HideInInspector]
        private float previousValue = 0f;

        public override float Process(float value, InputControl control)
        {
            if (value == 0)
                previousValue = Mathf.MoveTowards(previousValue, 0f, gravitySpeed * Time.unscaledDeltaTime);

            previousValue = Mathf.MoveTowards(previousValue, value, sensitivitySpeed * Time.unscaledDeltaTime);
            return previousValue;
        }

#if UNITY_EDITOR
        static ExtensionProcessor() => Initialize();
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Initialize() => InputSystem.RegisterProcessor<ExtensionProcessor>();
    }
}
