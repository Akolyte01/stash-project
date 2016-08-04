using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public Text suspicionText;
    public Text scoreText;
    public Text escapeText;
    public Text winText;
    public Slider suspicionSlider;
    public Slider scoreSlider;
    public Slider scoreSliderExt;
    public MasterController masterController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        suspicionText.text = "Suspicion: " + Mathf.Round(masterController.suspicionLevel);
        scoreText.text = "Score: " + Mathf.Round(masterController.score);
        if(masterController.score > 100) {
            winText.text = "YOU WIN!\r BONUS: " + Mathf.Round(masterController.score-100);
        } else winText.text = "YOU WIN!";
        
        suspicionSlider.value = masterController.suspicionLevel;
        scoreSlider.value = masterController.score;
        scoreSliderExt.value = masterController.score - 100f;
        if(masterController.score >= 100) {
            escapeText.enabled = true;
        }else escapeText.enabled = false;
	}
}
