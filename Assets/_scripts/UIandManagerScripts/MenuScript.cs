using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
    [SerializeField]
    private Canvas _creditMenu;
    [SerializeField]
    private Button _startText;
    [SerializeField]
    private Button _exitText;

	//Gets all the text and menu components
	void Start () {
        _startText = _startText.GetComponent<Button>();
        _creditMenu = _creditMenu.GetComponent<Canvas>();
        _exitText = _exitText.GetComponent<Button>();
        _creditMenu.enabled = false;
	}
    //When you press the Start button it loads scene1
    public void StartLevel()
    {
        SceneManager.LoadScene("scene1");
    }
    //When you press the credit button it'll go to the credit menu
    public void ExitPress()
    {
        _creditMenu.enabled = true;
        _startText.enabled = false;
        _exitText.enabled = false;
    }
    //when you press the button inside the creditmenu, it goes back to the normal menu again.
    public void NoPress()
    {
        _creditMenu.enabled = false;
        _startText.enabled = true;
        _exitText.enabled = true;
    }
}
