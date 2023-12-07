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
	}

	private void Update()
	{
		if (!isClicked) return;

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Debug.DrawLine(transform.position, mousePos);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isClicked = false;
		float distanceDelta = Vector2.Distance(mousePos, transform.position);
		float powerPercentage = distanceDelta / maxDragDistance;
		powerPercentage = Mathf.Clamp(powerPercentage, 0, 1.0f);
		Vector2 dir = transform.position - mousePos;
		shooter?.Shoot(dir, powerPercentage);
	}
}
