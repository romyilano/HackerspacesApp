/*
 * Copyright 2015 Kronnect Games 
 * Check our awesome assets: World Political Map 2D & 3D and others at kronnect.com or Unity Asset Store
 * Follow us at @KronnectGames 
 */


using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Benchmark : MonoBehaviour {

	#region Public API & GUI

	public bool showCountersOnGUI = true;
	public Rect screenRect = new Rect(0,0, Screen.width, Screen.height);

	const string DEFAULT_COUNTER = "1";

	void OnGUI() {
		if (!showCountersOnGUI) return;
		string countersText = GetCountersText();
		if (countersText.Length>0) {
			GUI.Label(screenRect, countersText);
		}
	}

	public static void Reset() {
		Reset (DEFAULT_COUNTER);
	}

	public static void Reset(string counterName) {
		Counter c = ThisCounter(counterName);
		if (c!=null) _counters[counterName].Reset();
	}

	public static void TimeStampAndPrint() {
		TimeStampAndPrint(DEFAULT_COUNTER);
	}

	public static void TimeStampAndPrint(string counterName) {
		TimeStamp (counterName);
		PrintToDebugConsole();
	}

	public static void TimeStamp () {
		TimeStamp(DEFAULT_COUNTER);
	}

	public static void TimeStamp (string counterName) {
		if (counters.ContainsKey (counterName)) {
			if (!_counters[counterName].recording) {
				_counters[counterName].LapStart();
			} else {
				_counters[counterName].LapStop();
			}
		} else {
			_counters.Add (counterName, new Counter());
		}
	}

	public static void Stop () {
		Stop (DEFAULT_COUNTER);
	}

	public static void Stop (string counterName) {
		Counter c = ThisCounter(counterName);
		if (c!=null) _counters[counterName].LapStop();
	}

	public static float ElapsedTimeTotal() {
		return ElapsedTimeTotal(DEFAULT_COUNTER);
	}

	public static float ElapsedTimeTotal(string counterName) {
		Counter c = ThisCounter(counterName);
		if (c!=null) return _counters[counterName].elapsedTimeTotal; else return 0;
	}
	
	public static float ElapsedTimeLastLap() {
		return ElapsedTimeLastLap(DEFAULT_COUNTER);
	}

	public static float ElapsedTimeLastLap(string counterName) {
		Counter c = ThisCounter(counterName);
		if (c!=null) return _counters[counterName].elapsedTimeLastLap; else return 0;
	}

	public static float AverageLapTime() {
		return AverageLapTime(DEFAULT_COUNTER);
	}


	public static float AverageLapTime(string counterName) {
		Counter c = ThisCounter(counterName);
		if (c!=null) return _counters[counterName].averageLapTime; else return 0;
	}

	public static void PrintToDebugConsole () {
		string countersText = GetCountersText();
		if (countersText.Length>0) Debug.Log (countersText);
	}

	public static string GetCountersText() {
		if (_counters==null) return "";
		List<string> counterNames = new List<string>(_counters.Keys);
		StringBuilder sb = new StringBuilder();
		for (int k=0;k<counterNames.Count;k++) {
			sb.Append(counterNames[k]);
			Counter counter = _counters[counterNames[k]];
			sb.Append("-> Total time: ");
			sb.Append(counter.elapsedTimeTotal.ToString("F2"));
			sb.Append(" ms");
			sb.Append(", Last time: ");
			sb.Append(counter.elapsedTimeLastLap.ToString("F2"));
			sb.Append(" ms");

			if (counter.laps>0) {
				sb.Append("; Average: ");
				sb.Append(counter.averageLapTime.ToString("F2"));
				sb.Append(" ms");
			}
			sb.AppendLine();
		}

		return sb.ToString();
	}

	#endregion



	#region Internal stuff

	// internal fields & methods
	static Dictionary<string,Counter> _counters;
	
	// Lazy instantiation
	static Dictionary<string,Counter> counters { get {
			if (_counters == null) {
				_counters = new Dictionary<string,Counter> ();
			}
			return _counters;
		} 
	}
	
	static Counter ThisCounter(string counterName) {
		if (counters.ContainsKey(counterName))
			return _counters[counterName];
		Debug.Log ("Counter " + counterName + " doesn't exist. You should call Benchmark.TimeStamp(" + counterName + ") at least once in your code.");
		return null;
	}

	class Counter {
		DateTime startLap;	// start recording time
		DateTime stopLap;	// recorded when Benchmark.Stop() is called
		int _laps;			// number of calls to Benchmark.Lap() + 1
		float accumTime;	// accumulated time between start-stop
		bool _recording;		// whether the counter is counting or not

		public Counter() {
			startLap = stopLap = DateTime.Now;
			_recording = true;
			_laps = 1;
		}

		public int laps { get { return _laps; } }

		public bool recording { get { return _recording; } }

		public float elapsedTimeTotal {
			get {
				if (recording) {
					return accumTime + (float) (DateTime.Now-startLap).TotalMilliseconds;
				} else
					return accumTime;
			}
		}
		
		public float elapsedTimeLastLap {
			get {
				if (recording) 
					return (float)(DateTime.Now-startLap).TotalMilliseconds;
				else
					return (float)(stopLap-startLap).TotalMilliseconds;
			}
		}
		
		public float averageLapTime {
			get {
				return elapsedTimeTotal / laps;
			}
		}
		
		
		public void LapStart() {
			if (!recording) {
				_recording = true;
				startLap = DateTime.Now;
				_laps++;
			}
		}
		
		public void LapStop() {
			if (recording) {
				_recording = false;
				stopLap = DateTime.Now;
				accumTime += elapsedTimeLastLap;
			}
		}

		public void Reset() {
			startLap = stopLap = DateTime.Now;
			_recording = false;
			_laps = 1;
		}
	}

	#endregion


}
