using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Hiramesaurus.Minerva
{
    public abstract class GlobalValue<T> : GlobalValueBase
        where T : unmanaged, IEquatable<T>
    {
        public T InitialValue;
        public T RuntimeValue;

        public override void Reset () => RuntimeValue = InitialValue;

        public override bool IsInitialValue ()
        {
            return InitialValue.Equals (RuntimeValue);
        }
        
        public override string RawValueString ()
        {
            return RuntimeValue.ToString ();
        }
        
        public override string RuntimeValueToString () =>  RuntimeValue.ToString ();

        public override string InitialValueToString () => InitialValue.ToString ();
        
        public override bool StringValueEquals (string value)
        {
            return string.CompareOrdinal (RawValueString (), value) == 0;
        }
             
        public override bool StringValueIsNot (string value)
        {
            return string.CompareOrdinal (RawValueString (), value) != 0;
        }
        
        public override bool StringValueIsGreater (string value)
        {
            return string.CompareOrdinal (RawValueString (), value) > 0;
        }
        
        public override bool StringValueIsLess (string value)
        {
            return string.CompareOrdinal (RawValueString (), value) < 0;
        }

        
        public static bool operator == (GlobalValue<T> a, GlobalValue<T> b)
        {        
            if (ReferenceEquals (a, null) || ReferenceEquals (b, null))
            {
                return false;
            }
            return EqualityComparer<T>.Default.Equals (a.RuntimeValue, b.RuntimeValue);
        }

        public static bool operator != (GlobalValue<T> a, GlobalValue<T> b)
        {        
            if (ReferenceEquals (a, null) || ReferenceEquals (b, null))
            {
                return false;
            }
            return !EqualityComparer<T>.Default.Equals (a.RuntimeValue, b.RuntimeValue);
        }
        
        protected bool Equals (GlobalValue<T> other)
        {
            return InitialValue.Equals (other.InitialValue) && RuntimeValue.Equals (other.RuntimeValue);
        }

        public override bool Equals (object other)
        {
            if (ReferenceEquals (null, other)) 
                return false;
            if (ReferenceEquals (this, other))
                return true;
            if (other.GetType () != this.GetType ())
                return false;
            
            return Equals ((GlobalValue<T>) other);
        }

        public override int GetHashCode ()
        {
            unchecked
            {
                var hashCode = base.GetHashCode ();
                hashCode = (hashCode * 397) ^ InitialValue.GetHashCode ();
                hashCode = (hashCode * 571) ^ RuntimeValue.GetHashCode ();
                return hashCode;
            }
        }
        
    }

}
