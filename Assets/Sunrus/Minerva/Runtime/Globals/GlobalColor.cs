using JetBrains.Annotations;
using UnityEngine;

namespace Sunrus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Color")]
    public sealed class GlobalColor : GlobalValue<Color>
    {
        public void Multiply (float multiplier) => RuntimeValue *= multiplier;

        public void Multiply (Color color) => RuntimeValue *= color;
    }
}
