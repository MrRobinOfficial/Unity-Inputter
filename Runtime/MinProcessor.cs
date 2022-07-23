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
    public class MinProcessor : InputProcessor<float>
    {
        public float minValue = 0;

        public override float Process(float value, InputControl control) => Mathf.Min(minValue, value);

#if UNITY_EDITOR
        static MinProcessor() => Initialize();
#endif

        [RuntimeInitializeOnLoadMethod]
        static void Initialize() => InputSystem.RegisterProcessor<MinProcessor>();
    }
}
