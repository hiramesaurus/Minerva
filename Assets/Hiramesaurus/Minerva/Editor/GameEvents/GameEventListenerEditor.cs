using Hiramesaurus.Minerva.Editor;
using UnityEditor;
using UnityEngine;

namespace Hiramesaurus.Minerva.GameEvents.Editor
{
    [CustomEditor (typeof (GameEventListener))]
    public class GameEventListenerEditor : MinervaEditorBase
    {
        private GameEventListener listener;
        private SerializedProperty ListenerProp;
        
        private void OnEnable ()
        {
            listener = target as GameEventListener;
            ListenerProp = serializedObject.FindProperty ("Listener");
        }

        public override void OnInspectorGUI ()
        {
            EditorGUILayout.PropertyField (ListenerProp, true);
        }
    }
}
