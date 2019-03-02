using System;
using UnityEditor;
using UnityEngine;

namespace Hiramesaurus.Minerva.GameEvents.Editor
{
    [CustomPropertyDrawer (typeof (GameEventListener))]
    public class GameEventListenerDrawer : PropertyDrawer
    {
        private bool showProperty;
        private float DrawerHeight;

        private SerializedProperty targetProp;     
        private SerializedProperty listenerProp;
        private SerializedProperty handlerProp;
        private SerializedProperty editorToggleProp;

        public override void OnGUI (Rect fullRect, SerializedProperty property, GUIContent label)
        {
            if (targetProp == null || !targetProp.Equals (property))
            {
                targetProp = property;
                listenerProp = property.FindPropertyRelative ("ListenedEvent");
                handlerProp = property.FindPropertyRelative ("EventHandler");
                editorToggleProp = property.FindPropertyRelative ("EnableInEditMode");
            }

            fullRect.y += 8;
            fullRect.height -= 12;
            var lineRect = fullRect;
            lineRect.height = 20;
            var labelSuffix = listenerProp?.objectReferenceValue?.name ?? "(None)";
       
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
            
            var halfRect = lineRect;
            halfRect.width = 65;
            GUI.Label (halfRect, $"{label.text} ->", EditorStyles.label);

            halfRect.x += halfRect.width;
            halfRect.width += lineRect.width - 100;

            var color = GUI.color;
            GUI.color = Color.green;
            GUI.Label (halfRect, labelSuffix, EditorStyles.label);
            GUI.color = color;
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