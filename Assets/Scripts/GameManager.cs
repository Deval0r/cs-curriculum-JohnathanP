using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript gm;
    public int coins;
    public int health;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI healthText;
    private void Start()
    {
        coinsText.text = "Coins:" + coins;
        healthText.text = "Health:" + health;
    }

    private void Awake()
    {

       
        if (gm != null && gm != this)
        {
           Destroy(this.gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        coinsText.text = "Coins:" + coins;
        healthText.text = "Health:"+health;
        if (gm.health < 1)
        {
            Application.Quit();

        }

    
        if (health < 1)
        {
            SceneManager.LoadScene("Start");
        }
    
    }



}


