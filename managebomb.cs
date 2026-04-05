using UnityEngine;

public class managebomb : MonoBehaviour
{
    [SerializeField] GameObject[] bomb;
    public void Spawn()
    {
	    int r = Random.Range(0, bomb.Length);
	    GameObject a = Instantiate(bomb[r], transform);
	    a.transform.position = new Vector3(Random.Range(-3.4f,3.4f),7f,0);
    }
}
