using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerLocation;
    private void Update()
    {
        transform.position = new Vector3(playerLocation.position.x, playerLocation.position.y, playerLocation.position.z - 15);
    }
}
