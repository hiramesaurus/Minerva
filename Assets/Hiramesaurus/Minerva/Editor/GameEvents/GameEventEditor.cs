using Hiramesaurus.Minerva.Editor;
using UnityEditor;
using UnityEngine;

namespace Hiramesaurus.Minerva.GameEvents.Editor
{
    [CustomEditor (typeof (GameEvent), true)]
    public class GameEventEditor : MinervaEditorBase
    {
        private GameEvent gameEvent;

        private SerializedProperty enableStaticEventBoolProp;
        private SerializedProperty staticEventProp;
        private SerializedProperty capacityProp;

        private void OnEnable ()
        {
            gameEvent = target as GameEvent;

            DontDraw ("staticEvent");
            DontDraw ("dynamicListeners");

            enableStaticEventBoolProp = serializedObject.FindProperty ("enableStaticEvent");
            staticEventProp = serializedObject.FindProperty ("staticEvent");
            capacityProp = serializedObject.FindProperty ("defaultCapacity");
        }

        public override void OnInspectorGUI ()
        {
            using (var changeScope = new EditorGUI.ChangeCheckScope ())
            {
                using (new GUILayout.VerticalScope (GUI.skin.box))
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
                            gameEvent.ClearDynamicListeners ();
                            serializedObject.ApplyModifiedProperties ();
                            EditorUtility.SetDirty (this);
                            return;
                        }
                    }

                    EditorGUILayout.Space ();

                    EditorGUILayout.IntField ("Capacity", capacityProp.intValue, EditorStyles.label);
                    gameEvent.Logging = (GameEvent.LogFlags) EditorGUILayout.EnumFlagsField ("Logging", gameEvent.Logging);
                }

                using (new GUILayout.VerticalScope (GUI.skin.box))
                {
                    var count = gameEvent.ListenerCount;
                    EditorGUILayout.LabelField ($"Dynamic Listeners ({count.ToString ()})", EditorStyles.boldLabel);

                    if (count == 0)
                    {
                        EditorGUILayout.LabelField ("None", EditorStyles.textArea);
                    }

                    foreach (var listener in gameEvent.DynamicListeners)
                    {
                        using (new GUILayout.HorizontalScope ())
                        {
                            if (listener.Owner)
                            {
                                EditorGUILayout.ObjectField (listener.Owner, typeof (Object), true);
                            }
                            else
                            {
                                EditorGUILayout.LabelField ("None Unity.Object");
                            }
  
                        }
   
                    }

                }

                using (new GUILayout.VerticalScope (GUI.skin.box))
                {
                    EditorGUILayout.PropertyField (enableStaticEventBoolProp);

                    if (enableStaticEventBoolProp.boolValue)
                        EditorGUILayout.PropertyField (staticEventProp);
                }

                if (changeScope.changed)
                {
                    serializedObject.ApplyModifiedProperties ();
                    EditorUtility.SetDirty (this);
                }
            }
        }
    }
}