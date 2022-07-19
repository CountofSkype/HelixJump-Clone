using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Player player;
    public Text Best;

    private void Update()
    {
        Best.text = player.MaxScore.ToString();
    }
}
