using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text timerText;


    public float targetTime = 60.0f;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        targetTime -= Time.deltaTime;
        timerText.text = "TIME: " + targetTime.ToString();

        if (targetTime <= 0.0f)
        {
            loseText.text = "You lose!";
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }

    void SetCountText()
    {

        countText.text = "COUNT: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }

    }
}

  



