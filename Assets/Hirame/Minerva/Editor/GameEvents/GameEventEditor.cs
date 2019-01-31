using UnityEditor;
using UnityEngine;

namespace Hirame.Minerva.Editor
{
    [CustomEditor (typeof (GameEvent), true)]
    public class GameEventEditor : MinervaEditorBase
    {
        private GameEvent gameEvent;
        
        private SerializedProperty eventToggleValue;
        private SerializedProperty staticEvent;
        private SerializedProperty dynamicListeners;
        
        private void OnEnable ()
        {
            gameEvent = target as GameEvent;
            
            DontDraw ("staticEvent");
            DontDraw ("dynamicListeners");
            
            eventToggleValue = serializedObject.FindProperty ("enableStaticEvent");
            staticEvent = serializedObject.FindProperty ("staticEvent");
            dynamicListeners = serializedObject.FindProperty ("dynamicListeners");
        }

        public override void OnInspectorGUI ()
        {
            using (new GUILayout.HorizontalScope ())
            {
                if (GUILayout.Button ("Raise"))
                {
                    gameEvent.RaiseEvent ();
                    return;
                }
            
                if (GUILayout.Button ("Clear"))
                {
                    if (dynamicListeners.arraySize == 0)
                        return;
                    
                    dynamicListeners.ClearArray ();
                    serializedObject.ApplyModifiedProperties ();
                    return;
                }
            }
          

            using (new GUILayout.VerticalScope (EditorStyles.helpBox))
            {
                EditorGUILayout.LabelField ("Dynamic Listeners", EditorStyles.boldLabel);
                
                var count = dynamicListeners.arraySize;

                if (count == 0)
                {
                    EditorGUILayout.LabelField ("None", EditorStyles.textArea);
                }

                for (var i = 0; i < count; i++)
                {                   
                    var reference = dynamicListeners.GetArrayElementAtIndex (i).objectReferenceValue;
                    EditorGUILayout.ObjectField (
                        EditorUtility.InstanceIDToObject (reference.GetInstanceID ()), 
                        typeof(Object), 
                        true);
                }

            }
            
            using (new GUILayout.VerticalScope (EditorStyles.helpBox))
            {
                base.OnInspectorGUI ();

                if (eventToggleValue.boolValue)
                    EditorGUILayout.PropertyField (staticEvent);
            }

        }
    }
}
