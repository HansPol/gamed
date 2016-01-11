﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowScript : MonoBehaviour 
{
	public enum FollowType
	{
		MoveTowards,
		Lerp
	}

	public FollowType Type = FollowType.MoveTowards;
	public PathDefinition Path;
	public float Speed = 1;
	public float MaxDistanceToGoal = 0.1f;

	private IEnumerator<Transform> _currentPoint;
	
	public void Start()
	{
		if (Path == null)
		{
			Debug.LogError ("Path cannot Be null", gameObject);
			return;
		}

		_currentPoint = Path.GetPathEnumerator();
		_currentPoint.MoveNext();

		if (_currentPoint.Current == null)
			return;

		transform.position = _currentPoint.Current.position;
	}

	public void Update()
	{
		if (_currentPoint == null || _currentPoint.Current == null)
			return;

		if (Type == FollowType.MoveTowards)
			transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
		else if (Type == FollowType.Lerp)
			transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
			_currentPoint.MoveNext();
	}
}
