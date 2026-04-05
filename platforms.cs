using UnityEngine;

public class platforms : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movespeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,movespeed*Time.deltaTime,0);
	    if(transform.position.y > 5f)
        {
            Destroy(gameObject);
            transform.parent.GetComponent<managefloor>().Spawn(); 
	    }
    }
}
