using UnityEngine;

public class Finish : MonoBehaviour
{
    private ParticleSystem _finishParticleSystem;
    private void Awake()
    {
        _finishParticleSystem = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;
        player.Finished();
        _finishParticleSystem.Play();
    }
}
