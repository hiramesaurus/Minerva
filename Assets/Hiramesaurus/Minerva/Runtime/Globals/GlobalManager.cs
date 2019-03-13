using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hiramesaurus.Minerva
{
    public class GlobalManager : MonoBehaviour
    {
        //private List<> changeTrackedGlobals = new List<GlobalValueBase> ();

        public static GlobalManager Instance { get; private set; }

        public void TrackGlobalChanged<T> (GlobalValue<T> global) where T : unmanaged, IEquatable<T>
        {
            
        }
        
        public void UntrackGlobalChanged<T> (GlobalValue<T> global) where T : unmanaged, IEquatable<T>
        {
            
        }
        
        private void Update ()
        {
//            foreach (var global in changeTrackedGlobals)
//            {
//                global.InvokeChanged ();
//            }
        }

        [RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize ()
        {
            Instance = new GameObject("GlobalsManager").AddComponent<GlobalManager> ();
        }

        private interface IChangeTracker
        {
            
        }
        
        private struct ChangedTracker : IChangeTracker
        {
            
        }
    }

}
