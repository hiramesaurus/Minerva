using UnityEngine;

namespace Hiramesaurus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Float")]
    public sealed class GlobalFloat : GlobalValue<float>
    {
        public void Increment () => RuntimeValue++;

        public void Decrement () => RuntimeValue--;

        public void Invert () => RuntimeValue = 1f / RuntimeValue;

        public override void Add (float value) => RuntimeValue += value;

        public override void Subtract (float value) => RuntimeValue -= value;

        public override void Multiply (float multiplier) => RuntimeValue *= multiplier;

        public override void Divide (float divider) => RuntimeValue /= divider;


        public override void Add (int value) => RuntimeValue += value;

        public override void Subtract (int value) => RuntimeValue -= value;

        public override void Multiply (int multiplier) => RuntimeValue *= multiplier;

        public override void Divide (int divider) => RuntimeValue /= divider;

        
        public void Add (GlobalFloat gFloat) => RuntimeValue += gFloat.RuntimeValue;

        public void Subtract (GlobalFloat gFloat) => RuntimeValue -= gFloat.RuntimeValue;

        public void Multiply (GlobalFloat gFloat) => RuntimeValue *= gFloat.RuntimeValue;

        public void Divide (GlobalFloat gFloat) => RuntimeValue /= gFloat.RuntimeValue;
        

        public void Add (GlobalInt gInt) => RuntimeValue += gInt.RuntimeValue;

        public void Subtract (GlobalInt gInt) => RuntimeValue -= gInt.RuntimeValue;
        
        public void Multiply (GlobalInt gInt) => RuntimeValue *= gInt.RuntimeValue;

        public void Divide (GlobalInt gInt) => RuntimeValue /= gInt.RuntimeValue;
    }
}
