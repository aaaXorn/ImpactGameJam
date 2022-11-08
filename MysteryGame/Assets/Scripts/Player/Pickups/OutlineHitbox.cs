using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pickups
{
    public class OutlineHitbox : MonoBehaviour
    {
        [SerializeField] Outline outline;

        //if the active coroutine is running
        bool _activeIsRunning;
        //current coroutine time
        float _activeTime;
        [Tooltip("Total outline active time.")]
        [SerializeField] float _totalActiveTime;

        public void AimedAt()
        {
            //resets the timer
            _activeTime = _totalActiveTime;
            //if the coroutine isn't running, start it
            if(!_activeIsRunning) StartCoroutine("ActiveTimer");
        }

        private IEnumerator ActiveTimer()
        {
            _activeIsRunning = true;
            //enables the outline
            outline.enabled = true;

            //timer
            while(_activeTime >= 0f)
            {
                _activeTime -= 0.1f;

                yield return new WaitForSeconds(0.1f);
            }

            //disables the outline
            outline.enabled = false;
        }
    }
}