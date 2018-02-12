using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

	public GameObject explosion;
	 public GameObject playerExplosion;
	   public Text winText;


		 void Start ()
		 {
		 		 winText.text = "";
		 }
	 void OnTriggerEnter(Collider other)
	 {
			 if (other.tag == "Boundary")
			 {
				  winText.text = "You lose";
					 return;
			 }
			 Instantiate(explosion, transform.position, transform.rotation);
			 if (other.tag == "Player")
			 {
           winText.text = "You lose";
					 Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
					 //gameController.GameOver ();
			 }
			 winText.text = "You lose";
			 Destroy(other.gameObject);
			 Destroy(gameObject);
	
	 }


}
