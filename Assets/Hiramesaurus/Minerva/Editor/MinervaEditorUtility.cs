using Hiramesaurus.Minerva.GameEvents;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Hiramesaurus.Minerva.Editor
{
    public static class MinervaEditorUtility
    {
        [RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.BeforeSceneLoad)]
        internal static void InitReset ()
        {
            ResetGlobalValues (false);
            ResetGameEvents ();
            
            AssetDatabase.SaveAssets ();
            AssetDatabase.Refresh ();
        }
        
        internal static void ResetGlobalValues (bool force)
        {
            foreach (var guid in AssetDatabase.FindAssets ("t:globalValueBase"))
            {
                var path = AssetDatabase.GUIDToAssetPath (guid);
                var global = AssetDatabase.LoadAssetAtPath<GlobalValueBase> (path);
                if (!(global.IsInitialValue () || global.ResetOnPlay || force)) 
                    continue;
 
                global.Reset ();
                EditorUtility.SetDirty (global);
            }
        }

        internal static void ResetGameEvents ()
        {
            foreach (var guid in AssetDatabase.FindAssets ("t:gameEvent"))
            {
                var path = AssetDatabase.GUIDToAssetPath (guid);
                var gameEvent = AssetDatabase.LoadAssetAtPath<GameEvent> (path);
                if (gameEvent.ListenerCount == 0)
                    continue;
                
                gameEvent.ClearDynamicListeners ();
                EditorUtility.SetDirty (gameEvent);
            }
        }
    }

    internal class MinervaBuildProcessor : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;
        
        public void OnPreprocessBuild (BuildReport report)
        {
            MinervaEditorUtility.ResetGlobalValues (true);
            MinervaEditorUtility.ResetGameEvents ();
            
            AssetDatabase.SaveAssets ();
            AssetDatabase.Refresh ();
        }
    }
}
