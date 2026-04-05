using UnityEngine;

public class bomb : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movespeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-movespeed*Time.deltaTime,0);
	    if(transform.position.y < -4f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<managebomb>().Spawn(); 
	    }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            transform.parent.GetComponent<managebomb>().Spawn(); 
        }
    }
}