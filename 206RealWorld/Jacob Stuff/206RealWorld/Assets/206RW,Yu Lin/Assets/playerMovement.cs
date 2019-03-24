using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

	public float Movespeed , JumpForce;
    // Start is called before the first frame update
	bool Jumpcheck;
	bool Groundcheck;


	 Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
		{
			transform.Translate(Vector3.left*Movespeed*Time.deltaTime);
			anim.SetFloat("Speed", Movespeed);
    	}
		   else anim.SetFloat("Speed", 0);

		             if (Input.GetKey("right"))
		{
			transform.Translate(Vector3.right*Movespeed*Time.deltaTime);
			anim.SetFloat("Speed", Movespeed);
    	}
		              else anim.SetFloat("Speed", 0);

		        if (Input.GetKey("up") && Jumpcheck == true)
        {
		    GetComponent<Rigidbody2D>().AddForce(transform.up * JumpForce);
			Jumpcheck = false;
			anim.SetBool("Groundcheck", true);
			anim.SetBool("JumpCheck", false);
		}
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.name == "Ground")
		{
			Jumpcheck = true;
			anim.SetBool("Groundcheck", false);
			anim.SetBool("JumpCheck", true);
		}
	}

		void OnCollisionExit2D(Collision2D col)
	{
		if (col.transform.name == "Ground")
		{
			Jumpcheck = false;

		}
	}



}


