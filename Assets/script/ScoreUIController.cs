using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUIController : MonoBehaviour
{
 	// reference ke text score nya
	// disini menggunakan TMP_Text karena yang dipakai adalah TextMeshPro
	// Jangan salah ya, yang nantinya dimasukan ke sini adalah text angka, bukan title nya
  public TMP_Text scoreText;
  public ScoreManager scoreManager;

  private void Update()
  {
    scoreText.text = scoreManager.score.ToString();
  }
}
