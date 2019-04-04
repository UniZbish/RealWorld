using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatcherry : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
{
	if (col.gameObject.tag == "cherry")
	{
		Destroy(col.gameObject);
	}
}
}
