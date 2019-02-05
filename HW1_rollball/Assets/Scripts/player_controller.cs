using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class player_controller : MonoBehaviour
{
    public float speed;
    public Text CountText;
    public Text WinText;

    public Rigidbody rb;
    private int count;


    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(move_horizontal, 0f, move_vertical);

        rb.AddForce(movement * speed);
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
        CountText.text = "Count: " + count.ToString();
        if (count >= 11)
            WinText.text = "You Win!";
    }
}