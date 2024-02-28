using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class bumbercontroller : MonoBehaviour
{
  public ScoreManager scoreManager;
	
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.collider == bola)
		{
		

      //tambah score saat menabrak bumper
      scoreManager.AddScore(99);
    }
  }

    
  public Collider bola;
  public float multiplier;
  public Color color;

  private Renderer renderer;
  private Animator animator;

  private void Start()
  {
    renderer = GetComponent<Renderer>();
    animator = GetComponent<Animator>();

    renderer.material.color = color;
  }

  private void OnCollisionStay(Collision collision)
  {
    if (collision.collider == bola)
    {
      Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
      bolaRig.velocity *= multiplier;

      animator.SetTrigger("hit");
    }
  }
}
