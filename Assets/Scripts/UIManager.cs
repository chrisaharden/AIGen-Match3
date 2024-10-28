using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text coinsEarnedText;
    public TMP_Text collectionGoalText;
    public TMP_Text movesRemainingText;
    public GameObject timesUpPanel;
    public GameObject boardClearedPanel;
    public GameObject creditsPanel;
    public GameObject exitConfirmPanel;
    public Button creditsButton;
    public Button timesUpButton;
    public Button boardClearedButton;
    public Button exitButton;
    public Button confirmExitButton;
    public Button cancelExitButton;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateCoinsEarned(int coins)
    {
        coinsEarnedText.text = $"{coins}";
    }

    public void UpdateMoves(int moves)
    {
        movesRemainingText.text = $"{moves}";
    }

    public void UpdateCollectionGoal(int goal)
    {
        collectionGoalText.text = $"{goal} Minerals";
    }

    public void ShowtimesUp()
    {
        timesUpPanel.SetActive(true);
    }

    public void CloseTimesUpPanel()
    {
        if (timesUpPanel != null)
        {
            timesUpPanel.SetActive(false);
        }
    }

    public void ShowBoardCleared()
    {
        if (boardClearedPanel != null)
        {
            bool isActive = !boardClearedPanel.activeSelf;
            boardClearedPanel.SetActive(isActive);

            // Bring the panel to the top of the z-order
            if (isActive)
            {
                boardClearedPanel.transform.SetAsLastSibling();
            }
        }
    }

    public void CloseBoardClearedPanel()
    {
        if (boardClearedPanel != null)
        {
            boardClearedPanel.SetActive(false);
        }
    }

    public void ToggleCreditsPanel()
    {
        if (creditsPanel != null)
        {
            bool isActive = !creditsPanel.activeSelf;
            creditsPanel.SetActive(isActive);

            // Bring the panel to the top of the z-order
            if (isActive)
            {
                creditsPanel.transform.SetAsLastSibling();
            }
        }
    }

    public void ShowExitConfirmation()
    {
        if (exitConfirmPanel != null)
        {
            exitConfirmPanel.SetActive(true);
            exitConfirmPanel.transform.SetAsLastSibling();
        }
    }

    public void CloseExitConfirmation()
    {
        if (exitConfirmPanel != null)
        {
            exitConfirmPanel.SetActive(false);
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void Start()
    {
        creditsButton.onClick.AddListener(ToggleCreditsPanel);
        if (timesUpButton != null)
        {
            timesUpButton.onClick.AddListener(CloseTimesUpPanel);
        }
        if (boardClearedButton != null)
        {
            boardClearedButton.onClick.AddListener(CloseBoardClearedPanel);
        }
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ShowExitConfirmation);
        }
        if (confirmExitButton != null)
        {
            confirmExitButton.onClick.AddListener(ExitGame);
        }
        if (cancelExitButton != null)
        {
            cancelExitButton.onClick.AddListener(CloseExitConfirmation);
        }
    }
}
