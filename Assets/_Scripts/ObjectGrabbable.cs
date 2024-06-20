using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _objectGrabPointTransform;
    private BoxCollider _triggerBoxCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _triggerBoxCollider = transform.GetChild(0).GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        if(_objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position,
                _objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            _rigidbody.MovePosition(newPosition);
        }
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        _objectGrabPointTransform = objectGrabPointTransform;
        _rigidbody.useGravity = false;
        _triggerBoxCollider.enabled = false;
        
    }
    public void Drop()
    {
        _objectGrabPointTransform = null;
        _rigidbody.useGravity = true;
        _triggerBoxCollider.enabled = true;
    }
}
