using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame


    private void Update()
    {
        body.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * speed, body.angularVelocity * speed, body.angularVelocity);

        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector3(body.angularVelocity, speed, body.angularVelocity);
        }
            
    }
      
   


}
