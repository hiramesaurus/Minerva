﻿using UnityEngine;
using UnityEditor;

namespace Hirame.Minerva.Editor
{
    [CustomEditor (typeof (GlobalValueBase), true)]
    public class GlobalValueEditor : MinervaEditorBase
    {
        private GlobalValueBase global;
        private SerializedProperty initialValue;
        private SerializedProperty runtimeValue;
        private SerializedProperty resetBool;

        protected virtual void OnEnable ()
        {
            global = target as GlobalValueBase;   
            
            initialValue = serializedObject.FindProperty ("Initial");
            runtimeValue = serializedObject.FindProperty ("Runtime");
            resetBool = serializedObject.FindProperty ("ResetOnPlay");
        }

        public override void OnInspectorGUI ()
        {
            
            using (var changeScope = new EditorGUI.ChangeCheckScope ())
            {
                using (new GUILayout.VerticalScope (EditorStyles.helpBox))
                {
                    EditorGUILayout.PropertyField (resetBool);
                }
                
                using (new GUILayout.VerticalScope (EditorStyles.helpBox))
                {
                    if (EditorApplication.isPlaying)
                    {
                        EditorGUILayout.PropertyField (initialValue);                  
                        EditorGUILayout.PropertyField (runtimeValue);
                    }
                    else
                    {
                        EditorGUILayout.PropertyField (initialValue);
                        if (changeScope.changed)
                        {
                            serializedObject.ApplyModifiedProperties ();
                            global.Reset ();
                            serializedObject.Update ();
                            return;
                        }
                        EditorGUILayout.TextField (runtimeValue.displayName, global.RuntimeValueToString (), EditorStyles.label);
                    }
                }
                       
                
                if (GUILayout.Button ("Reset"))
                {
                    ResetAndUpdate ();
                }

                if (changeScope.changed)
                {
                    serializedObject.ApplyModifiedProperties ();
                    EditorUtility.SetDirty (this);
                }
            }
        }

        private void ResetAndUpdate ()
        {
            global.Reset ();
            serializedObject.Update ();
            EditorUtility.SetDirty (this);
        }
    }
}