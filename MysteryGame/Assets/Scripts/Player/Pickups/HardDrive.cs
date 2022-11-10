using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDrive : MonoBehaviour
{
    [SerializeField] GameEnd GE;

    public void HDGet()
    {
        GE._finishOpen = true;
        gameObject.SetActive(false);
    }
}
