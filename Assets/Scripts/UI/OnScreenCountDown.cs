using TMPro;
using UnityEngine;

public class OnScreenCountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text countDownText;
    private void Start()
    {
        if (countDownText == null)
        {
            Debug.LogError("TMP_Text component is not assigned!");
            return;
        }

        if (BrickPickUp.Instance == null)
        {
            Debug.LogError("BrickPickUp Singleton instance is missing!");
            return;
        }

        CountDownTimerToText();
    }

    private void Update()
    {
        CountDownTimerToText();
    }

    private void CountDownTimerToText()
    {
        countDownText.text = FormatTime(BrickPickUp.Instance.currentTime);
    }

    private string FormatTime(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); // Convert total time to minutes
        int seconds = Mathf.FloorToInt(currentTime % 60); // Get remaining seconds

        return string.Format("Time left: {0:00}:{1:00}", minutes, seconds); // Format as MM:SS
    }
}
