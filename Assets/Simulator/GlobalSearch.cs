using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WPM;
using UnityEngine.UI;

namespace Hackerspaces {
	/// <summary>
	/// GlobalSearch can search for many kinds of entities with auto-completion and fly to the chosen result.
	/// </summary>
	public class GlobalSearch : MonoBehaviour {
		#region variables
		public WorldMapGlobe map;
		
		public Text searchInputText;
		public Text searchResultText;
		
		City cityResult = null;
		List<City> cityResults = new List<City>();
		#endregion
		
		#region methods
		public void Search ()
		{
			string searchString = searchInputText.text;
			cityResults.Clear();
			foreach (WPM.City city in map.cities)
			{
				if (city.name.Contains(searchString))
				{
					cityResult = city;
					cityResults.Add(city);
				}
			}
			if (cityResult == null)
			{
				searchResultText.text = "Not found.";
			}
			else
			{
				searchResultText.text = cityResult.name;
				if (cityResults.Count>1)
				{
					searchResultText.text = "";
					foreach (City city in cityResults)
					{
						searchResultText.text += "\n" + city.name;
					}
				}
			}
		}
		
		#endregion
		
		#region MonoBehaviour
		
		// Use this for initialization
		void Awake () {
			map = WorldMapGlobe.instance;
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		#endregion
	}
}