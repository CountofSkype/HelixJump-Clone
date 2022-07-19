using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Controls Controls;
    public RestartUI RestartUI;
    public FinishUI FinishUI;
    private AudioSource _audio;
    public enum Status
    {
        Playing,
        Win,
        Lose
    }
    public Status CurrentStatus { get; private set; }
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

    public void OnDeath()
    {
        if (CurrentStatus != Status.Playing) return;

        _audio.Stop();
        CurrentStatus = Status.Lose;
        Controls.enabled = false;
        RestartUI.gameObject.SetActive(true);      
    }

    public void OnVictory()
    {
        if (CurrentStatus != Status.Playing) return;

        _audio.Stop();
        CurrentStatus = Status.Win;
        Controls.enabled = false;
        LevelNumber++;
        FinishUI.gameObject.SetActive(true);
    }
    public int LevelNumber
    {
        get => PlayerPrefs.GetInt(LevelNumberKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelNumberKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelNumberKey = "LevelNumber";

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 
    }    
}
