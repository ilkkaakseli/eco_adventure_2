using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsMover : MonoBehaviour
{
	#region Member variables
		[SerializeField]
		private float speed = 1;

		private float speedModifier = 1;

		[SerializeField]
		private float jumpForce = 1;

		private Rigidbody2D rb2D;
		private InputReader2 inputReader;

		private bool isJumping = false;
		private Vector2 direction = Vector2.zero;
		private float jumpRate = 0.5f;
		private float jumpTimer = 0;
		//private bool isGrounded = false;
		private float modifierTimer = 0;
		bool facingRight = true;
	public float KBForce;
	public float KBCounter;
	public float KBTotalTime;

	public bool knockFromRight;

	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;

	public Animator animator;
	public bool allowMovement = true;
		#endregion

	#region Unity Methods
		private void Awake()
		{
			this.rb2D = GetComponent<Rigidbody2D>();
			this.inputReader = GetComponent<InputReader2>();
		}

		private void Update()
		{
			this.direction = inputReader.GetMovement();

			bool isJumping = inputReader.IsJumping();
			if (!this.isJumping && isJumping)
			{
				this.isJumping = true;
			}

			UpdateJumpTimer(Time.deltaTime);

			UpdateModifierTimer();

        animator.SetBool("isJumping", !CanJump());


    }

		private void UpdateModifierTimer()
		{
			if (modifierTimer > 0)
			{
				modifierTimer -= Time.deltaTime;

				if (modifierTimer <= 0)
				{
					speedModifier = 1;
				}
			}
		}

		private void FixedUpdate()
		{
			if(allowMovement)
			{
				if (KBCounter <= 0)
				{
					Move(this.direction);
				}
				else
				{
					if (knockFromRight == true)
					{
						rb2D.velocity = new Vector2(-KBForce, KBForce / 10);
					}
					if (knockFromRight == false)
					{
						rb2D.velocity = new Vector2(KBForce, KBForce / 10);
					}
					KBCounter -= Time.deltaTime;
				}

				if (this.isJumping)
				{
					Jump();

					// Jump input consumed
					this.isJumping = false;
				}
			} 
			else
			{
				rb2D.velocity = new Vector2(0,0);
				animator.SetFloat("Speed", 0);
			}	
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Enemy"))
			{
				this.isJumping = false;
			}
		}

    #endregion

    #region Internal functionality
    private void UpdateJumpTimer(float deltaTime)
		{
			if (this.jumpTimer > 0)
			{
				this.jumpTimer -= deltaTime;
			}
		}

		public void Jump()
		{
		
			if (this.jumpTimer > 0)
			{
				// Jump on cooldown, can't jump again just yet.
				return;
			}

			if (CanJump())
			{
				if(AudioManager.Instance != null)
				{
					AudioManager.Instance.PlaySFX("Jump");
				}
				
				this.rb2D.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse);
				this.jumpTimer = this.jumpRate;
			}
		}

		private void Move(Vector2 direction)
		{
			Vector2 velocity = this.rb2D.velocity;
			velocity.x = this.direction.x * this.speed * this.speedModifier;
			this.rb2D.velocity = velocity;
			
			if(direction.x > 0 && !facingRight)
			{
				Flip();
			} else if (direction.x < 0 && facingRight)
			{
				Flip();
			}

			animator.SetFloat("Speed", Math.Abs(velocity.x));

        }
		#endregion

	public void ApplySpeedModifier(float modifier, float time)
	{
		this.speedModifier = modifier;
		this.modifierTimer = time;
	}

	private bool CanJump()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
	}

	void Flip()
	{

		Vector3 currentScale = gameObject.transform.localScale;
		currentScale.x *= -1;
		gameObject.transform.localScale = currentScale;

		facingRight = !facingRight;

	}

	public void switchMoving()
	{
		allowMovement = !allowMovement;
	}
}
