using UnityEngine;

namespace Hiramesaurus.Minerva
{
    public abstract class GlobalValueBase : ScriptableObject
    {
        public bool ResetOnPlay = true;
        
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