using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchligtht : MonoBehaviour
{
   public ScoreManager scoreManager;
	
  private void Toggle()
  {
    //tambah score saat menyalakan atau mematikan switch
    scoreManager.AddScore(0);
  }
 private enum SwitchState
  {
    Off,
    On,
    Blink
  }

  public Collider ball;
  public Material offMaterial;
  public Material onMaterial;

  private SwitchState state;
  private Renderer renderer;

  private void Start()
  {
    renderer = GetComponent<Renderer>();

    Set(false);

    StartCoroutine(BlinkTimerStart(5));
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other == ball)
    {
      Toggle();
    }
  }

  private void Set(bool active)
  {
    if (active == true)
    {
      state = SwitchState.On;
      renderer.material = onMaterial;
      StopAllCoroutines();
    }
    else
    {
      state = SwitchState.Off;
      renderer.material = offMaterial;
      StartCoroutine(BlinkTimerStart(5));
    }
  }

  private void togel()
  {
    if (state == SwitchState.On)
    {
      Set(false);
    }
    else
    {
      Set(true);
    }
  }

  private IEnumerator Blink(int times)
  {
    state = SwitchState.Blink;

    for (int i = 0; i < times; i++)
    {
      renderer.material = onMaterial;
      yield return new WaitForSeconds(0.5f);
      renderer.material = offMaterial;
      yield return new WaitForSeconds(0.5f);
    }

    state = SwitchState.Off;

    StartCoroutine(BlinkTimerStart(5));
  }

  private IEnumerator BlinkTimerStart(float time)
  {
    yield return new WaitForSeconds(time);
    StartCoroutine(Blink(2));
  }
}
