using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CreateBallButton : MonoBehaviour {
	Button button;
	int movespeed = 3;
	[SerializeField]
	private GameObject ballPref;
	Transform cameratransform;
	
	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		this.button.OnClickAsObservable()
            .Subscribe(_ =>CreateBall()); 
	}
	void CreateBall(){
		cameratransform = Camera.main.transform;
		GameObject ball =  Instantiate(ballPref,cameratransform);
		Rigidbody rb = ball.GetComponent<Rigidbody>();
		rb.AddForce(cameratransform.forward*movespeed,ForceMode.Impulse);
		Destroy(ball,5.0f);
	}
}
