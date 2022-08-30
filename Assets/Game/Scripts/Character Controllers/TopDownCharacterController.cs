using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TopDownCharacterController : MonoBehaviour
{
    [SerializeField] private Transform directionIndicator;
    [SerializeField] private float movementSpeed = 3f;

    private Rigidbody _rb;
    private FloatingJoystick _joystick;
    private Transform _transform;
    private Vector3 _targetPos;
    public bool IsMoving;

    void Start()
    {
        Init();
    }

    private void Init(){
        _rb = GetComponent<Rigidbody>();
        _joystick = FindObjectOfType<FloatingJoystick>().GetComponent<FloatingJoystick>();
        _transform = GetComponent<Transform>();
    }

    public void SetSpeed(float newSpeed){
        movementSpeed = newSpeed;
    }
    
    void Update()
    {
        float magnitude = new Vector2(_joystick.Direction.x,_joystick.Direction.y).magnitude;
        float magnitudeSpeed = magnitude * movementSpeed;
        directionIndicator.position = _transform.position + new Vector3(_joystick.Direction.x,-.49f,_joystick.Direction.y) * 2f;
        
        if(Input.GetMouseButton(0))
        {
            Vector3 indicatorPos = directionIndicator.position;
            
            _targetPos = Vector3.MoveTowards(_targetPos,
                new Vector3(indicatorPos.x, transform.position.y, indicatorPos.z), Time.deltaTime * movementSpeed);
            
            _transform.LookAt(_targetPos);
            _rb.velocity = _transform.forward * magnitudeSpeed;
        }
        else{
            _rb.velocity = Vector3.zero;
        }
    }

    public void DisableController(){
        _rb.velocity = Vector3.zero;
        enabled = false;
    }


}
