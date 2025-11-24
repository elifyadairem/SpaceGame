using JetBrains.Annotations;
using System.Collections;
using UnityEngine;


public class Player_sc : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]  //private yazmadan private yapma
    private float speed = 500;

    [SerializeField]
    private GameObject laserPrefab;// mermi prefab’ýný buraya atayacaðýz

    [SerializeField]
    GameObject shieldVisualizer;

    private float fireRate = 0.25f; //saniyede ateþ etme sýnýrý
    private float canFire = 0f;
   
    [SerializeField]
    private int lives = 3;
    
    [SerializeField]
    bool isTripleShotActive = false;

    [SerializeField]
    GameObject tripleLaserPrefab;

    float speedMultiplier = 2;

   // [SerializeField]
    //bool isSpeedBonusActive = false;

    [SerializeField]
    bool isShieldBonusActive = false;

    [SerializeField]
    GameObject shield;

    [SerializeField]
    int score = 0;

    [SerializeField]
    UIManager_sc uiManager_sc;




    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
        if (uiManager_sc != null)
        {
            Debug.Log("Player_sc:: Start Hata - uiManger_sc NULL deðerine sahip");
        }


    }

    // Update is called once per frame
    void Update()
    {
        shield.SetActive(isShieldBonusActive);
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space)&&Time.time>canFire)
        {          
            canFire = Time.time + fireRate;
            ShootLaser();
        }

        
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
    public void ShootLaser()
    {
        if (!isTripleShotActive)
        {
            
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1.11F, 0),
                Quaternion.identity);//insantiate=prefabdan yeni merme nesnesi oluþturur
        }
        else
        {
            
            Instantiate(tripleLaserPrefab, (this.transform.position),
                Quaternion.identity);//insantiate=prefabdan yeni merme nesnesi oluþturur
        }       
    }

    public void damage()
    {
        //koruma kalkaný aktifse,caný azalmasýn ama koruma kalkaný pasif duruma dönsün
        if (isShieldBonusActive)
        {
            isShieldBonusActive = false;
            return;
        }
        //koruma kalkaný aktif deðilse cani bir azzalýr
        lives--;
        if (uiManager_sc != null)
        {
            uiManager_sc.UpdateLives(lives);
        }

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
        
    

        public void tripleshotActive()
    {
           isTripleShotActive = true;
           StartCoroutine(TripleShotCancelRoutine());
    }


    public void AddScore(int point)
    {
        score += point;
        uiManager_sc.UpdateScore(score);

    }
    public void SpeedBonusActive()
    {
       // isSpeedBonusActive = true;
        speed *= speedMultiplier;
        StartCoroutine(SpeedBonusCancelRoutine());

    }

    public void ShieldBonusActive()
    {
        isShieldBonusActive = true;
      

    }

    IEnumerator TripleShotCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }

    IEnumerator SpeedBonusCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        //isSpeedBonusActive = false;
        speed /= speedMultiplier;
    }

    IEnumerator SheildBonusCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isShieldBonusActive = false;
        
    }
}