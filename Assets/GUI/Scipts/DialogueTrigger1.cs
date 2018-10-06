using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger1 : MonoBehaviour {

    //So you can snap in a dialogue sequence to speak
	public Dialogue dialogue;

    //Finds the Dialogue Manager
	public void TriggerDialogue(){
		FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);

	}
}
