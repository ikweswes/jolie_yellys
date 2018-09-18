using UnityEngine;

public class TypeWriter : MonoBehaviour {
	[SerializeField] private string _textToShowOnScreen = "";
	[SerializeField] private float _delayBetweenCharacters = 0.5f;
	private float _startTime;
	private int _textIndex;
	private bool _isDoneSaying = false;
	private bool _isStarted = false;
	private TextMesh _textMesh;

	public void Say(string text) {
		_textIndex = 0;
		_textToShowOnScreen = text;
		_startTime = 0;
		//_textMesh.text = "";
		_isStarted = true;
	}

	protected void Start() {
		_textMesh = this.GetComponentInChildren<TextMesh>();
		_textMesh.text = "";
	}

	protected void Update () {
		if(Input.GetKeyDown(KeyCode.Y)) {
			Say(_textToShowOnScreen);
		}
		if(_isDoneSaying || !_isStarted || (_startTime + Time.deltaTime) < _delayBetweenCharacters) {
			_startTime += Time.deltaTime;
			return;
		}

		_startTime -= _delayBetweenCharacters;
		if(_textIndex == _textToShowOnScreen.Length) {
			_isDoneSaying = true;
		} else {
			_textMesh.text += _textToShowOnScreen[_textIndex++];
		}



	}
}
