using UnityEngine;

namespace Hiramesaurus.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Boolean")]
    public sealed class GlobalBool : GlobalValue<bool>
    {
        public void Invert () => RuntimeValue = !RuntimeValue;
        
    }
}
