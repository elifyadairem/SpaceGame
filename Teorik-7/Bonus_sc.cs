using UnityEngine;

public class Bonus_sc : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    [SerializeField]
    int bonusId;

    
 
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
                switch (bonusId)
                {
                    //0 üçlü atýþ bonusunu temsil eder
                    case 0:
                        player_sc.tripleshotActive();
                        break;
                    //1 hýz bonusunu temsil eder
                    case 1:
                        player_sc.SpeedBonusActive();
                        break;
                    //kalkan bonusunu temsil eder
                    case 2:
                        player_sc.ShieldBonusActive();
                        break;
                    //yalnýzca 3 tane tanýmladýk bunlarýn dýþýndakiler hata alsýn
                    default:
                        Debug.Log("hata durumu");
                        break;


                }
         
            }
            //bonus nesnesini yok et.
            Destroy(this.gameObject);

        }
    }
}
