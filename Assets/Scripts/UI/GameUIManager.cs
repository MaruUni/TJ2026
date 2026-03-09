using TMPro;
using UnityEngine;

/// <summary>
/// This class is responsible for managing the in game UI (score, timer...), it listen's to GameManager events.
/// </summary>
public class GameUIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextMeshProUGUI[] teamScoreTexts = new TextMeshProUGUI[2];
    [SerializeField] private TextMeshProUGUI timerText;
    float timePassed = 0;

    bool timeBelowZero = false;
    #endregion

    #region Monobehaviour

    private void Awake()
    {
        // TODO: Once everything is more stablished we should add a way to ensure this is always assigned instead of manually checking the inspector, maybe with a tag or something like that
        if (teamScoreTexts == null)
        {
            Debug.LogWarning("Team score texts not assigned in the inspector, unless you want to see a sea of red on the console you should add them :)");
        }

        teamScoreTexts[0].text = "0";
        teamScoreTexts[1].text = "0";

        timerText.text = GameManager.Instance.GetGameDuration().ToString("F2");
    }
    void Update()
    {
        if (!timeBelowZero)
            UpdateTimer();
    }
    #endregion

    #region Event listeners setup

    private void OnEnable()
    {
        GameManager.Instance.UpdateUIScore += UpdateScoreUI;
        GameManager.Instance.EndGame += EndGameUI;
    }
    private void OnDisable()
    {
        GameManager.Instance.UpdateUIScore -= UpdateScoreUI;
        GameManager.Instance.EndGame -= EndGameUI;
    }
    #endregion

    #region Update score, timer and player stuff
    void UpdateScoreUI(int teamIndex, int teamScore)
    {
        teamScoreTexts[teamIndex].text = teamScore.ToString();
    }

    void UpdateTimer()
    {
        timePassed += Time.deltaTime;
        int currentTime = Mathf.CeilToInt(GameManager.Instance.GetGameDuration() - timePassed);
        if (currentTime <= 0)
        {
            timeBelowZero = true;
            GameManager.Instance.TimerEnded(); // Notify GameManager of timer end
        }

        timerText.text = currentTime.ToString();
    }
    #endregion

    #region Victory screen
    void EndGameUI(int winningTeamIndex)
    {
        UINavigationManager.Instance.ShowScreen(ScreenName.Victory);
    }
    #endregion
}
