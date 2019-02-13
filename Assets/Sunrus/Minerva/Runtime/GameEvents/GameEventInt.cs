using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunrus.Minerva.GameEvents
{
    [CreateAssetMenu (menuName = "Minerva/Events/Game Event Int")]
    public class GameEventInt : GameEvent<int, GlobalInt>
    {

        public void Raise (int value)
        {
            EventData.Runtime = value;
        }

        public void RaiseIncrementing (int value)
        {
            
        }

        public void RaiseDecrementing (int value)
        {
            
        }
    }

}