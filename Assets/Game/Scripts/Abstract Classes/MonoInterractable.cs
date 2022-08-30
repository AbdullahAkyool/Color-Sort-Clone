using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoInterractable<T> : MonoSingleton<T> where T:MonoSingleton<T>
{
    public virtual void Interract(Transform interractor){

    }
    public virtual void InterractStay(Transform interractor){

    }
    public virtual void InterractExit(Transform interractor){

    }
}
