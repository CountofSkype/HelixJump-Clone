using UnityEngine;

namespace Assets.Scripts
{
    public class Stage : MonoBehaviour
    {
        public Explosion[] Explosion;
        private AudioSource _breakSound;
        private void Start()
        {
            _breakSound = GetComponent<AudioSource>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.CurrentPlatform = this;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.EarnPoints();
                player.CheckMaxScore();
            }
            foreach (var explosion in Explosion) explosion.Break();
            _breakSound.Play();
        }
    }
}