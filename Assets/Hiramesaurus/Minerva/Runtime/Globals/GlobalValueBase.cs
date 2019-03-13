using UnityEditor;
using UnityEngine;

namespace Hiramesaurus.Minerva
{
    public abstract class GlobalValueBase : ScriptableObject
    {
        [System.Flags]
        internal enum GlobalValueSettings { ResetOnPlay = 1, ChangedEvent = 2 }

        [SerializeField]
        internal GlobalValueSettings Settings;
        public event System.Action ValueChanged;

                
        public bool ResetOnPlay => (Settings & GlobalValueSettings.ResetOnPlay) == GlobalValueSettings.ResetOnPlay;

        public bool UseChangeCheck => (Settings & GlobalValueSettings.ChangedEvent) == GlobalValueSettings.ChangedEvent;

        
        internal void InvokeChanged () => ValueChanged?.Invoke ();


        private void OnEnable ()
        {
            #if UNITY_EDITOR
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
                return;
            #endif
            
            if (UseChangeCheck)
            {
                
            }
        }

        public abstract void Reset ();

        public abstract string RawValueString ();
        
        public abstract bool StringValueEquals (string value);

        public abstract bool StringValueIsGreater (string value);

        public abstract bool StringValueIsLess (string value);

        public abstract bool StringValueIsNot (string value);
        
        public abstract bool IsInitialValue ();
        
        public abstract string RuntimeValueToString ();

        public abstract string InitialValueToString ();
    }
}