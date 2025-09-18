using UnityEngine;

public class LightningFall : MonoBehaviour
{
    public GameObject impactPrefab;   // Particule � l'impact
    public GameObject lightningVFX;   // Particule de l'�clair en chute
    private float fallSpeed;

    // Initialisation
    public void Initialize(GameObject impactPrefab, GameObject lightningVFX, float fallSpeed)
    {
        this.impactPrefab = impactPrefab;
        this.lightningVFX = lightningVFX;
        this.fallSpeed = fallSpeed;

        // Instancier les particules de l'�clair au d�part
        if (lightningVFX != null)
        {
            GameObject vfx = Instantiate(lightningVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = transform; // suivre la chute
        }
    }

    void Update()
    {
        // Faire descendre l'�clair
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // V�rifier le sol
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 20f))
        {
            if (transform.position.y - hit.point.y <= 0.1f)
            {
                SpawnImpact(hit.point);
                Destroy(gameObject); // d�truire l'�clair
            }
        }
    }

    void SpawnImpact(Vector3 position)
    {
        if (impactPrefab != null)
        {
            GameObject impact = Instantiate(impactPrefab, position, Quaternion.identity);
            Destroy(impact, 1f); // d�truire apr�s 1 seconde
        }
    }
}
