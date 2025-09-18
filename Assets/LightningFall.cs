using UnityEngine;

public class LightningFall : MonoBehaviour
{
    public GameObject impactPrefab;   // Particule à l'impact
    public GameObject lightningVFX;   // Particule de l'éclair en chute
    private float fallSpeed;

    // Initialisation
    public void Initialize(GameObject impactPrefab, GameObject lightningVFX, float fallSpeed)
    {
        this.impactPrefab = impactPrefab;
        this.lightningVFX = lightningVFX;
        this.fallSpeed = fallSpeed;

        // Instancier les particules de l'éclair au départ
        if (lightningVFX != null)
        {
            GameObject vfx = Instantiate(lightningVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = transform; // suivre la chute
        }
    }

    void Update()
    {
        // Faire descendre l'éclair
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Vérifier le sol
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 20f))
        {
            if (transform.position.y - hit.point.y <= 0.1f)
            {
                SpawnImpact(hit.point);
                Destroy(gameObject); // détruire l'éclair
            }
        }
    }

    void SpawnImpact(Vector3 position)
    {
        if (impactPrefab != null)
        {
            GameObject impact = Instantiate(impactPrefab, position, Quaternion.identity);
            Destroy(impact, 1f); // détruire après 1 seconde
        }
    }
}
