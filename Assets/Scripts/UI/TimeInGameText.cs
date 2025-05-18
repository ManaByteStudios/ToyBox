using UnityEngine;
using TMPro;

public class TotalGameTime : MonoBehaviour
{
    [SerializeField] private TMP_Text timeInGameText;

    void Start()
    {
        if (timeInGameText == null)
        {
            Debug.LogError("TMP_Text component is not assigned!");
            return;
        }

        if (BrickPickUp.Instance == null)
        {
            Debug.LogError("BrickPickUp Singleton instance is missing!");
            return;
        }

        TotalTimeInGameText();
    }

    private void TotalTimeInGameText()
    {
        timeInGameText.text = FormatTime(BrickPickUp.Instance.TimeInGame());
    }

    private string FormatTime(float timeInGame)
    {
        int minutes = Mathf.FloorToInt(timeInGame / 60); // Convert total time to minutes
        int seconds = Mathf.FloorToInt(timeInGame % 60); // Get remaining seconds

        return string.Format("{0:00}:{1:00}", minutes, seconds); // Format as MM:SS
    }
}
