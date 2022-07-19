using UnityEngine;
using UnityEngine.UI;

public class NextLevelNumber : MonoBehaviour
{
    public Text Text;
    public GameLogic Game;

    private void Start()
    {
        Text.text = (Game.LevelNumber + 2).ToString();
    }
}
