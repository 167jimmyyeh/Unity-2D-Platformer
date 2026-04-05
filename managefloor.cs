using UnityEngine;

public class managefloor : MonoBehaviour
{
    [SerializeField] GameObject[] floor;
    public void Spawn()
    {
	    int r = Random.Range(0, floor.Length);
	    GameObject a = Instantiate(floor[r], transform);
	    a.transform.position = new Vector3(Random.Range(-3.4f,3.4f),-4f,0);
    }
}
