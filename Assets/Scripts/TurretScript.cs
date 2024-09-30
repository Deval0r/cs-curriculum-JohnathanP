using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Vector3 spawnPos;
    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPos = new Vector3 (transform.position.x,transform.position.y, 0);
    }

    private void OnTriggerStay(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            GameObject clone;
            clone = Instantiate(projectilePrefab,spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
