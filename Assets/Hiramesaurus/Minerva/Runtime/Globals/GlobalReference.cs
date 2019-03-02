using UnityEngine.Serialization;

namespace Hiramesaurus.Minerva
{
public abstract class GlobalReference<T> : GlobalValueBase
        where T : class
    {
        [FormerlySerializedAs ("Initial")] public T InitialValue;
        [FormerlySerializedAs ("Runtime")] public T RuntimeValue;

        public U GetRuntimeAs<U> () where U : class, T
        {
            return RuntimeValue as U;
        }
        
        public override void Reset () => RuntimeValue = InitialValue;

        public override bool IsInitialValue ()
        {
            return InitialValue == RuntimeValue;
        }

        public override string RawValueString ()
        {
            return RuntimeValue.ToString ();
        }

        public override bool StringValueEquals (string value)
        {
            return false;
        }

        public override bool StringValueIsGreater (string value)
        {
            return false;
        }

        public override bool StringValueIsLess (string value)
        {
            return false;
        }

        public override bool StringValueIsNot (string value)
        {
            return false;
        }
        
        public override string RuntimeValueToString () => RuntimeValue?.ToString () ?? "None (Object)";

        public override string InitialValueToString () => InitialValue?.ToString () ?? "None (Object)";
    }
}
