using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitiate : MonoBehaviour
{
    [SerializeField] string txt;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Dialogue.Instance.ChangeText(txt);
            Destroy(gameObject);
        }
    }
}
