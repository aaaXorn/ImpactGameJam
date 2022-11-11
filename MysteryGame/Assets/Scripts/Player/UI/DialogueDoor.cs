using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDoor : MonoBehaviour
{
    [SerializeField] string txt, txt2;

    [SerializeField] DoorOpen door;

    bool _dialogue1;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(door._hasKey)
            {
                Dialogue.Instance.ChangeText(txt);
                Destroy(gameObject);
            }
            else if(!_dialogue1)
            {
                Dialogue.Instance.ChangeText(txt2);
                _dialogue1 = false;
            }
        }
    }
}
