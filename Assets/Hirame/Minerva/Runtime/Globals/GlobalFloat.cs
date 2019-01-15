using UnityEngine;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Hirame/Globals/Float")]
    public sealed class GlobalFloat : GlobalValue<float>
    {

        public void Add (float value)
        {
            RuntimeValue += value;
        }

        public void Subtract (float value)
        {
            RuntimeValue -= value;
        }

        public void Multiply (float multiplier)
        {
            RuntimeValue *= multiplier;
        }

        public void Divide (float divider)
        {
            RuntimeValue /= divider;
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
