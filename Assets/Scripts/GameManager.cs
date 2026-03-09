using UnityEngine;

/// <summary>
/// Game logic and state
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameStats gameStats;
    int[] teamScore = new int[2] { 0, 0 };

    public int[] TeamScore { get { return teamScore; } }

    bool suddenDeathEnabled = false;

    public bool SuddenDeathEnabled { get { return suddenDeathEnabled; } }

    int maxScore;

    /// <summary>
    /// Event fires when score changes
    /// <para>&lt;Team 1 score, team 2 score&gt;</para>
    /// </summary>
    public event System.Action<int, int> UpdateUIScore;
    /// <summary>
    /// Event fires when player has consumed stamina
    /// <para>&lt;Player index, Amount of Stamina consumed&gt;</para>
    /// </summary>
    public event System.Action<int, int> PlayerStaminaConsumption;
    /// <summary>
    /// Event fires when game ends
    /// <para> Returns winning team index</para>
    /// </summary>
    public event System.Action<int> EndGame;

    private void Start()
    {
        if (gameStats == null)
        {
            Debug.LogError("GameStats not assigned in GameManager!");
        }

        ResetGame();
    }

    public void ResetGame()
    {
        StopAllCoroutines();

        maxScore = FindObjectsByType<Crystal>(FindObjectsSortMode.None).Length;

        teamScore[0] = 0;
        UpdateUIScore?.Invoke(0, 0);
        teamScore[1] = 0;
        UpdateUIScore?.Invoke(1, 0);

        suddenDeathEnabled = false;
    }

    #region Get global game stats
    public Color GetTeamColor(int teamIndex){ return gameStats.TeamColor[teamIndex]; }

    public Material GetTeamEmissiveMaterial(int teamIndex){ return gameStats.TeamEmissiveMaterial[teamIndex]; }

    public float GetReclaimCrystalDuration(){ return gameStats.ReclaimCrystalDuration; }

    public float GetGameDuration(){ return gameStats.GameDuration; }

    public float GetCrystalCooldownDuration(){ return gameStats.CrystalCooldownDuration; }

    public float GetLightStunDuration(){ return gameStats.LightStunDuration; }

    public float GetHeavyStunDuration(){ return gameStats.HeavyStunDuration; }

    public float GetDashDuration(){ return gameStats.DashDuration; }

    public float GetDashSpeedIncrement() { return gameStats.DashSpeedIncrement; }

    public float GetMaxStamina() { return gameStats.MaxStamina; }

    public float GetStaminaConsumption() { return gameStats.StaminaConsumption; }

    public float GetStaminaRegenRate() { return gameStats.StaminaRegenRate; }

    #endregion

    #region Score management

    public void ChangeScore(int teamIndex, int scoreChange)
    {
        teamScore[teamIndex] += scoreChange;
        Debug.Log($"Team {teamIndex} score changed! Current score: {teamScore[0]} - {teamScore[1]}");
        UpdateUIScore?.Invoke(teamIndex, teamScore[teamIndex]);
        CheckWinCondition();
    }

    #endregion

    #region End game conditions management

    private void CheckWinCondition()
    {
        if (!suddenDeathEnabled)
        {
            if (teamScore[0] >= maxScore)
            {
                EndGame.Invoke(0);
            }
            else if (teamScore[1] >= maxScore)
            {
                EndGame.Invoke(1);
            }
        } else
        {
            if (teamScore[0] > teamScore[1])
            {
                EndGame.Invoke(0);
            }
            else if (teamScore[1] > teamScore[0])
            {
                EndGame.Invoke(1);
            }
        }
    }

    public void TimerEnded()
    {
        if (teamScore[0] > teamScore[1])
        {
            EndGame.Invoke(0);
        }
        else if (teamScore[1] > teamScore[0])
        {
            EndGame.Invoke(1);
        }
        else
        {
            suddenDeathEnabled = true;
        }
    }
    #endregion
}
