using UnityEngine;
using UnityEngine.Rendering;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField]float destroyDelay = 0.5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if the tag is package then print somthing to conqole 
        //then (print picked up in consule)
      
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
        }

         if (collision.CompareTag("costumer") && hasPackage)
        {
            
                Debug.Log("Package delivered");
                hasPackage = false;
                GetComponent<ParticleSystem>().Stop();
                Destroy(collision.gameObject, destroyDelay);
                              
        }
    }
    
}
