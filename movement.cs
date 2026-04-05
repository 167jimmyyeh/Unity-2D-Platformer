using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movespeed = 3f;
    GameObject currentfloor;
    [SerializeField] int hp;
    [SerializeField] GameObject hpbar;
    [SerializeField] Text scoreText;
    [SerializeField] float passtime;
    [SerializeField] int score;
    [SerializeField] int pb = 0;
    [SerializeField] Text pbText;
    [SerializeField] GameObject replaybutton;
     private Animator animator;    
     void Start()
    {
        hp = 10;
        passtime = 0;
	    score = 0;
        animator = GetComponent<Animator>();

        pb = PlayerPrefs.GetInt("pb", 0);
        pbText.text = "Personal Best: " + pb.ToString();
    }

    // Update is called once per frame
   void Update()
{
    if (Input.GetKey(KeyCode.RightArrow))
    {
        transform.Translate(movespeed * Time.deltaTime, 0, 0);
        animator.SetBool("IsRunning", true);
        Vector3 newScale = transform.localScale;
        newScale.x = 4;
        transform.localScale = newScale;
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
        transform.Translate(-movespeed * Time.deltaTime, 0, 0);
        animator.SetBool("IsRunning", true);
        Vector3 newScale = transform.localScale;
        newScale.x = -4;
        transform.localScale = newScale;
    }
    else 
    {
        animator.SetBool("IsRunning", false);
    }
    updatescore();
}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "green")
        {
            Debug.Log("Alive");
            Debug.Log(other.contacts[0].normal);
            Debug.Log(other.contacts[1].normal);
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                currentfloor = other.gameObject;
                score += 5;
            }
        }
        if (other.gameObject.tag == "red")
        {
            Debug.Log("Dead");
            Debug.Log(other.contacts[0].normal);
            Debug.Log(other.contacts[1].normal);
            if (other.contacts[0].normal == new Vector2(0f, 1f))
            {
                currentfloor = other.gameObject;
                score -= 10;
            }
        }

        if(other.gameObject.tag == "spike")
        {
            currentfloor.GetComponent<BoxCollider2D>().enabled = false;
            modifyhp(-3);
        }

        if(other.gameObject.tag == "bomb")
        {
            modifyhp(-3);
        }

        if(other.gameObject.tag == "apple")
        {
            modifyhp(3);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pink")
        {
            death();
        }
    }
    void modifyhp(int num)
    {
	    hp += num;
        if (hp > 10)
        {
            hp = 10;
        }
        else if (hp <= 0)
        {
            hp = 0;
            death();
        }
	    updatehpbar(hp);
    }

    void updatehpbar(int hp)
    {
        for (int i = 0; i < hpbar.transform.childCount; i += 1)
        {
            if (hp > i)
            {
                hpbar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                hpbar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    void updatescore()
    {
        passtime += Time.deltaTime;
        if (passtime > 0.5f)
        {
            score += 1;
            passtime = 0f;
            scoreText.text = "Score: " + score.ToString();
        }
        if (score <= 0)
        {
            score = 0;
        }
    }
    void death()
    {
        Time.timeScale = 0f;
        replaybutton.SetActive(true);
        if (score > pb)
        {
            pb = score;
            PlayerPrefs.SetInt("pb", pb);
            PlayerPrefs.Save();
        }
    }

    public void replay() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
