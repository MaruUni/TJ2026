using TMPro;
using UnityEngine;

/// <summary>
/// This class is responsible for managing the score UI, it listens to the GameManager's ChangeScore event and updates the score display accordingly. Singleton because there can only be an instance of this in scene (but not called from anywhere really)
/// </summary>
public class ScoreUIManager : Singleton<ScoreUIManager>
{
    [SerializeField] private TextMeshProUGUI[] teamScoreTexts;

    private void Start()
    {
        // TODO: Once everything is more stablished we should add a way to ensure this is always assigned
        // This is also going to be a problem 100% when we have multiple scenes because it is not destroyable on load and im not doing anything about it!
        // In the future it shouldnt be initialized on inspector but found on the scene and it should also be reset on scene change
        if (teamScoreTexts == null)
        {
            Debug.LogWarning("Team score texts not assigned in the inspector, unless you want to see a sea of red on the console you should add them :)");
        }

        teamScoreTexts[0].text = "0";
        teamScoreTexts[1].text = "0";
    }
    private void OnEnable()
    {
        GameManager.Instance.ChangeScore += UpdateScoreUI;
    }
    private void OnDisable()
    {
        GameManager.Instance.ChangeScore -= UpdateScoreUI;
    }

    void UpdateScoreUI(int teamIndex, int teamScore)
    {
       Debug.Log($"Updating score UI for team {teamIndex} with new score {teamScore}");
        teamScoreTexts[teamIndex].text = teamScore.ToString();
    }
}
