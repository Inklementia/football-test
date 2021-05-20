using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] [Range(3, 30)] private int _lineSegmentCount = 20;
    private List<Vector3> _linePoints = new List<Vector3>();

    //Singleton
    public static DrawTrajectory instance;

    private void Awake()
    {
        instance = this;
    }
    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        lineRenderer.gameObject.SetActive(true);
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float flightDuration = (2 * velocity.y) / Physics.gravity.y;
        float stepTime = flightDuration / _lineSegmentCount;
        _linePoints.Clear();

        for (int i = 0; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 movementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
            );

            _linePoints.Add(-movementVector + startingPoint);
        }
        lineRenderer.positionCount = _linePoints.Count;
        lineRenderer.SetPositions(_linePoints.ToArray());
    }

    public void HideTrajectory()
    {
        lineRenderer.positionCount = 0;
    }
}
