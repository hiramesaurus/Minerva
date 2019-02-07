using UnityEditor;
using UnityEngine;
using Hirame.Minerva.Editor;

namespace Hirame.Minerva.GameEvents.Editor
{
    [CustomEditor (typeof (GameEvent), true)]
    public class GameEventEditor : MinervaEditorBase
    {
        private GameEvent gameEvent;
        
        private SerializedProperty enableStaticEventBool;
        private SerializedProperty staticEvent;
        //private SerializedProperty dynamicListeners;
        
        private void OnEnable ()
        {
            gameEvent = target as GameEvent;
            
            DontDraw ("staticEvent");
            DontDraw ("dynamicListeners");
            
            enableStaticEventBool = serializedObject.FindProperty ("enableStaticEvent");
            staticEvent = serializedObject.FindProperty ("staticEvent");
            //dynamicListeners = serializedObject.FindProperty ("dynamicListeners");
        }

        public override void OnInspectorGUI ()
        {
            using (new GUILayout.HorizontalScope ())
            {
                if (GUILayout.Button ("Raise"))
                {
                    gameEvent.Raise ();
                    return;
                }
            
                if (GUILayout.Button ("Clear"))
                {
                    gameEvent.DynamicListeners.Clear ();
                    return;
                }
            }
          

            using (new GUILayout.VerticalScope (EditorStyles.helpBox))
            {
                var count = gameEvent.DynamicListeners.Count;
                EditorGUILayout.LabelField ($"Dynamic Listeners ({count})", EditorStyles.boldLabel);

                if (count == 0)
                {
                    EditorGUILayout.LabelField ("None", EditorStyles.textArea);
                }

                foreach (var listener in gameEvent.DynamicListeners)
                {
                    GUILayout.Button ("a listener");
                }

            }
            
            using (new GUILayout.VerticalScope (EditorStyles.helpBox))
            {
                EditorGUILayout.PropertyField (enableStaticEventBool);
                
                if (enableStaticEventBool.boolValue)
                    EditorGUILayout.PropertyField (staticEvent);
            }

        }
    }
}
