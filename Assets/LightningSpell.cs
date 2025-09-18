using UnityEngine;

public class LightningSpell : MonoBehaviour
{
    public GameObject lightningPrefab;   // Cube ou empty pour le script
    public GameObject lightningVFX;      // Particules de l'éclair
    public GameObject impactVFX;         // Particules de l'impact
    public float spawnDistance = 3f;
    public float fallSpeed = 10f;
    public Transform orientation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnLightning();
        }
    }

    void SpawnLightning()
    {
        Vector3 spawnPos = transform.position + orientation.forward * spawnDistance + Vector3.up * 10f;
        GameObject lightning = Instantiate(lightningPrefab, spawnPos, Quaternion.identity);

        // Ajouter le script pour la chute et passer les particules
        lightning.AddComponent<LightningFall>().Initialize(impactVFX, lightningVFX, fallSpeed);
    }
}
