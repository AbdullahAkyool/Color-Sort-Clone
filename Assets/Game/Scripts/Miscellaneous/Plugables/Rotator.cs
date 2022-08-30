using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    private enum RotationMode{
        Local,
        World
    }
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private RotationMode rotationMode;
    private RotateMode rotateMode;
    

    private void Start() {

        if(rotationMode == RotationMode.Local){
            rotateMode = RotateMode.LocalAxisAdd;
            LocalRotate();
            
        }
        else if(rotationMode == RotationMode.World){
            rotateMode = RotateMode.WorldAxisAdd;
            WorldRotate();
        }
    }

    private void WorldRotate(){
        transform.DORotate(rotationAxis,1f,RotateMode.WorldAxisAdd).SetEase(Ease.Linear).OnComplete(()=>{
            WorldRotate();
        });
    }
    private void LocalRotate(){
        transform.DOLocalRotate(rotationAxis,1f,RotateMode.LocalAxisAdd).SetEase(Ease.Linear).OnComplete(()=>{
            LocalRotate();
        });
    }
    
}
