using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public enum EVENT{MyEvent1, MyEvent2};
public static class EventManager {
	private static Dictionary<EVENT,Action> eventTable = new Dictionary<EVENT,Action>();



	public static void AddHandler(EVENT evnt,Action action)
	{
		if(!eventTable.ContainsKey(evnt)) eventTable[evnt] = action;
		else eventTable[evnt] += action;
	}

	public static void Broadcast(EVENT evnt)
	{
		if (eventTable[evnt] != null) eventTable[evnt]();
	}

	public static void RemoveHandler(EVENT evnt,Action action)
	{
		if(eventTable[evnt] != null)
			eventTable[evnt] -= action;
		if(eventTable[evnt] == null)
			eventTable.Remove(evnt);
	}



}
