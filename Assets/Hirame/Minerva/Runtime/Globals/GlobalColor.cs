using UnityEngine;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Hirame/Globals/Color")]
    public sealed class GlobalColor : GlobalValue<Color>
    {

        public void Multiply (float multiplier)
        {
            RuntimeValue *= multiplier;
        }
        
        public void Multiply (Color color)
        {
            RuntimeValue *= color;
        }
        
    }
}
