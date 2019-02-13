using JetBrains.Annotations;
using UnityEngine;

namespace Sunrus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Color")]
    public sealed class GlobalColor : GlobalValue<Color>
    {
        public void Multiply (float multiplier) => Runtime *= multiplier;

        public void Multiply (Color color) => Runtime *= color;
    }
}
