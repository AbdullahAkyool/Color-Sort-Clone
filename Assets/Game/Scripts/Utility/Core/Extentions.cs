using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class Extentions
{
    /// <summary> Return a transform array of the given transforms children </summary>
    public static Transform[] GetChildren(this Transform parent){
        List<Transform> children = new List<Transform>(); 
        foreach (Transform child in parent)
        {
            children.Add(child);
        }
        return children.ToArray();
    }

    public static List<T> ToList<T>(this T[] array){
        List<T> list = new  List<T>();
        foreach(T typ in array){
            list.Add(typ);
        }
        return list;
    }

    /// <summary> Outputs a integer number in a shortened form to a string (Ex: 1200000 -> 1.2M) </summary>
    public static string ToStringShortenedNumber(this int number,string format = null){
        if(number < 1000){
            return number.ToString();
        }
        else if(number < 1000000){
            return ((float)number/1000f ).ToString(format) + "K";
        }
        else if(number < 1000000000){
            return ((float)number/1000000f ).ToString(format) + "M";
        }
        else{
            return ((float)number/1000000000f ).ToString(format) + "B";
        }
    }

    public static string ToStringShortenedNumber(this float number,string format = null){
        if(number < 1000){
            return number.ToString(format);
        }
        else if(number < 1000000){
            return ((float)number/1000f ).ToString(format) + "K";
        }
        else if(number < 1000000000){
            return ((float)number/1000000f ).ToString(format) + "M";
        }
        else{
            return ((float)number/1000000000f ).ToString(format) + "B";
        }
    }





    public static string ToStringTime(this int seconds){
        if(seconds<60){
            return seconds.ToString();
        }
        else if(seconds<3600){
            return (seconds/60).ToString("00") +":" + (seconds%60).ToString("00");
        }
        else{
            return (seconds/3600).ToString()+":"+((seconds/60)%60).ToString("00") +":" + (seconds%60).ToString("00");
        }
    }

    public static T RandomElement<T>(this List<T> list){
        return list[UnityEngine.Random.Range(0,list.Count)];
    }

    public static T RandomElement<T>(this T[] arr){
        return arr[UnityEngine.Random.Range(0,arr.Length)];
    }
    
    public static void DOTranslate(this Transform trn,Transform target,float duration,Ease ease = Ease.InOutQuad,float delay = 0f){
        trn.DOMove(target.position,duration).SetEase(ease).SetDelay(delay);
        trn.DORotateQuaternion(target.rotation,duration).SetEase(ease).SetDelay(delay);
        trn.DOScale(target.localScale,duration).SetEase(ease).SetDelay(delay);
    }
    public static void DOLocalTranslate(this Transform trn,Transform target,float duration,Ease ease = Ease.InOutQuad,float delay = 0f){
        trn.DOLocalMove(target.localPosition,duration).SetEase(ease).SetDelay(delay);
        trn.DOLocalRotateQuaternion(target.localRotation,duration).SetEase(ease).SetDelay(delay);
        trn.DOScale(target.localScale,duration).SetEase(ease).SetDelay(delay);
    }
}


