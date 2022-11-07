using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArmcrutch : MonoBehaviour
{
    [Tooltip("Object with the camera component.")]
        [SerializeField] GameObject _camObj;
        [Tooltip("Object the camera will be following.")]
        [SerializeField] GameObject _camFollowObj;

        [Tooltip("Base horizontal camera sensivity.")]
        [SerializeField] float _base_sensivity_h;

        //horizontal rotation
        float _hRot = 0;

        void Start()
        {
            //debugging
            if(_camObj == null)
            {
                Debug.LogError("_camObj not defined.");
                Destroy(gameObject);
            }

            //Y axis is left/right for rotation
            _hRot = transform.eulerAngles.y;

            //cursor lock
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //used in Update()
        public void PosAndRot(float inputX)
        {
            //smoothes out the input
            inputX = inputX * Time.deltaTime * StaticVars.cam_sensivity * _base_sensivity_h;

            //sets the variables used to rotate
            _hRot += inputX;
            //rotates the player
            transform.rotation = Quaternion.Euler(transform.rotation.x, _hRot, transform.rotation.z);

            _camObj.transform.position = _camFollowObj.transform.position;
            _camObj.transform.rotation = _camFollowObj.transform.rotation;
            //= Quaternion.RotateTowards(_camObj.transform.rotation, _camFollowObj.transform.rotation, _cam_rotSpd * Time.deltaTime);
        }
}
