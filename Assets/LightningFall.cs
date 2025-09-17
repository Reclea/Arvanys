using UnityEngine;

public class LightningFall : MonoBehaviour
{
    private GameObject circlePrefab;
    private float fallSpeed;

    public void Initialize(GameObject circlePrefab, float fallSpeed)
    {
        this.circlePrefab = circlePrefab;
        this.fallSpeed = fallSpeed;
    }

    void Update()
    {
        // Faire descendre le cube
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Vérifier le sol avec un rayon plus grand pour éviter le délai
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 20f))
        {
            if (transform.position.y - hit.point.y <= 0.1f) // proche du sol
            {
                SpawnCircle(hit.point);
                Destroy(gameObject); // supprimer l'éclair
            }
        }
    }

    void SpawnCircle(Vector3 position)
    {
        GameObject circle = Instantiate(circlePrefab, position, Quaternion.identity);

        // Ajuster le cercle pour avoir 1 mètre de rayon
        circle.transform.localScale = new Vector3(2f, 1f, 2f); // 1m de rayon = diamètre 2m

        // Détruire le cercle après 1 seconde
        Destroy(circle, 1f);
    }
}
