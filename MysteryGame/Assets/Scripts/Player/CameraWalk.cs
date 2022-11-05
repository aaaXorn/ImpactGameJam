using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CameraWalk : MonoBehaviour
    {
        [SerializeField] GameObject _camObj;

        [SerializeField] GameObject _camFollowObj;

        //horizontal and vertical rotation
        float _hRot, _vRot;

        //base sensivity
        [SerializeField]
        float _base_sensivity_h;
        [SerializeField]
        float _base_sensivity_v;

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
            //X axis is up/down
            _vRot = _camObj.transform.eulerAngles.x;
        }

        //used in Update()
        public void RotateWalk(float inputX, float inputY)
        {
            _camObj.transform.position = _camFollowObj.transform.position;

            inputX = inputX * Time.deltaTime * StaticVars.cam_sensivity * _base_sensivity_h;
            inputY = inputY * Time.deltaTime * StaticVars.cam_sensivity * _base_sensivity_v;

            _hRot += inputX;
            _vRot -= inputY;
            _vRot = Mathf.Clamp(_vRot, -90f, 90f);

            _camObj.transform.rotation = Quaternion.Euler(_vRot, _hRot, 0);
            transform.rotation = Quaternion.Euler(transform.rotation.x, _hRot, transform.rotation.z);
        }
    }
}