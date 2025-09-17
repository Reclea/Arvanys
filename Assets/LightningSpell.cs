using UnityEngine;

public class LightningSpell : MonoBehaviour
{
    public GameObject lightningPrefab;   // Cube violet
    public GameObject circlePrefab;      // Cercle violet au sol
    public float spawnDistance = 3f;     // Distance devant le joueur
    public float fallSpeed = 10f;        // Vitesse de chute
    public Transform orientation;        // GameObject qui gère la direction du regard

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Touche pour lancer le sort
        {
            SpawnLightning();
        }
    }

    void SpawnLightning()
    {
        // Utiliser l'orientation pour la direction
        Vector3 spawnPos = transform.position + orientation.forward * spawnDistance + Vector3.up * 10f;
        GameObject lightning = Instantiate(lightningPrefab, spawnPos, Quaternion.identity);

        // Ajouter le script qui fait tomber le cube
        lightning.AddComponent<LightningFall>().Initialize(circlePrefab, fallSpeed);
    }
}
