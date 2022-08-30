using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : Interractable
{
    public override void Interract(Transform interractor){
        Player.Instance.cc.BounceBack(20f,7f,.7f);
        Haptics.Medium();
    }
}
