using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] Timer timer;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            timer.StartTimer();
            Destroy(gameObject);
        }
    }
}
