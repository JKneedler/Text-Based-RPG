using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryFeed : MonoBehaviour {

	public TextAsset csvFile;
	private string[][] data;
	public Object storyElement;
	public Transform storyQueue;
	public Text[] optionTexts;
	private int curLine;

	// Use this for initialization
	void Start () {
		ProcessCSV ();
		GoToLine (0);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 4; i++) {
			if (Input.GetKeyDown ("" + i)) {
				PressedOption (i);
			}
		}
	}

	public void Output(string lineText){
		GameObject lineElement = (GameObject)Instantiate (storyElement, storyQueue);
		lineElement.transform.SetSiblingIndex (0);
		lineElement.GetComponent<Text> ().text = lineText;
	}

	public void ProcessCSV() {
		string[] lines = csvFile.text.Split ("\n" [0]);
		data = new string[lines.Length][];
		for (int i = 0; i < lines.Length; i++) {
			string[] lineData = (lines [i].Trim ()).Split ("," [0]);
			data [i] = lineData;
		}
	}

	public void GoToLine(int lineNum) {
		curLine = lineNum;
		Output (data [lineNum] [0]);
		if (int.Parse (data [curLine] [1]) == 0) {
			GoToLine (curLine + 1);
		} else {
			for (int i = 0; i < 2; i++) {
				int textIndex = ((i + 1) * 2) + 1;
				string optionString = data [lineNum] [textIndex];
				if (!optionString.Equals ("")) {
					optionTexts [i].text = (i + 1) + ") " + optionString;
				} else {
					optionTexts [i].text = "";
				}
			}
		}
	}

	public void PressedOption(int optionNum) {
		if (!optionTexts [optionNum - 1].text.Equals ("")) {
			int linkIndex = optionNum * 2;
			GoToLine (int.Parse(data [curLine] [linkIndex]) - 1);
		}
	}
}
