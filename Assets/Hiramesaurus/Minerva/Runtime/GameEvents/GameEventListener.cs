using UnityEngine;
using UnityEngine.Events;

namespace Hiramesaurus.Minerva.GameEvents
{
    [ExecuteAlways]
    public class GameEventListener : MonoBehaviour
    {
        public EventListener Listener;

        private void OnEnable ()
        {
            Listener.StartListening ();
        }

        private void OnDisable ()
        {
            Listener.StopListening ();
        }

        private void OnDestroy ()
        {
            Listener.Clear ();
        }

        private void Reset ()
        {
            Listener = new EventListener (this);
        }
    }
}