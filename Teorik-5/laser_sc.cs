using UnityEngine;

public class laser_sc : MonoBehaviour
{
    private float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (this.transform.position.y > 7.0f)
        {
            if(this.transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }






    //fonksiyonu silebilir misin?
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject); // düþmaný yok et
            Destroy(gameObject);
        }
    }
}
