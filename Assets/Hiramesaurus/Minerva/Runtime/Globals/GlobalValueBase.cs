using UnityEngine;

namespace Hiramesaurus.Minerva
{
    public abstract class GlobalValueBase : GlobalBase
    {
        public abstract void Add (int value);

        public abstract void Subtract (int value);

        public abstract void Divide (int value);

        public abstract void Multiply (int value);
        
        
        public abstract void Add (float value);
        
        public abstract void Subtract (float value);

        public abstract void Divide (float value);

        public abstract void Multiply (float value);

    }
}