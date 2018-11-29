using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Target"){
			Destroy(col.gameObject);
			ScoreManager.Instance.Addscore();
			Destroy(this.gameObject);
		}
	}
}
