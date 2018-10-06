using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Is pretty much here to just hold sentences for characters
//Lets you play with it in menu
[System.Serializable]
public class Dialogue {
    //character name
	public string name;
    //max size of text
	[TextArea(3, 10)]
    //holds all sentences
	public string[] sentences;
}
