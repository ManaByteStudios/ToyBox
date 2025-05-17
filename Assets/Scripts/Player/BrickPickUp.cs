using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            GameOverMessage("Game Over");
            LoadNextScene();
        }
        else if (brickCount == bricks.Count)
        {
            GameOverMessage("Success");
            LoadNextScene();
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

    private float TimeInGame()
    {
        float timeInGame = Time.deltaTime;

        return timeInGame;
    }

    private string GameOverMessage(string message)
    {
        if(message == "Success")
        {
            return "Success";
        }
        else if (message == "Game Over")
        {
            return "Game Over";
        }
        return message;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
