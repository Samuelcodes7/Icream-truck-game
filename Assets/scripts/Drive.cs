using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Drive : MonoBehaviour
{
    [SerializeField]float currentspeed = 5f;
    [SerializeField]float steerspeed = 200f;
    [SerializeField]float Boostspeed = 10f;
    [SerializeField]float regularspeed = 5f;
    [SerializeField] TMP_Text BoostText;


    void Start()
    {
        BoostText.gameObject.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Boost"))
        {
            currentspeed = Boostspeed;
            BoostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WorldCollision"))
        {
            currentspeed = regularspeed;
            BoostText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
         float move = 0f;
         float steer = 0f;
        
       
       

         if(Keyboard.current.wKey.isPressed)
        {
            move =1f;
           
        }
         else if(Keyboard.current.sKey.isPressed)
        {
            move =-1f;
           
        }
         if(Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
           
        }
       
        else if(Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }
       
      
        
        
        
        float moveamount = move * currentspeed * Time.deltaTime;
        float steeramount = steer * steerspeed * Time.deltaTime;
         
         transform.Translate(0, moveamount, 0);
         transform.Rotate(0, 0, steeramount);
        

        
    }
    
}
