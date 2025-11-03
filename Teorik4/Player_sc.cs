using UnityEngine;


public class Player_sc : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]  //private yazmadan private yapma
    private float speed = 500;

    [SerializeField]
    private GameObject laserPrefab;// mermi prefab’ýný buraya atayacaðýz

    

    private float fireRate = 0.25f; //saniyede ateþ etme sýnýrý
    private float canFire = 0f;
    [SerializeField]
    private int lives = 3;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        ShootLaser();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//yatay-yukarýaþaðý
        float verticalInput = Input.GetAxis("Vertical");//dikey-ileri geri

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);


        transform.position = new Vector3(transform.position.x,
                  Mathf.Clamp(transform.position.y, -3.8f, 0), 0); //Unity’de bir sayýyý belli bir aralýða sýkýþtýrýr.
        
                if (transform.position.x > 11.3f)
                {
                    transform.position = new Vector3(-11.3f, transform.position.y, 0);
                }
                else if (transform.position.x < -11.3f)
                {
                    transform.position = new Vector3(11.3f, transform.position.y, 0);
                }
        
    }
    void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire) //time.time = oyun baþladýktan sonra geçen süre
        {
            canFire = Time.time + fireRate;
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);//insantiate=prefabdan yeni merme nesnesi oluþturur

            //Quaternion = “hiç döndürme, olduðu gibi oluþtur”.
        }

    }

    public void damage()
    {
        lives--;
        if (lives == 0)
        {

            spawnManager_sc spawnmanager_sc = GameObject.Find("spawnManager").
                                                       GetComponent<spawnManager_sc>();
            if (spawnmanager_sc != null)
            {
                spawnmanager_sc.OnPlayerDeath();
            }
            else
            {
                Debug.LogError("Player_sc: :Damage spawnManager_sc is NULL");
            }

            Destroy(this.gameObject);
           
        }
            
       
    }
}