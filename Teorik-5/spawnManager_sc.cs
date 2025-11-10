using System.Collections;
using UnityEditor;
using UnityEngine;

public class spawnManager_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemyprefab;

    [SerializeField]
    GameObject tripleShotBonusPrefab;
    
    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    bool stopSpawning = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());//bu  özel bir fonksiyonu arka planda döngüsel olarak çalıştırır.Coroutine, Unity’de zaman kontrollü işlemler yapmak için kullanılır
                                            //(örneğin “her 5 saniyede bir düşman üret”).Burada başlatılan coroutine’in adı SpawnRoutine().
        StartCoroutine(SpawnBonusRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()  //Coroutine fonksiyonlarının dönüş tipi `IEnumerator` olmak zorundadır.  
                                     //Bu sayede Unity, fonksiyonun belirli yerlerde “beklemesini” (`yield return`) sağlar.
                                    // Yani fonksiyon **tek seferde değil**, “aralıklarla” çalışır.
    {
        
        while (stopSpawning == false)    //Sonsuz döngü anlamına gelir.  
                                        // -Bu sayede oyun devam ettiği sürece düşmanlar sürekli spawn edilir.
                                        // Ama oyun durduğunda ya da player öldüğünde bu döngü kontrol altına alınmalıdır(örneğin `while (isGameActive)` gibi).  
                                        //Şimdilik temel mantıkta olduğu için `true` bırakılmış.
       
        
        
        {
            Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);

            GameObject enemy = Instantiate(Enemyprefab, position, Quaternion.identity);
            enemy.transform.parent = enemyContainer.transform;
            
            yield return new WaitForSeconds(5.0f);   // Coroutine burada **5 saniye bekler** ⏳  
                                                    //-5 saniye dolunca döngü başa döner, yeni düşman oluşturulur.
        }
    }

    IEnumerator SpawnBonusRoutine()
    {

        while (stopSpawning == false)
        {
            int waitTime = Random.Range(5, 10);
            Debug.Log("Üçlü atış bekleme süresi: " + waitTime);
            yield return new WaitForSeconds((float) waitTime);

            Vector3 position = new Vector3(Random.Range(-9.18f, 9.18f),
                                            7.7f, 0);
            GameObject tripleShotBonus = Instantiate(tripleShotBonusPrefab, position, Quaternion.identity);

        }
    }

    public void OnPlayerDeath() //static olsaydı player içinden  " .(metot adı)" olarak çağıralbilirdi
    {
        stopSpawning = true;
    }
}
