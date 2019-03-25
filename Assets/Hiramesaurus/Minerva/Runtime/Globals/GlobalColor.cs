using JetBrains.Annotations;
using UnityEngine;

namespace Hiramesaurus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Color")]
    public sealed class GlobalColor : GlobalStruct<Color>
    {
        public void Multiply (float multiplier) => RuntimeValue *= multiplier;

        public void Divide (float divider) => RuntimeValue /= divider;

        public void Multiply (int multiplier) => RuntimeValue *= multiplier;

        public void Divide (int divider) => RuntimeValue /= divider;
    }
}
