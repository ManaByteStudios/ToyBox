using TMPro;
using UnityEngine;

public class BricksCollectedText1 : MonoBehaviour
{
    [SerializeField] private TMP_Text bricksCollectedText;
    private void Start()
    {
        if (bricksCollectedText == null)
        {
            Debug.LogError("TMP_Text component is not assigned!");
            return;
        }

        if (BrickPickUp.Instance == null)
        {
            Debug.LogError("BrickPickUp Singleton instance is missing!");
            return;
        }

        BricksCollectedToText();
    }

    private void Update()
    {
        BricksCollectedToText();
    }

    private void BricksCollectedToText()
    {
        bricksCollectedText.text = FormatTime(BrickPickUp.Instance.brickCount);
    }

    private string FormatTime(int brickCount)
    {
        return string.Format($"Bricks Collected: {brickCount}");
    }
}
