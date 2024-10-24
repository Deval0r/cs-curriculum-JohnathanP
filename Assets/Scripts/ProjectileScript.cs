using System.Timers;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 target;
    public int speed;
    public PlayerController playerController;
    public Vector3 current;
    public Vector3 direction;
    public GameManagerScript gameManager;
    public float life = 10;
    public float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //FindFirstObjectByType<>()
        
        playerController = FindFirstObjectByType<PlayerController>();
        gameManager = FindFirstObjectByType<GameManagerScript>();
        current = transform.position;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);
        
        speed = 9;
        direction = ((target - transform.position).normalized) * speed;

        
    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, target);
        current = transform.position;
        life -= Time.deltaTime * 3;
        if (life < -1000)
        {
            
            Destroy(gameObject);

        }
        //Vector3 newposition = Vector3.MoveTowards(current,target,speed*Time.deltaTime);
        // transform.position = newposition;
        transform.position += (direction * Time.deltaTime);


    }

    private void OnDestroy()
    {
        if (distance < 0.5)
        {
            gameManager.health -= 1;
        }
    }


}
