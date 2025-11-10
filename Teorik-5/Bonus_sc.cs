using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    
 
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -5.8f)
        {

            Destroy(this.gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //üçlü atýþ bonusunu aktifleþtir
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            if (player_sc != null)
            {
                player_sc.tripleshotAvtive();
            }
            //bonus nesnesini yok et.
            Destroy(this.gameObject);

        }
    }
}
