using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Events;

public class interactor : MonoBehaviour
{
    [Header ("ïnterqactable layer mask")]
    public LayerMask interactionMask;

    Interactable inter;
    public Image iImage;
    public Sprite defIcon;
    public Vector2 defIconSize;
    public Sprite defInterIcon;
    public Vector2 defInterIconSize;

    // UnityEvent onInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 2, interactionMask)){
            if(hit.collider.GetComponent<Interactable>() != false){
                int currID = hit.collider.GetComponent<Interactable>().id;
                if(inter == null || inter.id != currID){
                    inter = hit.collider.GetComponent<Interactable>();
                }
                if(inter.iIcon != null){
                    iImage.sprite = inter.iIcon;
                    if(inter.iconSize == Vector2.zero){
                        iImage.rectTransform.sizeDelta = defInterIconSize;
                    }else{
                        iImage.rectTransform.sizeDelta = inter.iconSize;
                    }
                }else{
                    iImage.sprite = defInterIcon;
                    iImage.rectTransform.sizeDelta = defInterIconSize;
                }
                // onInteract = hit.collider.GetComponent<Interactable>().onInteract;
                if(Input.GetKeyDown(KeyCode.E)){
                    // onInteract.invoke();
                    Debug.Log("Gameobject: "+hit.collider.name+" ID: "+currID);
                }
            }
        }else{
            if(iImage.sprite != defIcon){
                iImage.sprite = defIcon;
                iImage.rectTransform.sizeDelta = defIconSize;
            }
        }
    }
}
