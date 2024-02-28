using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class ScriptPlunger : MonoBehaviour
{
  float power;
  float minPower = 0f;
  public float maxpower=100f;
  public Slider PowerSlider;
  List<Rigidbody> balllist;
  bool ballReady;

    public object Private { get; private set; }

    void Start ()
  {
    PowerSlider.minValue = 0f;
    PowerSlider.maxValue = maxpower;
    balllist = new List<Rigidbody>();
  }

  void update ()
  {
    if (ballReady)
    {
      PowerSlider.gameObject.SetActive(true);
    }
    else
    {
      PowerSlider.gameObject.SetActive(true);
    }

    PowerSlider.value = power;
    if(balllist.Count > 0)
    {
      ballReady = true;
      if (Input.GetKey(KeyCode.Space))
      {
        if(power <= maxpower)
        {
          power += 50 * Time.deltaTime;
        }
      }
       if (Input.GetKeyUp(KeyCode.Space))
      {
        foreach ( Rigidbody r in  balllist)
        {
          r.AddForce(power*Vector3.forward);
        }
      }
    }
    else
    {
      ballReady = false;
      power = 0f;
    }

  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("ball"))
    {
      balllist.Add(other.gameObject.GetComponent<Rigidbody>());
    }
  }
  void OnTriggerExit(Collider other)
  {
    balllist.Remove(other.gameObject.GetComponent<Rigidbody>());
    power = 0f; 
  }
}
