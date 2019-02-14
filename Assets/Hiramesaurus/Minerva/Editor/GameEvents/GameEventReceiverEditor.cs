using Hiramesaurus.Minerva.Editor;
using UnityEditor;
using UnityEngine;

namespace Hiramesaurus.Minerva.GameEvents.Editor
{
    [CustomEditor (typeof (GameEventReceiver))]
    public class GameEventReceiverEditor : MinervaEditorBase
    {
        private GameEventReceiver receiver;
        private SerializedProperty ListenerProp;
        
        private void OnEnable ()
        {
            receiver = target as GameEventReceiver;
            if (receiver != null)
                receiver.ConvertToNewListener ();

            ListenerProp = serializedObject.FindProperty ("Listener");
        }

        public override void OnInspectorGUI ()
        {
            EditorGUILayout.PropertyField (ListenerProp, true);
        }
    }
}
