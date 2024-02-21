using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanAndZoom : MonoBehaviour
{
	[Header("Panning and Zooming")]
	[SerializeField] float panAndZoomDuration = 0.2f;

	[Header("Panning - Follow Mouse")]
	[SerializeField] float defaultFollowMouseRatio = 0.001f;
	float unitHoveredFollowMouseRatio;
	float unitSelectedFollowMouseRatio;
	float followMouseRatio;

	[Header("Panning - Pan Over Time")]
	[SerializeField] Vector2 unitHoveredCameraOffsetFromCenter = new Vector2(-0.15f, -0.06f);
	[SerializeField] Vector2 unitSelectedCameraOffsetFromUnit;
	Vector2 screenCenter;
	Vector2 prevTargetPosition;
	Vector2 newTargetPosition;
	Vector2 currentFollowMousePosition;
	Vector2 currentPanPosition;

	[Header("Zooming")]
	[SerializeField] float defaultSize = 5f;
	[SerializeField] float unitHoveredSize;
	[SerializeField] float unitSelectedSize;
	float prevTargetSize;
	float newTargetSize;
	bool isZoomingOutFromUnitSelected;

	void Start()
	{
		// Initialize pan variables
		// Follow mouse
		float defaultToUnitHoveredRatio = unitHoveredSize / defaultSize;
		unitHoveredFollowMouseRatio = defaultFollowMouseRatio * defaultToUnitHoveredRatio;

		float defaultToUnitSelectedRatio = unitSelectedSize / defaultSize;
		unitSelectedFollowMouseRatio = defaultFollowMouseRatio * defaultToUnitSelectedRatio;

		followMouseRatio = defaultFollowMouseRatio;

		// Pan over time
		screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
		prevTargetPosition = Vector2.zero;
		newTargetPosition = Vector2.zero;
		currentFollowMousePosition = Vector2.zero;
		currentPanPosition = Vector2.zero;

		// Initialize zoom variables
		prevTargetSize = defaultSize;
		newTargetSize = defaultSize;
		isZoomingOutFromUnitSelected = false;
	}

	void Update()
	{
		// Camera Panning:
		// Check if the mouse is within the game window
		if (MouseIsWithinWindow())
		{
			// Follow mouse
			Vector2 mousePosition = Input.mousePosition;
			Vector2 mousePositionFromCenter = mousePosition - screenCenter;
			currentFollowMousePosition = mousePositionFromCenter * followMouseRatio;
		}
		// Pan over time
		Vector2 panPositionChange = new Vector2(Mathf.Abs(prevTargetPosition.x - newTargetPosition.x), Mathf.Abs(prevTargetPosition.y - newTargetPosition.y));
		Vector2 panPositionChangePerSecond = new Vector2(panPositionChange.x / panAndZoomDuration, panPositionChange.y / panAndZoomDuration);
		Vector2 newPanPosition = new Vector2(Mathf.MoveTowards(currentPanPosition.x, newTargetPosition.x, panPositionChangePerSecond.x * Time.deltaTime),
											Mathf.MoveTowards(currentPanPosition.y, newTargetPosition.y, panPositionChangePerSecond.y * Time.deltaTime));
		currentPanPosition = newPanPosition;

		// Move camera
		Vector2 newPosition = newPanPosition + currentFollowMousePosition;
		transform.position = new Vector3(newPosition.x, newPosition.y, -10f);


		// Camera Zooming:
		// Check if zooming out from unit selected
		isZoomingOutFromUnitSelected = (prevTargetSize == unitSelectedSize && (newTargetSize == defaultSize || newTargetSize == unitHoveredSize) && Camera.main.orthographicSize != newTargetSize);

		float sizeChange = Mathf.Abs(prevTargetSize - newTargetSize);
		float sizeChangePerSecond = sizeChange / panAndZoomDuration;
		float newSize = Mathf.MoveTowards(Camera.main.orthographicSize, newTargetSize, sizeChangePerSecond * Time.deltaTime);
		Camera.main.orthographicSize = newSize;
	}

	bool MouseIsWithinWindow() { return Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width && Input.mousePosition.y >= 0 && Input.mousePosition.y <= Screen.height; }

	public void SetDefault()
	{
		// Set follow mouse ratio to default
		followMouseRatio = defaultFollowMouseRatio;

		// Record previous target position and set new target position
		// Check if zooming out from unit selected, if so then keep previous target position as unit selected position + offset
		if (!isZoomingOutFromUnitSelected) { prevTargetPosition = newTargetPosition; }
		newTargetPosition = Vector2.zero;

		// Record previous target size and set new target size
		// Check if zooming out from unit selected, if so then keep previous target size as unit selected size
		if (!isZoomingOutFromUnitSelected) { prevTargetSize = newTargetSize; }
		newTargetSize = defaultSize;
	}
	public void SetUnitHovered(Unit unit)
	{
		// Set follow mouse ratio to unit hovered
		followMouseRatio = unitHoveredFollowMouseRatio;

		// Record previous target position and set new target position
		// Check if zooming out from unit selected, if so then keep previous target position as unit selected position + offset
		if (!isZoomingOutFromUnitSelected) { prevTargetPosition = newTargetPosition; }

		// the camera offset from center depends on whether the unit is a wizard (on the left side of the screen) or an enemy (on the right side of the screen)
		if (unit.tag == "Wizard")
		{
			newTargetPosition = unitHoveredCameraOffsetFromCenter;
		}
		else if (unit.tag == "Enemy")
		{
			// Flip the x offset
			newTargetPosition = new Vector2(unitHoveredCameraOffsetFromCenter.x * -1, unitHoveredCameraOffsetFromCenter.y);
		}

		// Record previous target size and set new target size
		// Check if zooming out from unit selected, if so then keep previous target size as unit selected size
		if (!isZoomingOutFromUnitSelected) { prevTargetSize = newTargetSize; }
		newTargetSize = unitHoveredSize;
	}
	public void SetUnitSelected(Unit unit)
	{
		// Set follow mouse ratio to unit selected
		followMouseRatio = unitSelectedFollowMouseRatio;

		// Record previous target position and set new target position
		prevTargetPosition = newTargetPosition;

		Vector2 unitPosition = unit.transform.position;
		newTargetPosition = unitPosition + unitSelectedCameraOffsetFromUnit;

		// Record previous target size and set new target size
		prevTargetSize = newTargetSize;
		newTargetSize = unitSelectedSize;
	}
}