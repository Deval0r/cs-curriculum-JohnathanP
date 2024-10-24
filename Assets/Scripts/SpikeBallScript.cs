using UnityEngine;

public class SpikeBallScript : MonoBehaviour
{
    private int timer = Random.Range(0, 10000);



    void Update()
    {
        timer += 1;
   
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(0, Mathf.Sin(timer * 0.003f) * 0.003f, 0);
        transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(timer * 0.003f) * 300f);

    }
}
