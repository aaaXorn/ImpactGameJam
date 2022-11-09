using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Pickups;

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

        Collider _lastHit;
        OutlineHitbox _outline;

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
            if(!_input.isControlled || Pause._isPaused) return;

            _cam.PosAndRot(_input.h_cam, _input.v_cam);

            _crutchMove.WalkTimer(_input.h_move);

            _crutchMove.CheckDirection(_input.v_move);
        }

        void FixedUpdate()
        {
            if(!_input.isControlled) return;

            _crutchMove.CrutchMove();
        }

        public void ReturnToChair()
        {
            InputManager.Instance.ChangeReceiver(_chairInput);
            _chairControl.ChairRaySetActive(false);
            _chairControl.CrutchRaySetActive(true);
            _crutchMove.ResetBar();
            gameObject.SetActive(false);
        }

        private void OnDrawGizmosSelected()
        {
            //draws the ReturnToChair raycast
            Debug.DrawRay(_transf_cam.position, transform.forward * _chairReturnDist, Color.green);
        }
    }
}