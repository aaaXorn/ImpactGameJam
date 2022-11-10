using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] Timer timer;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Chair"))
        {
            timer.StartTimer();
            Destroy(gameObject);
        }
    }
}
