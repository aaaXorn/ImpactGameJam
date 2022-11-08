using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputReceiver))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(ArmcrutchMove))]
    [RequireComponent(typeof(CameraArmcrutch))]
    public class ControlArmcrutch : MonoBehaviour
    {
        InputReceiver _input;
        Movement _move;
        ArmcrutchMove _crutchMove;
        CameraArmcrutch _cam;

        LayerMask _chairLM;
        [Tooltip("Distance of the raycast that checks if the player can return to the chair.")]
        [SerializeField] float _chairReturnDist;

        [Tooltip("Wheelchair player object.")]
        [SerializeField] GameObject _objChair;
        InputReceiver _chairInput;
        ControlChair _chairControl;

        [SerializeField] Transform _transf_cam;

        void Awake()
        {
            _input = GetComponent<InputReceiver>();
            _move = GetComponent<Movement>();
            _crutchMove = GetComponent<ArmcrutchMove>();
            _cam = GetComponent<CameraArmcrutch>();

            _chairInput = _objChair.GetComponent<InputReceiver>();
            _chairControl = _objChair.GetComponent<ControlChair>();
        }

        void Start()
        {
            //only layer 6
            _chairLM = (1 << 6);
        }

        void Update()
        {
            if(!_input.isControlled) return;

            _cam.PosAndRot(_input.h_cam);

            _crutchMove.WalkTimer(_input.h_move);

            ReturnToChair();
            _crutchMove.CheckDirection(_input.v_move);
        }

        void FixedUpdate()
        {
            if(!_input.isControlled) return;

            _crutchMove.CrutchMove();
        }

        private void ReturnToChair()
        {
            Ray ray = new Ray(_transf_cam.position, transform.forward);

            //check if the chair is in range
            if(Physics.Raycast(ray, _chairReturnDist, _chairLM))
            {
                //interactable effect

                //move into the chair
                if(_input.swap_move)
                {
                    InputManager.Instance.ChangeReceiver(_chairInput);
                    _chairControl.RayHitboxSetActive(false);
                    gameObject.SetActive(false);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            //draws the ReturnToChair raycast
            Debug.DrawRay(_transf_cam.position, transform.forward * _chairReturnDist, Color.green);
        }
    }
}