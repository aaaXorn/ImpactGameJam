using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CameraChair : MonoBehaviour
    {
        [Tooltip("Object with the camera component.")]
        [SerializeField] GameObject _camObj;
        [Tooltip("Object the camera will be following.")]
        [SerializeField] GameObject _camFollowObj;

        //[SerializeField] float _cam_rotSpd;

        //horizontal and vertical rotation
        float _hRot, _vRot;

        [Tooltip("Base horizontal camera sensivity.")]
        [SerializeField] float _base_sensivity_h;
        [Tooltip("Base vertical camera sensivity.")]
        [SerializeField] float _base_sensivity_v;

        void Start()
        {
            //debugging
            if(_camObj == null)
            {
                Debug.LogError("_camObj not defined.");
                Destroy(gameObject);
            }

            //Y axis is left/right for rotation
            _hRot = _camObj.transform.eulerAngles.y;
            //X axis is up/down
            _vRot = _camObj.transform.eulerAngles.x;

            //cursor lock
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //used in Update()
        public void PosAndRot(float inputX, float inputY)
        {
            _camObj.transform.position = _camFollowObj.transform.position;
            //_camObj.transform.rotation = _camFollowObj.transform.rotation;
            //= Quaternion.RotateTowards(_camObj.transform.rotation, _camFollowObj.transform.rotation, _cam_rotSpd * Time.deltaTime);

            //smoothes out the inputs
            inputX = inputX * Time.deltaTime * StaticVars.cam_sensivity * _base_sensivity_h;
            inputY = inputY * Time.deltaTime * StaticVars.cam_sensivity * _base_sensivity_v;

            //sets the variables used to rotate
            _hRot += inputX;
            //_hRot = Mathf.Clamp(_hRot, _camFollowObj.transform.rotation.y - 90f, _camFollowObj.transform.rotation.y + 90f);
            _vRot -= inputY;
            _vRot = Mathf.Clamp(_vRot, -90f, 90f);

            //rotates the camera
            _camObj.transform.rotation = Quaternion.Euler(_vRot, _hRot, 0);
        }
    }
}