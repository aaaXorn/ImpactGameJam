using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Player;

namespace Pickups
{
    public class Interact : MonoBehaviour
    {
        LayerMask _interactLM;

        [SerializeField] float _interactDist;

        Collider _lastHit;

        OutlineHitbox _outline;

        void Start()
        {
            //only layer 8 (interactable)
            _interactLM = (1 << 8);
        }
        
        void Update()
        {
            if(Pause._isPaused) return;

            InteractRay();
        }

        private void InteractRay()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, _interactDist, _interactLM))
            {
                if(_lastHit != hit.collider)
                {
                    _lastHit = hit.collider;
                    _outline = _lastHit.GetComponent<OutlineHitbox>();
                }

                if(_outline != null)
                {
                    _outline.AimedAt();

                    if(Input.GetButtonDown("Interact"))
                    {
                        _outline.PickupEvent?.Invoke();
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            //draws the ReturnToChair raycast
            Debug.DrawRay(transform.position, transform.forward * _interactDist, Color.green);
        }
    }
}