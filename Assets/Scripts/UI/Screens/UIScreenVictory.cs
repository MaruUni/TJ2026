using TMPro;
using UnityEngine;

public class UIScreenVictory : UIScreen
{
    [SerializeField] TextMeshProUGUI winningTeamText;

    public override void Show()
    {
        int[] teamScore = GameManager.Instance.TeamScore;

        if (teamScore[0] > teamScore[1])
            winningTeamText.text = "Team 1 wins";
        else
            winningTeamText.text = "Team 2 wins";


        base.Show();
    }
}
