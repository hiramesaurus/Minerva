using UnityEngine;

namespace Hiramesaurus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Boolean")]
    public sealed class GlobalBool : GlobalValue<bool>
    {
        public void Invert () => RuntimeValue = !RuntimeValue;

        public override void Add (float value) { }

        public override void Subtract (float value)  { }

        public override void Multiply (float multiplier) { }

        public override void Divide (float divider)  { }


        public override void Add (int value)  { }

        public override void Subtract (int value)  { }

        public override void Multiply (int multiplier)  { }

        public override void Divide (int divider)  { }
    }
}
