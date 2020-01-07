using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{

    public GameObject Ghost;
    public Transform GhostSpawnPoint;
    private float playerDifferenceX;
    private float playerDifferenceY;
    private float RespawnTimer = 0f;
    private float RespawnCoolDown = 20f;
    public float spawnRange;
    private bool ghostinRange;
    void Start()
    {
        
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
    // Update is called once per frame
    void Update()
    {

        Spawner();
    }
    void Spawner()
    {
        if (RespawnTimer <= 0)
        {
            playerDifferenceX = PlayerController.Instance.gameObject.transform.position.x - transform.position.x;
            playerDifferenceY = PlayerController.Instance.gameObject.transform.position.y - transform.position.y;

            if (Mathf.Abs(playerDifferenceX) < spawnRange && Mathf.Abs(playerDifferenceY) < spawnRange )
            {
                Instantiate(Ghost, GhostSpawnPoint.position, GhostSpawnPoint.rotation);
                RespawnTimer = RespawnCoolDown;
            }
        }
        else
        {
            RespawnTimer -= Time.deltaTime;
        }
    }
    
    
}
