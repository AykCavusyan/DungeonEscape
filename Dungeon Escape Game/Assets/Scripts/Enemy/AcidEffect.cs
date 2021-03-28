using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField] private int speed;
   
    

    // Start is called before the first frame update
    private void Start()
    {
        speed = 3;
        StartCoroutine(SelfDestroyAcidBall());
    }

    // Update is called once per frame
    private void Update()
    {

        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerGameObject")
        {
            IDamageable hit = collision.gameObject.GetComponent<IDamageable>();

            if (hit != null)
            {
                Debug.Log("Acid Hits player");
                hit.Damage();
                StopCoroutine(SelfDestroyAcidBall());
                Destroy(gameObject);
            }
        }

        
    }

    IEnumerator SelfDestroyAcidBall()
    {
        yield return new WaitForSeconds(5f);
            Destroy(gameObject);
    }
}
