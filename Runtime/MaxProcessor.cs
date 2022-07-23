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
    public class MaxProcessor: InputProcessor<float>
    {
        public float maxValue = 0;

        public override float Process(float value, InputControl control) => Mathf.Max(maxValue, value);

#if UNITY_EDITOR
        static MaxProcessor() => Initialize();
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Initialize() => InputSystem.RegisterProcessor<MaxProcessor>();
    }
}
