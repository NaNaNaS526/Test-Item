using System.ComponentModel;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    private Vector3 _camOffset = new Vector3(0f, 15f, -25f);


    private void LateUpdate()
    {
        transform.position = targetTransform.TransformPoint(_camOffset);
        transform.LookAt(new Vector3(targetTransform.position.x, targetTransform.position.y + 4f,
            targetTransform.position.z));
    }
}