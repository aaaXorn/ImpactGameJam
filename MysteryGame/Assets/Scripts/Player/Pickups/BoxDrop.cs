using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrop : MonoBehaviour
{
    bool _hasFallen, _fallStarted;

    [SerializeField] Rigidbody _rigid;

    [SerializeField] Transform _playerPos;

    [SerializeField] float _pushForce, _crutchMove;

    [SerializeField] GameObject _crutchAnimation;

    [SerializeField] Outline _outline;

    [SerializeField] Color _newClr, _newClrDoor, _oldClr;

    float step = 1f/60f;

    [SerializeField] DoorOpen door;

    [SerializeField] GameObject _keyUI;

    void Start()
    {
        _pushForce *= step;
        _crutchMove *= step * 2f;

        //_oldClr = _outline.OutlineColor;

        //Push();
    }

    public void Interact()
    {
        if(!_hasFallen && !_fallStarted) Push();
        else if(_hasFallen) GetKey();
    }

    private void Push()
    {
        StartCoroutine("PushEffect");
    }
    private void GetKey()
    {
        if(door._hasKey) return;

        _outline.OutlineColor = _oldClr;
        door._hasKey = true;
        door.outline.OutlineColor = _newClrDoor;
    }

    private IEnumerator PushEffect()
    {
        _fallStarted = true;

        _crutchAnimation.SetActive(true);
        

        Vector3 force_vect = new Vector3(0, 0, (transform.position.z > _playerPos.position.z) ? 1 : -1);
        int i = 0;
        while(i < 45)
        {
            if(i >= 15)
            {
                if(i == 20) _crutchAnimation.SetActive(false);
                _rigid.transform.Translate(force_vect * _pushForce, Space.World);
            }
            else
                _crutchAnimation.transform.Translate(-Vector3.up * _crutchMove);
            i++;
            yield return new WaitForSeconds(step);
        }

        _rigid.isKinematic = false;

        while(i < 60)
        {
            i++;
            yield return new WaitForSeconds(step);
        }

        _hasFallen = true;
        _outline.OutlineColor = _newClr;

        yield break;
    }
}
