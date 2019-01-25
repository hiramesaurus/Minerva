using UnityEngine;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Hirame/Globals/Boolean")]
    public sealed class GlobalBool : GlobalValue<bool>
    {
        public void Invert () => RuntimeValue = !RuntimeValue;
        
    }
}
