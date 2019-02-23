using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Hiramesaurus.Minerva.Editor
{
    public class GlobalsEditorUtility : IPreprocessBuildWithReport
    {
        [RuntimeInitializeOnLoadMethod]
        private static void ResetGlobals ()
        {
            ResetGlobals (false);
        }

        public int callbackOrder => 0;
        public void OnPreprocessBuild (BuildReport report)
        {
            ResetGlobals (true);
        }

        public static void ResetGlobals (bool force)
        {
            foreach (var guid in AssetDatabase.FindAssets ("t:globalValueBase"))
            {
                var global = AssetDatabase.LoadAssetAtPath<GlobalValueBase> (AssetDatabase.GUIDToAssetPath (guid));
                if (global.ResetOnPlay)
                    global.Reset ();
            }
        }
    }
}
