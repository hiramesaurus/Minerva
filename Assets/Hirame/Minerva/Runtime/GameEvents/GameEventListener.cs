using UnityEngine;
using UnityEngine.Events;

namespace Hirame.Minerva.GameEvents
{
    [System.Serializable]
    public class GameEventListener
    {
        public bool EnableInEditMode;      
        public int ParentInstanceId { get; set; }
        
        [SerializeField]
        internal GameEvent ListenedEvent;
        public UnityEvent EventHandler;

        private void OnEnable ()
        {
            Debug.Log ("asd");
        }

        public void StartListening ()
        {
            if (ListenedEvent != null)
                ListenedEvent.AddListener (this);
        }

        public void StopListening ()
        {
            if (ListenedEvent != null)
                ListenedEvent.RemoveListener (this);
        }
        
        public void OnEventRaised ()
        {
            EventHandler.Invoke ();
        }

        public void Clear ()
        {
            ListenedEvent.RemoveListener (this);
            EventHandler.RemoveAllListeners ();
        }
    }

}