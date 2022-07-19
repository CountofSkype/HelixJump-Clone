using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    public Text Text;
    public GameLogic Game;

    private void Start()
    {
        Text.text = (Game.LevelNumber + 1).ToString();
    }
}
