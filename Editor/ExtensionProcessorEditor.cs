using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Editor;

namespace Inputter
{
    public class ExtensionProcessorEditor : InputParameterEditor<ExtensionProcessor>
    {
        public override void OnGUI()
        {
            var style = new GUIStyle
            {
                normal = new GUIStyleState
                {
                    textColor = Color.grey,
                },
                fontStyle = FontStyle.Italic,
                wordWrap = true,
            };

            EditorGUILayout.LabelField("Note: Action Type must be of Pass Through, in order to work", style);
            EditorGUILayout.Space(10f);

            target.sensitivitySpeed = EditorGUILayout.FloatField("Sensitivity Speed", target.sensitivitySpeed);
            target.gravitySpeed = EditorGUILayout.FloatField("Gravity Speed", target.gravitySpeed);
        }
    }
}