using UnityEngine;
using System.Collections;

public class BreakableBoxScript : MonoBehaviour
{
    public GameObject coin;
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
	}

    void OnCollisionEnter (Collision collider)
    {
        //Debug.Log("Hit");
        if (collider.gameObject.CompareTag("Player")&&collider.gameObject.transform.position.y>transform.position.y+0.3f)
        {
            //Debug.Log("Hit");
            collider.gameObject.GetComponent<Rigidbody>().AddForce(0, 600, 0);
            for(int i = 0;i<5;i++)
            {
                GameObject clone = Instantiate(coin,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity) as GameObject;
                clone.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100.0f,100.0f),300.0f,0.0f));
            }
            Destroy(gameObject);
        }
    }
}
