using UnityEngine;

public class manageapple : MonoBehaviour
{
    [SerializeField] GameObject[] apple;
    public void Spawn()
    {
	    int r = Random.Range(0, apple.Length);
	    GameObject a = Instantiate(apple[r], transform);
	    a.transform.position = new Vector3(Random.Range(-3.4f,3.4f),Random.Range(-3.4f,3.4f),0);
    }
}
