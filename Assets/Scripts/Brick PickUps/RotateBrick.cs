using UnityEngine;

public class RotateBrick : MonoBehaviour
{
    public static RotateBrick Instance;

    [SerializeField] private float rotationSpeed = 2f;
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
