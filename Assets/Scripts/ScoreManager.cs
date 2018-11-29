using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;


public class ScoreManager : SingletonMonoBehaviour<ScoreManager>  {
	int score = 0;
	[SerializeField]
	Text scoretext;
	public Target target;
	// Use this for initialization
	void Start () {
		scoretext.text = "Score:"+score;
	}
	// Update is called once per frame
	void Update () {
		scoretext.text = "Score:"+score;
	}
	public void Addscore(){
		score++;
		target.createtarget = false;
	}
}
