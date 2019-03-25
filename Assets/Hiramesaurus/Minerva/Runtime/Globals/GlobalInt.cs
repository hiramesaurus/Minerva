using JetBrains.Annotations;
using UnityEngine;

namespace Hiramesaurus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Int")]
    public sealed class GlobalInt : GlobalValue<int>
    {
        public void Increment () => RuntimeValue++;

        public void Decrement () => RuntimeValue--;
        
        public override void Add (float value) => RuntimeValue += (int) value;

        public override void Subtract (float value) => RuntimeValue -= (int) value;

        public override void Multiply (float multiplier) => RuntimeValue = (int) (RuntimeValue * multiplier);

        public override void Divide (float divider) => RuntimeValue = (int) (RuntimeValue / divider);


        public override  void Add (int value) => RuntimeValue += value;

        public override void Subtract (int value) => RuntimeValue -= value;

        public override void Multiply (int multiplier) => RuntimeValue *= multiplier;

        public override void Divide (int divider) => RuntimeValue /= divider;

        
        public void Add (GlobalFloat gFloat) => RuntimeValue += (int) gFloat.RuntimeValue;

        public void Subtract (GlobalFloat gFloat) => RuntimeValue -= (int) gFloat.RuntimeValue;

        public void Multiply (GlobalFloat gFloat) => RuntimeValue = (int) (RuntimeValue * gFloat.RuntimeValue);

        public void Divide (GlobalFloat gFloat) => RuntimeValue = (int) (RuntimeValue / gFloat.RuntimeValue);
        
        
        public void Add (GlobalInt gInt) => RuntimeValue += gInt.RuntimeValue;

        public void Subtract (GlobalInt gInt) => RuntimeValue -= gInt.RuntimeValue;
        
        public void Multiply (GlobalInt gInt) => RuntimeValue *= gInt.RuntimeValue;

        public void Divide (GlobalInt gInt) => RuntimeValue /= gInt.RuntimeValue;
    }
}