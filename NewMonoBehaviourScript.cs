using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int speed = 3;//public speed deðeri unity üzerinden deðiþtirebiliriz ama private olursa deðþitremeyiz
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      //  transform.position = new Vector3(5, 0, 0); //nesnenin pozisyonunu direkt deðiþtiriyoruz

    }

    // Update is called once per frame
    void Update()
    {
      //  transform.Translate(Vector3.right); nesnenin sürekli saða gitmeisin saðlarýz
      //  transform.Translate(Vector3.right * speed * Time.deltaTime);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),
                                        Input.GetAxis("Vertical"),
                                        0)
                                    * Time.deltaTime
                                    * speed);

    }
}
