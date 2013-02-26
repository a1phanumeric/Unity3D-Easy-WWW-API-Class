using UnityEngine;
using System.Collections;

public class Nullable : MonoBehaviour {

	public static implicit operator bool(Nullable o) {
		return (object)o != null;
	}
}
