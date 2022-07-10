using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class SwordController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    //parameters for PC
    private Vector3 mousePosition;
    //parameters for MOBILE
    [Header("Mobile parameters")]
    [SerializeField] private float minSpeed=.1f;
    private Vector3 lastMousePosition;
    private CircleCollider2D myCollider2D;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {        
        AsociateSwordToMouse();        
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            myCollider2D.enabled = IsMouseInMovement();
        }
    }
    private void AsociateSwordToMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        _rigidbody2D.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    private bool IsMouseInMovement()
    {
        Vector3 currentMousePosition = transform.position;
        float movement = (lastMousePosition - currentMousePosition).magnitude;
        lastMousePosition = currentMousePosition;
        if (movement > minSpeed)
            return true;
        else
            return false;
    }
    
}
