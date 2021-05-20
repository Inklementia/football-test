using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtRandomPlace : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private GameObject thingToSpawn;

    private float _randomX;

    private void Start()
    {
        _randomX = Random.Range(pointA.position.x, pointB.position.x);

        Instantiate(thingToSpawn, new Vector3(_randomX, pointA.position.y, pointA.position.z), Quaternion.identity);
    }
}
