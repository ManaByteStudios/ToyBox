using UnityEngine;

public class RotateBrick : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
