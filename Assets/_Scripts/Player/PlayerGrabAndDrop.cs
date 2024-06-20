using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabAndDrop : MonoBehaviour
{
    [SerializeField] private Transform _raycastGrabPointTransform;
    [SerializeField] private Transform _objectGrabPointTransform;
    [SerializeField] private LayerMask _grabMask;


    private PlayerInput _playerInput;
    private ObjectGrabbable _objectGrabbable;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_playerInput.FrameInput.Grab)
        {
            if (_objectGrabbable == null)
            {
                float grabDistance = 2f;
                if (Physics.Raycast(_raycastGrabPointTransform.position, _raycastGrabPointTransform.forward, out RaycastHit raycastHit, grabDistance))
                {
                    if (raycastHit.transform.TryGetComponent(out _objectGrabbable))
                    {
                        _objectGrabbable.Grab(_objectGrabPointTransform);
                    }
                }

            }
            else
            {
                _objectGrabbable.Drop();
                _objectGrabbable = null;
            }
        }
    }
}
