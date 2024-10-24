using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    
    private Vector3 target;
    private Vector3 current;
    private Vector3 direction;
    private GameManagerScript gameManager;
    private PlayerController playerController;
    private TopDown_AnimatorController animScript;
    private float distance;
    public float state;
    private float changetime;
    private float iframes;
    public float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 3;
        animScript= FindFirstObjectByType<TopDown_AnimatorController>();
        iframes = 750;
        playerController = FindFirstObjectByType<PlayerController>();
        gameManager = FindFirstObjectByType<GameManagerScript>();
        changetime = 100;
        current = transform.position;
        target = new Vector3(playerController.playerX, playerController.playerY, 0);

    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(gameObject.transform.position, target);
        if (distance < 4.5)
        {
            if (distance < 1.25)
                state = 3; ////////ATTACK
            else
                state = 2; /////////////CHASE

        }
        else
        {
           
            state = 1;////////////PATROL
        }

            target = new Vector3(playerController.playerX, playerController.playerY, 0);
            
        if (state == 2)/////////CHASE
        {
            iframes -= 1;
            direction = ((target - transform.position).normalized) * 3;
            transform.position += (direction * Time.deltaTime);
        }

        if (state == 3)/////ATK
        {
            iframes -= 1;
            if (iframes < 1)
            {
                if (animScript.attacking==1)
                {
                    health -= 1;
                    animScript.cooldown = 600;
                    animScript.attacking = 0;
                    
                }
                iframes = 750;
                gameManager.health -= 1;
            }
            direction = ((target - transform.position).normalized) * 3;
            transform.position += (direction * Time.deltaTime) / 2;
        }

        if (health<1)
        {

            Destroy(gameObject);
        }

        current = transform.position;


        if (state == 1)///////PATROL
        {

            
            changetime -= 1;
            if (changetime<1)
            {
                direction = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0);
                changetime = Random.Range(750, 4000);
            }
            transform.position += ((direction * Time.deltaTime) * 0.06f);
        }



    }
}
