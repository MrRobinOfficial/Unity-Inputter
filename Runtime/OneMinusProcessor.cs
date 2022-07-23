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
    public class OneMinusProcessor: InputProcessor<float>
    {
        public override float Process(float value, InputControl control) => 1f - value;

#if UNITY_EDITOR
        static OneMinusProcessor() => Initialize();
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Initialize() => InputSystem.RegisterProcessor<OneMinusProcessor>();
    }
}
