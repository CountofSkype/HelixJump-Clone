using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public GameLogic Game;
    public Stage CurrentPlatform;
    private Material _dissolve;
    public float DissolveSpeed = 0.001f;
    private ParticleSystem _dissolveParticle;

    public int Score { get; private set; }
    
    public int MaxScore
    {
        get => PlayerPrefs.GetInt(BestScoreKey, 0);
        private set
        {
            PlayerPrefs.SetInt(BestScoreKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string BestScoreKey = "BestScore";
    private void Start()
    {
        _dissolve = GetComponent<Renderer>().material;
        _dissolveParticle = GetComponent<ParticleSystem>();
    }
    public string CheckMaxScore()
    {
        if (MaxScore < Score) MaxScore = Score;
        return MaxScore.ToString();
    }
    public void Finished()
    {
        Game.OnVictory();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);    
    }

    public void Die()
    {
        Game.OnDeath();
        _dissolveParticle.Play();
        Rigidbody.velocity = Vector3.zero;
    }

    public void EarnPoints()
    {
        Score += 1;
    }
    public void Update()
    {
        if (Game.CurrentStatus == GameLogic.Status.Lose)
        {
            _dissolve.SetFloat("DissolveFactor", (_dissolve.GetFloat("DissolveFactor") - DissolveSpeed));
        }
    }
}
