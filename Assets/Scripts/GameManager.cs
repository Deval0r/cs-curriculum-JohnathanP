using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript gm;
    public int coins;

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
}
