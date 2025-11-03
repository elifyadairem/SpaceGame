using UnityEngine;

public class enemy_sc : MonoBehaviour
{

    [SerializeField]
    int speed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed *  Time.deltaTime);

        if (this.transform.position.y < -5.5f)
        {


            //TODO: Playerýn canýnýn bir eksilt 

            this.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);// RANDOM.RANGE = X ekseninde rastgele pozisyon (sað-sol sýnýrlarý arasýnda).
        }

    }

     void OTriggerEnter2D(Collider2D other)
    {
       
        if(other.tag == "Player")
        {

           Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            player_sc.damage();

            Destroy(this.gameObject);
        }
        else if(other.tag == "laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject); 
            
        
        }
    }
}
