using UnityEngine;
using UnityEngine.Serialization;

namespace Sunrus.Minerva
{
    public abstract class GlobalValue<T> : GlobalValueBase
        where T : unmanaged
    {
        [FormerlySerializedAs ("InitialValue")] public T Initial;
        [FormerlySerializedAs ("RuntimeValue")] public T Runtime;

        public override void Reset () => Runtime = Initial;

        public override string RuntimeValueToString () =>  Runtime.ToString ();

        public override string InitialValueToString () => Initial.ToString ();
    }
    
    public abstract class GlobalReference<T> : GlobalValueBase
        where T : class
    {
        public T Initial;
        public T Runtime;

        public U GetRuntimeAs<U> () where U : class, T
        {
            return Runtime as U;
        }
        
        public override void Reset () => Runtime = Initial;

        public override string RuntimeValueToString () => Runtime?.ToString () ?? "None (Object)";

        public override string InitialValueToString () => Initial?.ToString () ?? "None (Object)";
    }

    public abstract class GlobalValueBase : ScriptableObject
    {
        public bool ResetOnPlay = true;
        
        public abstract void Reset ();

        public abstract string RuntimeValueToString ();

        public abstract string InitialValueToString ();
    }

}
