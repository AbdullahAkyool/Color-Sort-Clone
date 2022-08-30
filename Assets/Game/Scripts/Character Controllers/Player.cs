using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [HideInInspector] public ICharacterController cc;

    private void Start() {
        cc = transform.parent.GetComponent<ICharacterController>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<Interractable>(out Interractable interractable)){
            interractable.Interract(transform);
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.TryGetComponent<Interractable>(out Interractable interractable)){
            interractable.InterractStay(transform);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.TryGetComponent<Interractable>(out Interractable interractable)){
            interractable.InterractExit(transform);
        }
    }
}
