using TMPro;
using UnityEngine;

public class BricksCollectedText : MonoBehaviour
{
    [SerializeField] private TMP_Text bricksCollected;

    void Start()
    {
        if (bricksCollected == null)
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
        bricksCollected.text = FormatTime(BrickPickUp.Instance.brickCount);
    }

    private string FormatTime(int bricksCollected)
    {
        return string.Format($"Total Bricks Collected: {bricksCollected}");
    }
}
