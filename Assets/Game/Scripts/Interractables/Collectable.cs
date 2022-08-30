using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interractable
{
    public override void Interract(Transform interractor){
        GetComponent<Collider>().enabled = false;
        Haptics.Soft();
        Destroy(gameObject);
        FloatingText.Instance.Launch(1,Color.green,transform.position,true,"$");
        UICollectable.Instance.Launch(transform.position,1);
    }
}
