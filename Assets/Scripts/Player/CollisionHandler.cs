using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BrickPickUp")
        {
            Destroy(other.gameObject);
        }
    }
}
