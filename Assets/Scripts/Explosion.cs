using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private ParticleSystem _particleSystem;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void Break()
    {
        _rigidbody.isKinematic = false;
        _particleSystem.Play();
        Destroy(gameObject, 0.25f);
    }
}
