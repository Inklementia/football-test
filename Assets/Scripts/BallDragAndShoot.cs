using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDragAndShoot : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 3;
    private Vector3 _mousePressDownPos;
    private Vector3 _mouseReleasePos;

    private Rigidbody _rb;

   // private Vector3 forceVector;
    private bool _isShoot;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

    }
    private void OnMouseDown()
    {
        _mousePressDownPos = Input.mousePosition; 
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = Input.mousePosition - _mousePressDownPos;
        Vector3 forceV = new Vector3(forceInit.x, forceInit.y, forceInit.y) * forceMultiplier;

        if (!_isShoot)
        {
            DrawTrajectory.instance.UpdateTrajectory(forceV, _rb, transform.position);
        }
    }

    private void OnMouseUp()
    {
        DrawTrajectory.instance.HideTrajectory();
       _mouseReleasePos = Input.mousePosition;
        ShootBall(_mousePressDownPos - _mouseReleasePos);
    }

    private void ShootBall(Vector3 force)
    {
        if (_isShoot)
        {
            return;
        }

        _rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        _isShoot = true;
    }
}
