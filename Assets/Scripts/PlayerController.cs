using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	//public AudioSource ping;
	public AudioClip impact;
	AudioSource audio;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		audio = GetComponent<AudioSource>();
		count = 0;
		countText.text = "Count: " + count.ToString ();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speed);
		if (Input.GetKey("escape"))
			Application.Quit();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			countText.text = "Count: " + count.ToString ();
			audio.PlayOneShot(impact);
			if (count >= 12) {
				winText.text = "You Win!";

			}
		}

	}

}
