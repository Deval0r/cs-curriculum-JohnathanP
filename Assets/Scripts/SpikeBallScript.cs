using UnityEngine;

public class SpikeBallScript : MonoBehaviour
{ private int timer;
  private float frequency;
  private int amount;
    private void Start()
    {
        timer = Random.Range(0, 100000);
        frequency = Random.Range(0.003f, 0.0045f);
        amount = Random.Range(300, 400);
    }




    void Update()
    {
        timer += 1;
   
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(0, Mathf.Sin(timer * frequency) * frequency, 0);
        transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(timer * frequency) * amount);

    }
}
