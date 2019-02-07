using System;
using UnityEditor;
using UnityEngine;

namespace Hirame.Minerva.GameEvents.Editor
{
    [CustomPropertyDrawer (typeof (GameEventListener))]
    public class GameEventListenerDrawer : PropertyDrawer
    {
        private bool showProperty;
        private float DrawerHeight;
        
        // TODO:
        // Me no like. Ugly, ugly, UGLY!
        public override void OnGUI (Rect fullRect, SerializedProperty property, GUIContent label)
        {
            var listenerProp = property.FindPropertyRelative ("ListenedEvent");
            var handlerProp = property.FindPropertyRelative ("EventHandler");
            var editorToggleProp = property.FindPropertyRelative ("EnableInEditMode");

            fullRect.y += 8;
            fullRect.height -= 8;
            var lineRect = fullRect;
            lineRect.height = 20;

            if (listenerProp.objectReferenceValue != null)
            {
                var labelSuffix = listenerProp.objectReferenceValue.name;
                label.text = $"{label.text} ({labelSuffix})";
            }
            else
            {
                label.text = $"{label.text} (None)";
            }
           
            
            GUI.Box (fullRect, "");
            GUI.Box (lineRect, "");
            
            var buttonRect = lineRect;
            buttonRect.x += buttonRect.width - 60;
            buttonRect.width = 60;
            buttonRect.height -= 2;

            if (GUI.Button (buttonRect, "Invoke"))
            {
                Debug.Log ("Super cool not yet implemented thing!");
            }

            lineRect.y += 2;
            GUI.Label (lineRect, label, EditorStyles.label);
        
            lineRect.y += 20;
            lineRect.height = 16;

            using (var change = new EditorGUI.ChangeCheckScope ())
            {
                EditorGUI.PropertyField (lineRect, editorToggleProp);

                lineRect.y += 18;
                EditorGUI.PropertyField (lineRect, listenerProp);

                lineRect.y += 18;
                lineRect.height = EditorGUI.GetPropertyHeight (handlerProp);
                EditorGUI.PropertyField (lineRect, handlerProp);

                if (change.changed)
                {
                    property.serializedObject.ApplyModifiedProperties ();
                    EditorUtility.SetDirty (property.serializedObject.targetObject);
                }
            }
        }

        public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
        {
            return 16 + EditorGUI.GetPropertyHeight (property);
        }


    }
}