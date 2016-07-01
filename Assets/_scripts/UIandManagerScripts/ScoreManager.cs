using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    public Text _scoreText;
    public float score;
	// Sets the score at 0 at the beginning of the game
	void Start () {
        score = 0;
	}
	// activates UpdateScoreUI() every frame
	void Update () {
        UpdateScoreUI();
    }
    //Updates the Score UI to the current score.
    private void UpdateScoreUI()
    {
        _scoreText.text = "Score:" + score.ToString();
    }
}
