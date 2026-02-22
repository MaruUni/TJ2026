using System.Collections;
using UnityEngine;

/// <summary>
/// Game logic and state
/// </summary>
public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameStats gameStats;
    int[] teamScore = new int[2] { 0, 0 };
    bool suddenDeathEnabled = false;
    public event System.Action<int, int> ChangeScore;

    private void Start()
    {
        if (gameStats == null)
        {
            Debug.LogError("GameStats not assigned in GameManager!");
        }

        ResetGame();
        StartCoroutine(CounterCoroutine());
    }

    public void ResetGame()
    {
        teamScore[0] = 0; 
        ChangeScore?.Invoke(0, 0);
        teamScore[1] = 0;
        ChangeScore?.Invoke(1, 0);
        suddenDeathEnabled = false;
        StopAllCoroutines();
        
    }

    #region Get global game stats
    public Color GetTeamColor(int teamIndex)
    {
        return gameStats.teamColors[teamIndex];
    }

    #endregion

    #region Score management

    public void AddToScore(int teamIndex)
    {
        teamScore[teamIndex]++;
        Debug.Log($"Team {teamIndex} scored! Current score: {teamScore[0]} - {teamScore[1]}");
        ChangeScore?.Invoke(teamIndex, teamScore[teamIndex]);
        CheckWinCondition();
    }

    #endregion

    #region End game conditions management

    private void CheckWinCondition()
    {
        if (!suddenDeathEnabled)
        {

            if (teamScore[0] >= gameStats.MaxScore)
            {
                Debug.Log("Team 0 wins!");
            }
            else if (teamScore[1] >= gameStats.MaxScore)
            {
                Debug.Log("Team 1 wins!");
            }
        } else
        {
            if (teamScore[0] > teamScore[1])
            {
                Debug.Log("Sudden death! Team 0 wins!");
            }
            else if (teamScore[1] > teamScore[0])
            {
                Debug.Log("Sudden death! Team 1 wins!");
            }
        }
    }

    IEnumerator CounterCoroutine()
    {
        yield return new WaitForSeconds(gameStats.Duration);
        if (teamScore[0] > teamScore[1])
        {
            Debug.Log("Time's up! Team 0 wins!");
        }
        else if (teamScore[1] > teamScore[0])
        {
            Debug.Log("Time's up! Team 1 wins!");
        }
        else
        {
            Debug.Log("Time's up! It's a tie! Sudden death starts!");
        }
    }
    #endregion
}
