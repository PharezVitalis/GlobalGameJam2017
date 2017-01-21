using UnityEngine;
using System.Collections;

public class SpinningHUDImage : MonoBehaviour {

    private bool m_spinning = true;
    private float m_spinSpeed;

    void Start()
    {
        m_spinSpeed = Random.Range(-0.25f, 0.25f);
    }
	
	void Update ()
    {
        if (m_spinning)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1) * m_spinSpeed);
        }
	}
}
