using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    bool _isOpen;

    bool _isRunning;

    [SerializeField] bool _needsKey;
    public bool _hasKey;

    [SerializeField] float _doorSpd;

    public Outline outline;

    public void OpenCloseDoor()
    {
        if(_needsKey && !_hasKey) return;

        if(!_isRunning) StartCoroutine("OpenClose");
    }

    private IEnumerator OpenClose()
    {
        _isRunning = true;

        float targetRotY = _isOpen ? transform.eulerAngles.y - 90f : transform.eulerAngles.y + 90f;
        float currRotY = transform.eulerAngles.y;

        _isOpen = !_isOpen;

        float target = Mathf.Abs(transform.eulerAngles.y - targetRotY);

        while(Mathf.Abs(currRotY - targetRotY) > 0.1f)
        {
            print(Mathf.Abs(currRotY - targetRotY) > 0.1f);
            currRotY = Mathf.MoveTowards(currRotY, targetRotY, _doorSpd * Time.fixedDeltaTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, currRotY, transform.eulerAngles.z);

            yield return new WaitForFixedUpdate();
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotY, transform.eulerAngles.z);

        _isRunning = false;
    }
}
