using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditorInputField : InputField {
	protected override void LateUpdate() {
		base.LateUpdate ();
		this.MoveTextEnd (false);
	}
}
