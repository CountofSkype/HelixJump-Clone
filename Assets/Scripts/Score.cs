using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Player player;
    public Text CurrentScore;

    private void Update()
    {
        CurrentScore.text = player.Score.ToString();      
    }

}
