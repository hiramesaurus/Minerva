using System.Collections;
using System.Collections.Generic;
using Hiramesaurus.Minerva;
using UnityEngine;

namespace Hiramesaurus.Minerva
{
    public abstract class GlobalStruct<T> : GlobalStructBase
    {
        public T InitialValue;
        public T RuntimeValue;
        
        public override void Reset ()
        {
            RuntimeValue = InitialValue;
        }

        public override string RawValueString ()
        {
            throw new System.NotImplementedException ();
        }

        public override bool StringValueEquals (string value)
        {
            throw new System.NotImplementedException ();
        }

        public override bool StringValueIsGreater (string value)
        {
            throw new System.NotImplementedException ();
        }

        public override bool StringValueIsLess (string value)
        {
            throw new System.NotImplementedException ();
        }

        public override bool StringValueIsNot (string value)
        {
            throw new System.NotImplementedException ();
        }

        public override bool IsInitialValue ()
        {
            throw new System.NotImplementedException ();
        }

        public override string RuntimeValueToString ()
        {
            throw new System.NotImplementedException ();
        }

        public override string InitialValueToString ()
        {
            throw new System.NotImplementedException ();
        }
    }


    public abstract class GlobalStructBase : GlobalBase
    {
    
    }

}