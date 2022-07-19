using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameLogic Game;
    public Button _btn;

    private void Start()
    {
        Button button = _btn.GetComponent<Button>();
        button.onClick.AddListener(Game.ReloadLevel);
    }
}
