using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pickups
{
    public class OutlineHitbox : MonoBehaviour
    {
        [SerializeField] Outline _outline;

        //if the active coroutine is running
        bool _activeIsRunning;
        //current coroutine time
        float _activeTime;
        [Tooltip("Total outline active time.")]
        [SerializeField] float _totalActiveTime;

        [Tooltip("If true, this script's gameObject starts disabled.")]
        [SerializeField] bool _startInactive;

        public UnityEvent PickupEvent;

        void Start()
        {
            _outline.enabled = false;

            if(_startInactive) gameObject.SetActive(false);
        }

        public void AimedAt()
        {
            //resets the timer
            _activeTime = _totalActiveTime;
            //if the coroutine isn't running, start it
            if(!_activeIsRunning) StartCoroutine("ActiveTimer");
        }

        private IEnumerator ActiveTimer()
        {
            //enables the outline
            _activeIsRunning = true;
            _outline.enabled = true;

            //timer
            while(_activeTime >= 0f)
            {
                _activeTime -= 0.1f;

                yield return new WaitForSeconds(0.05f);
            }

            //disables the outline
            _activeIsRunning = false;
            _outline.enabled = false;
        }
    }
}