using UnityEngine;
using TMPro;

public class SuccessText : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip gameOverSFX;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        

        if (titleText == null)
        {
            Debug.LogError("TMP_Text component is not assigned!");
            return;
        }

        if (BrickPickUp.Instance == null)
        {
            Debug.LogError("BrickPickUp Singleton instance is missing!");
            return;
        }

        SetTitleText();
    }

    private void SetTitleText()
    {
        titleText.text = BrickPickUp.Instance.isSuccessful ? "Successful" : "Game Over";
        Debug.Log("Title updated to: " + titleText.text);

        if (titleText.text == "Successful")
        {
            audioSource.PlayOneShot(successSFX);
        }
        else if(titleText.text == "Game Over")
        {
            audioSource.PlayOneShot(gameOverSFX);
        }
    }
}
