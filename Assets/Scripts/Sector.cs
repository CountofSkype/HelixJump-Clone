using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsCommon = true;
    public Material Common;
    public Material DeadlyMaterial;
    private AudioSource _bounceSound;
    private void Awake()
    {
        UpdateMaterial();
        _bounceSound = GetComponent<AudioSource>();
    }

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsCommon ? Common : DeadlyMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5) return;

        _bounceSound.Play();
        if (IsCommon)
            player.Bounce();
        else
            player.Die();
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
