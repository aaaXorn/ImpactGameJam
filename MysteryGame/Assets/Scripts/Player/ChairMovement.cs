using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ChairMovement : MonoBehaviour
    {
        [Tooltip("Rotation speed.")]
        [SerializeField] float _rotSpd;
        [Tooltip("Maximum X and Z rotation.")]
        [SerializeField] float _max_rot;
        [Tooltip("Speed which the X and Z rotation return to 0.")]
        [SerializeField] float _clampRotSpd;

        //used in Update()
        public void RotateChair(float h_input)
        {
            //rotates the player object
            Vector3 rot_dir = new Vector3(0, h_input * _rotSpd * Time.deltaTime, 0);
            transform.Rotate(rot_dir);
        }

        //stops the chair from flipping over
        public void ClampRotation()
        {
            //current rotations
            float rotX = transform.eulerAngles.x;
            float rotZ = transform.eulerAngles.z;

            //if the target rotation is 0 (true) or 360 (false)
            bool toZeroX = (rotX < 180f);
            bool toZeroZ = (rotZ < 180f);

            //if the rotation needs clamping
            bool clampX = (rotX > _max_rot && rotX < (360f - _max_rot));
            bool clampZ = (rotZ > _max_rot && rotZ < (360f - _max_rot));
            if(clampX || clampZ)
            {
                //clamps the rotation to _max_rot or 360 - _max_rot (which is the equivalent of -_max_rot)
                if(clampX)
                    rotX = toZeroX ? _max_rot : (360f - _max_rot);
                if(clampZ)
                    rotZ = toZeroZ ? _max_rot : (360f - _max_rot);
            }

            //gradually rotates the chair back to 0
            rotX = Mathf.MoveTowards(rotX, (toZeroX ? 0 : 360), _clampRotSpd * Time.deltaTime);
            rotZ = Mathf.MoveTowards(rotZ, (toZeroZ ? 0 : 360), _clampRotSpd * Time.deltaTime);

            print("X " + rotX + " Z " + rotZ);
            //applies the new rotation
            transform.eulerAngles = new Vector3(rotX, transform.eulerAngles.y, rotZ);
        }

        /*
        //wheelchair grounded check (unused)

        [Tooltip("Where each grounded check raycast will begin.")]
        [SerializeField] Transform[] _isGroundedTransf;
        [Tooltip("Distance of the grounded check raycast.")]
        [SerializeField] float _isGroundedRC_dist;
        //layers the IsGrounded raycast will check
        LayerMask _isGroundedLM;

        void Start()
        {
            //all but layer 3 (Player)
            _isGroundedLM = ~(1 << 3);
        }

        //checks if the wheelchair is grounded using raycasts
        public bool IsGrounded()
        {
            foreach(Transform transf in _isGroundedTransf)
            {
                Ray ray = new Ray(transf.position, -transform.up);

                if(Physics.Raycast(ray, _isGroundedRC_dist, _isGroundedLM))
                    return true;
            }

            return false;
        }

        private void OnDrawGizmosSelected()
        {
            //draws the IsGrounded raycasts on the editor
            foreach(Transform transf in _isGroundedTransf)
                Debug.DrawRay(transf.position, -transform.up * _isGroundedRC_dist, Color.blue);
        }
        */
    }
}