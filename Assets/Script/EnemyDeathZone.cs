using UnityEngine;

public class EnemyDeathZone : MonoBehaviour
{
    public bool enabled;
    public Material defMat, disable;
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
		//IMPORTANT : A tej plus tard, debug
		if (Input.GetKeyDown("e"))
		{
            SwitchState();
		}
	}

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.CompareTag("Enemy") && enabled)
		{
			Destroy(other.gameObject);
		}
	}


    public void SwitchState()
    {
        enabled = !enabled;
        if (enabled) meshRenderer.material = defMat; else { meshRenderer.material = disable; }
    }

    public void SetState(bool state)
    {
		enabled = state;
		if (enabled) meshRenderer.material = defMat; else { meshRenderer.material = disable; }
	}
}
