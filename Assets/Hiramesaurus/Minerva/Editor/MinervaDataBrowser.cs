using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Hiramesaurus.Minerva.Editor
{
    public class MinervaDataBrowser : EditorWindow
    {
        private List<GlobalValueBase> globals;

        [MenuItem ("Hiramesaurus/Minerva/Data Browser")]
        private static void Open ()
        {
            var window = GetWindow<MinervaDataBrowser> ();
            window.name = "Minerva Browser";
            window.titleContent = new GUIContent("Minerva Browser");
            window.LoadAllGlobals ();
        }
    
        private void OnGUI ()
        {
            EditorGUILayout.LabelField ("Globals");
 
            foreach (var global in globals)
            {
                EditorGUILayout.LabelField (global.name);
            }
        }

        private void LoadAllGlobals ()
        {
            var guids = AssetDatabase.FindAssets ($"t:{nameof(GlobalValueBase)}");

            if (globals == null)
                globals = new List<GlobalValueBase> (guids.Length);
            else
            {
                globals.Clear ();
                if (globals.Capacity < guids.Length)
                    globals.Capacity = guids.Length;
            }
           

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath (guid);
                var asset = AssetDatabase.LoadAssetAtPath<GlobalValueBase> (path);
                globals.Add (asset);
            }
        }
    }

}
