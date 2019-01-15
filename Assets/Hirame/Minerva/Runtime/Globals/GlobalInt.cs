using UnityEngine;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Hirame/Globals/Int")]
    public sealed class GlobalInt : GlobalValue<int>
    {

        public void Add (float value)
        {
            RuntimeValue += (int) value;
        }

        public void Subtract (float value)
        {
            RuntimeValue -= (int) value;
        }

        public void Multiply (float multiplier)
        {
            RuntimeValue = (int) (RuntimeValue * multiplier);
        }

        public void Divide (float divider)
        {
            RuntimeValue = (int) (RuntimeValue / divider);
        }
        
        
        public void Add (int value)
        {
            RuntimeValue += value;
        }

        public void Subtract (int value)
        {
            RuntimeValue -= value;
        }

        public void Multiply (int multiplier)
        {
            RuntimeValue *= multiplier;
        }

        public void Divide (int divider)
        {
            RuntimeValue /= divider;
        }
        
    }
}
