using UnityEngine;

namespace Hirame.Minerva
{
    [CreateAssetMenu (menuName = "Minerva/Globals/Boolean")]
    public sealed class GlobalBool : GlobalValue<bool>
    {
        public void Invert () => Runtime = !Runtime;
        
    }
}
