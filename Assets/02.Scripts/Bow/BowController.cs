using UnityEngine;
using UnityEngine.EventSystems;

public class BowController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[Header("References")]
	[SerializeField] private Shooter shooter;
	private Camera mainCam;

	[Header("Setting Values")]
	[SerializeField] private float maxDragDistance;

	[Header("Flags")]
	private bool isClicked = false;
	private Vector3 mousePos;

	private void Awake()
	{
		mainCam = Camera.main;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		isClicked = true;
		shooter?.Shoot(Vector2.up, 1f);
	}

	private void Update()
	{
		if (!isClicked) return;

		//mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Vector3 dir = mousePos - transform.position;
		//dir.z = 0;
		//dir.Normalize();
		//dir *= maxDragDistance * 3;
		//Debug.DrawLine(transform.position, transform.position + -dir);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isClicked = false;
		//float distanceDelta = Vector2.Distance(mousePos, transform.position);
		//float powerPercentage = distanceDelta / maxDragDistance;
		//powerPercentage = Mathf.Clamp(powerPercentage, 0, 1.0f);
		//Vector2 dir = transform.position - mousePos;
		//shooter?.Shoot(dir, powerPercentage);
	}
}
