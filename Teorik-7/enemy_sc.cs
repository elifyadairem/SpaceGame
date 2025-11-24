using UnityEngine;

public class enemy_sc : MonoBehaviour
{

    [SerializeField]
    int speed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Player_sc player_sc;
    void Start()
    {
      player_sc = GameObject.Find("Player").GetComponent<Player_sc>();
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

     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Çarpýþma : " + other.tag);
        if(other.tag == "Player")
        {
            //player ýn canýný bir eksilt
            //Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            if (player_sc != null)
            {
                player_sc.damage();
            }
            

            Destroy(this.gameObject);
        }
        else if(other.tag == "laser")
        {
            //Player_sc player_sc = other.transform.GetComponent<Player_sc>(); buyöntem kllanýlmaz çünkü other dediðimiz þey lazer

            Destroy(other.gameObject); //çarpýþtýðý lazeri yok et
            if (player_sc != null)
            {
                //puaný arttýr
                player_sc.AddScore(10);
            }
            
            //kendini yok et
            Destroy(this.gameObject); 
            
        
        }
    }
}
