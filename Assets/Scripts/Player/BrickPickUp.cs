using System.Collections.Generic;
using UnityEngine;

public class BrickPickUp : MonoBehaviour
{
    [SerializeField] List<GameObject> bricks = new List<GameObject>();

    [SerializeField] private float startTime = 30f;

    int brickCount = 0;
    
    float currentTime;
    float addedTime = 5f;

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        Debug.Log(currentTime);

        if (currentTime <= 0)
        {
            Debug.Log("GameOver");
        }
        else if (brickCount == bricks.Count)
        {
            Debug.Log("Success");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BrickPickUp")
        {
            brickCount++;

            currentTime += addedTime;

            Destroy(other.gameObject);
        }
    }
}
