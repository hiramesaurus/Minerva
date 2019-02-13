using UnityEngine;

namespace Sunrus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Float")]
    public sealed class GlobalFloat : GlobalValue<float>
    {
        public void Increment () => Runtime++;

        public void Decrement () => Runtime--;

        public void Invert () => Runtime = 1f / Runtime;

        public void Add (float value) => Runtime += value;

        public void Subtract (float value) => Runtime -= value;

        public void Multiply (float multiplier) => Runtime *= multiplier;

        public void Divide (float divider) => Runtime /= divider;


        public void Add (int value) => Runtime += value;

        public void Subtract (int value) => Runtime -= value;

        public void Multiply (int multiplier) => Runtime *= multiplier;

        public void Divide (int divider) => Runtime /= divider;

        
        public void Add (GlobalFloat gFloat) => Runtime += gFloat.Runtime;

        public void Subtract (GlobalFloat gFloat) => Runtime += gFloat.Runtime;

        public void Multiply (GlobalFloat gFloat) => Runtime *= gFloat.Runtime;

        public void Divide (GlobalFloat gFloat) => Runtime /= gFloat.Runtime;
        

        public void Add (GlobalInt gInt) => Runtime += gInt.Runtime;

        public void Subtract (GlobalInt gInt) => Runtime += gInt.Runtime;
        
        public void Multiply (GlobalInt gInt) => Runtime *= gInt.Runtime;

        public void Divide (GlobalInt gInt) => Runtime /= gInt.Runtime;
    }
}
