using UnityEngine;
using UnityEngine.Serialization;

namespace Hiramesaurus.Minerva
{
    public abstract class GlobalValue<T> : GlobalValueBase
        where T : unmanaged
    {
        [FormerlySerializedAs ("Initial")] public T InitialValue;
        [FormerlySerializedAs ("Runtime")] public T RuntimeValue;

        public override void Reset () => RuntimeValue = InitialValue;

        public override string RuntimeValueToString () =>  RuntimeValue.ToString ();

        public override string InitialValueToString () => InitialValue.ToString ();
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
