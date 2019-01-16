using JetBrains.Annotations;
using UnityEngine;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Hirame/Globals/Int")]
    public sealed class GlobalInt : GlobalValue<int>
    {
        [UsedImplicitly]
        public void Increment ()
        {
            RuntimeValue++;
        }

        [UsedImplicitly]
        public void Decrement ()
        {
            RuntimeValue--;
        }
        
        [UsedImplicitly]
        public void Add (float value)
        {
            RuntimeValue += (int) value;
        }

        [UsedImplicitly]
        public void Subtract (float value)
        {
            RuntimeValue -= (int) value;
        }

        [UsedImplicitly]
        public void Multiply (float multiplier)
        {
            RuntimeValue = (int) (RuntimeValue * multiplier);
        }

        [UsedImplicitly]
        public void Divide (float divider)
        {
            RuntimeValue = (int) (RuntimeValue / divider);
        }
        
        
        [UsedImplicitly]
        public void Add (int value)
        {
            RuntimeValue += value;
        }

        [UsedImplicitly]
        public void Subtract (int value)
        {
            RuntimeValue -= value;
        }

        [UsedImplicitly]
        public void Multiply (int multiplier)
        {
            RuntimeValue *= multiplier;
        }

        [UsedImplicitly]
        public void Divide (int divider)
        {
            RuntimeValue /= divider;
        }
        
    }
}
