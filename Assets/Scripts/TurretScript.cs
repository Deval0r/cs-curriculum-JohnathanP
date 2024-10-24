using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Vector3 spawnPos;
    public float cool = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        spawnPos = new Vector3 (transform.position.x,transform.position.y, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        
        cool -= 1;



        if (other.gameObject.CompareTag("Player") && (cool < 1))
        {
            cool = 60;
            Instantiate(projectilePrefab,spawnPos, Quaternion.identity);

            ProjectileScript Script = projectilePrefab.GetComponent<ProjectileScript>();
           

        }
    }


}
