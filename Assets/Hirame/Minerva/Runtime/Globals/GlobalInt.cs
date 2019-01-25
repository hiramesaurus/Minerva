using JetBrains.Annotations;
using UnityEngine;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Hirame/Globals/Int")]
    public sealed class GlobalInt : GlobalValue<int>
    {
        public void Increment () => RuntimeValue++;

        public void Decrement () => RuntimeValue--;
        
        public void Add (float value) => RuntimeValue += (int) value;

        public void Subtract (float value) => RuntimeValue -= (int) value;

        public void Multiply (float multiplier) => RuntimeValue = (int) (RuntimeValue * multiplier);

        public void Divide (float divider) => RuntimeValue = (int) (RuntimeValue / divider);


        public void Add (int value) => RuntimeValue += value;

        public void Subtract (int value) => RuntimeValue -= value;

        public void Multiply (int multiplier) => RuntimeValue *= multiplier;

        public void Divide (int divider) => RuntimeValue /= divider;

        
        public void Add (GlobalFloat gFloat) => RuntimeValue += (int) gFloat.RuntimeValue;

        public void Subtract (GlobalFloat gFloat) => RuntimeValue += (int) gFloat.RuntimeValue;

        public void Multiply (GlobalFloat gFloat) => RuntimeValue = (int) (RuntimeValue * gFloat.RuntimeValue);

        public void Divide (GlobalFloat gFloat) => RuntimeValue = (int) (RuntimeValue / gFloat.RuntimeValue);
        
        
        public void Add (GlobalInt gInt) => RuntimeValue += gInt.RuntimeValue;

        public void Subtract (GlobalInt gInt) => RuntimeValue += gInt.RuntimeValue;
        
        public void Multiply (GlobalInt gInt) => RuntimeValue *= gInt.RuntimeValue;

        public void Divide (GlobalInt gInt) => RuntimeValue /= gInt.RuntimeValue;
    }
}