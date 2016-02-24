using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using WPM;
namespace Hackerspaces {
	public class Simulator : MonoBehaviour {
		
		public static Simulator Instance;
		
		[System.Serializable]
		public class Hackerspace {
			/// <summary>
			/// The WorldMapGlobe cityIndex number of the city where the hackerspace is
			/// </summary>
		
			public int cityIndex = 0;
			public string name = "Hackspace";
			public int members = 1;
			public List<Relationship> people;
			public float growthPerMonth = 1f;
			
			public Hackerspace ()
			{
				
			}
			public Hackerspace (string n, int m, float g, int i)
			{
				cityIndex = i;
				name = n;
				members = m;
				growthPerMonth = g;
			}
		}
		
		public List<Hackerspace> hackerspaces;
		
		public GameObject cofoundInterface;
		public Text cofoundNameText;
		
		public void ShowCofoundHackerspace()
		{
			cofoundInterface.SetActive(true);
		}
		
		public void HideCofoundHackerspace()
		{
			cofoundInterface.SetActive(false);
		}
		public void CofoundHackerspace()
		{
			Hackerspace newHackerspace = new Hackerspace();
			newHackerspace.name = cofoundNameText.text;
			newHackerspace.members = 1;
			newHackerspace.cityIndex = HackerspacesManager.Instance.mapCitySelectedIndex;
			hackerspaces.Add(newHackerspace);
			//newHackerspace.cityIndex = Hackerspaces.instance.sel
			HideCofoundHackerspace();
			HackerspacesManager.Instance.ShowHackerspaces();
		}
		
		/// <summary>
		/// Gets a list of hackerspaces in a given city index.
		/// </summary>
		/// <param name="inCityIndex"></param>
		/// <returns></returns>
		public List<Hackerspace> HackerspacesInCityIndex(int inCityIndex)
		{
			List<Hackerspace> hackerspacesInCity = new List<Hackerspace>();
			foreach (Hackerspace space in hackerspaces)
			{
				if (space.cityIndex == inCityIndex)
				{
					hackerspacesInCity.Add(space);
				}
			}
			return hackerspacesInCity;
		}
		
		public class Relationship {
			public int personUID;
			public int otherPersonUID;
		}
		
		public class Person {
			public int personUID;
			
		}
		
		public List<Person> people;
		
		public class Resource {
			
		}
		
		public void Run () {
			foreach (Hackerspace space in hackerspaces)
			{
				//space.members+=space.growthPerMonth;
			}
		}
		
		void Awake () {
			if (Instance==null)
			{
				Instance=this;
			}
			InitHackerspaces();
			
		}
		
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		
		void InitHackerspaces () 
		{
			List<Hackerspace> hackerspacesToAdd = new List<Hackerspace>();
			hackerspacesToAdd.Add( new Hackerspace("/dev/tal", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
			hackerspacesToAdd.Add( new Hackerspace("091 Labs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("57North Hacklab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("[hsmr]", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Ace Monster Toys", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("ACKspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("AFRA", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Apollo-NG", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Arch Reactor", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Attraktor Makerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Awesome Space", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("backspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("base48", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Bastli", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Bhack", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("BinarySpace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Bitlair", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Breizh-Entropy", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Brixel", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("brmlab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Bytespeicher", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("bytewerk", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("c-base", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("C3D2 GCHQ", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("CADR", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("CCC Hamburg", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("CCCFr", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("cccmzwi", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Chaos Computer Club Hamburg e.V.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Chaos Darmstadt", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Chaos inKL.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Chaosdorf", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("ChaosStuff", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Chaostreff Chemnitz", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Chaostreff Dortmund", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Codersfield", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("CommonGround", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("coredump", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("CSSA Common Room", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("DevLoL", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Dingfabrik", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Dlabs Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Don't Panic", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("E5", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Edinburgh Hacklab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Eigenbaukombinat Halle e.V.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Embassy of Nerdistan", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Entropia", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Estação H4ck3r", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("FabLab Nürnberg", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("FamiLAB", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Farset Labs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("FAU FabLab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("FIXME", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Foomatic", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Frack", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Freies Labor", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Freiraum", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("GarageLab e.V.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Garaj", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Garoa Hacker Clube", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("GeekLabs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Gothemburg Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("H.A.C.K.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HacDC", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hack42", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackburg", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HackerGarage", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackeriet", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace Bielefeld e.V.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace Bremen e.V.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace KRK", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace Monterrey", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace Pardubice", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace Valencia", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace.gr", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace.sg", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hacklab Kika", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("hacklab01", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HackLabAsu", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("hacklabbo", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hacksaar", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hacksburg", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackspace Manchester", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackspace Siegen", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackspace-Jena", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("hackzogtum", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HAUM", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HeatSync Labs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hickerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hive13", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HSBNE", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HSBXL", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Hackerspace Brussel", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HSMTY", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("HTU Graz - Basisgruppe Informatik", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Istanbul Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("IT-Syndikat", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Jeanne D'Hack", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("K4CG", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Kamloops MakerSpace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Krautspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Kwartzlab Makerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("LabHacker SP", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Laboratoire Ouvert Grenoblois", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Laboratorio Hacker de Campinas", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Laboratório Hacker", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("LAG", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Lamba Labs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Le Loop", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("LearnObots HackerSpace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Leeds Hackspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("LeineLab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Level2", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("London Hackspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Mainframe", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Make, Hack, Void Canberra", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("MakeHackVoid Canberra", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Makers Local 256", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("MakerSpace Nanaimo", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Maschinendeck", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Maschinenraum", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Matehackers", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("MechArtLab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Melbourne Makerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("MetaMeute", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("MidsouthMakers", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Mikkeli Hacklab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("miLKlabs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Milwaukee Makerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Minsk Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("MuCCC", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Munich Maker Lab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("nbsp", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Netz39", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Netzladen", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Nicelab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Noisebridge", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Noklab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Nottinghack", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Nova Labs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("NURDSpace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Open Space Aarhus", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("OpenLab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Pyŏngyang Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("P-Space", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Pangloss Labs #1", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Perth Artifactory", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Pixelbar", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Politecnico Open unix Lab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Post Tenebras Lab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("PotentialLabs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("PotteriesHackspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Progressbar", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("ProjectKitchen", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Pumping Station One", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Quelab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Randomdata", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Raul Hacker Club", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("RaumZeitLabor", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Reaktor 23", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("realraum", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Recompile", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("RevSpace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("ruum42", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Sabugosa", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("shackspace stuttgart", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Sk1llz", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("SMART Lab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("spaceleft", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Stgo MakerSpace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Stratum 0", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("sublab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Sudo Room", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Swansea Hackspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("SYNHAK", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Taipei Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Tampere Hacklab 5w", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Tangleball", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Tarlab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Tarrafa Hacker Clube", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Technologia Incognita", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("TechTonik Labs", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Terminal.21 Basislager", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Tetalab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("The Bodgery", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Tink3rLab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("TkkrLab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("TOG", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Triangulo Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("turmlabor", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Umeå Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Unallocated Space", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("UrLab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Vaasa Hacklab", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Verr's Space", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("VoidWarranties", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Warpzone e.V.", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Warsaw Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Wolfplex Hackerspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("Xerocraft", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
hackerspacesToAdd.Add( new Hackerspace("York Hackspace", Random.Range(10,200), Random.Range(1,4), Random.Range(0,7000)));
			
			hackerspaces = hackerspacesToAdd;
		}
		
	}
}