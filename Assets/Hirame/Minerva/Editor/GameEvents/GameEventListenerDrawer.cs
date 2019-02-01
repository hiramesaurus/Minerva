using UnityEditor;
using UnityEngine;

namespace Hirame.Minerva.GameEvents.Editor
{
    //[CustomPropertyDrawer (typeof (GameEventListener))]
    public class GameEventListenerDrawer : PropertyDrawer
    {
        private bool showProperty;
        private float DrawerHeight;
        
        // TODO:
        // Me no like. Ugly, ugly, UGLY!
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
        {
            //EditorGUI.PropertyField (position, property, label);
        }

       // public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
       // {
         //   return 16 + EditorGUI.GetPropertyHeight (property);
        //}

//        void Asd ()
//        {
//            var propertyEditor = UnityEditor.Editor.CreateEditor (property.objectReferenceValue);
//            var indent = EditorGUI.indentLevel;
//            var foldRect = new Rect (position.x, position.y, 16, 16);
//            
//            showProperty = EditorGUI.Foldout (foldRect, showProperty, "", true);
//
//            DrawerHeight = 0;
//            position.height = 16;
//            EditorGUI.PropertyField (position, property);
//            position.y += 20;
//            
//            if (!showProperty || propertyEditor == null)
//                return;
//
//            position.x += 20;
//            position.width -= 40;
//            var so = propertyEditor.serializedObject;
//            so.Update ();
//            var prop = so.GetIterator ();
//
//            prop.NextVisible (true);
//            
//            // HMM this seems redundant...
//            var childDepth = 0;
//            var drawChildren = false;
//            
//            while (prop.NextVisible (true))
//            {
//                if (prop.depth == 0)
//                {
//                    drawChildren = false;
//                    childDepth = 0;
//                }
//
//                if (drawChildren && prop.depth > childDepth)
//                {
//                    continue;
//                }
//
//                var propHeight = EditorGUI.GetPropertyHeight (prop);
//                position.height = propHeight;
//                EditorGUI.indentLevel = indent + prop.depth;
//                
//                if (EditorGUI.PropertyField (position, prop))
//                {
//                    drawChildren = false;
//                }
//                else
//                {
//                    drawChildren = true;
//                    childDepth = prop.depth;
//                }
//
//                position.y += propHeight;
//                DrawerHeight += propHeight;
//            }
//
//            if (GUI.changed)
//            {
//                so.ApplyModifiedProperties ();
//            }
//        }

    }
}