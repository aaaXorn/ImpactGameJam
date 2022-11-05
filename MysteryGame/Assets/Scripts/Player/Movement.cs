using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        Rigidbody _rigid;

        [Tooltip("Velocity.")]
        [SerializeField] float _moveSpd;
        [Tooltip("Applied force.")]
        [SerializeField] float _moveForce;
        [Tooltip("Horizontal drag (air resistance).")]
        [SerializeField] float _moveDrag;

        void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }

        //used in FixedUpdate()
        public void MoveVelocity(Vector3 dir)
        {
            //movement with rigidbody velocity
            _rigid.velocity = new Vector3(dir.x * _moveSpd, _rigid.velocity.y, dir.z * _moveSpd);
        }

        //used in FixedUpdate()
        public void MoveForce(Vector3 dir)
        {
            //movement with rigidbody AddForce

            //target velocity
            Vector3 vel = dir * _moveSpd;
            vel += vel.normalized * 0.2f * _moveDrag;
            //force applied
            float force = Mathf.Clamp(_moveForce, -_rigid.mass / Time.fixedDeltaTime, _rigid.mass / Time.fixedDeltaTime);
            //if velocity magnitude is 0, apply full force
            if(_rigid.velocity.magnitude == 0) _rigid.AddForce(vel * force, ForceMode.Force);
            //otherwise apply partial force, to not yeet the player out of orbit
            else
            {
                Vector3 velToTarget = (vel.normalized * Vector3.Dot(vel, _rigid.velocity) / vel.magnitude);
                _rigid.AddForce((vel - velToTarget) * force, ForceMode.Force);
            }
        }

        //used in FixedUpdate()
        public void CustomDrag()
        {
            //creates a drag effect, similar to rigidbody drag, but without the Y coordinate
            Vector3 dragVec = new Vector3(-_rigid.velocity.x, 0, -_rigid.velocity.z) * _moveDrag;
            _rigid.AddForce(dragVec);
        }
        //used in FixedUpdate()
        public void CustomDragWUp(float up_mod = 1)
        {
            //creates a drag effect, similar to rigidbody drag, but only applying the Y coordinate when moving upwards
            float y_drag = 0;
            if(_rigid.velocity.y > 0.1f) y_drag = -_rigid.velocity.y;

            Vector3 dragVec = new Vector3(-_rigid.velocity.x, y_drag * up_mod, -_rigid.velocity.z) * _moveDrag;
            _rigid.AddForce(dragVec);
        }
    }
}