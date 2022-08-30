using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoInterractable<Finish>
{
    public IMultiplier multiplier;

    public override void Interract(Transform interractor){
        Player.Instance.cc.Disable();
        
        ParticleManager.Instance.Launch(0,transform.position + Vector3.up,2f);

    }
}
