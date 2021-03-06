using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OSCCommunicator : MonoBehaviour {

	private Osc oscHandler;
	
	public string remoteIp = "127.0.0.1";
	public int senderPort = 57000;
	public int listenerPort = 57001; 
	public bool verbose = false; //whether to print out received OSC messages to the console
	
	public delegate void MidiEventReceiver(string status, int byte1, int byte2);
	public delegate void OSCMessageReceiver(OscMessage oscMessage);
	
	private Dictionary<string, ArrayList> registeredOSCReceivers;
	
	public MidiEventReceiver midiEventReceiver;
	//this is needed because the callback cannot change the scene itself. Only Update() can.
	private int sceneChange = -1;
	//if the OSC callback gets a message, it goes into here. Update() treats it as a FIFO. This
	//is done because the callback isn't threadsafe, so can't modify anything.
	private ArrayList oscMessagesToSend; 
		
	~OSCCommunicator() {
		print("Destructor called");
		if (oscHandler != null) {
			oscHandler.Cancel();
		}
		
		oscHandler = null;
		System.GC.Collect();
	} 

	void Awake() {
		registeredOSCReceivers = new Dictionary<string, ArrayList>();
		oscMessagesToSend = new ArrayList();
	}
	
	void Start () {
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(remoteIp, senderPort, listenerPort);
		
		oscHandler = GetComponent<Osc>();
		oscHandler.init(udp);
		oscHandler.SetAddressHandler("/acw", OSCCallback);
	}
	
	// Update is called once per frame
	void Update () {
		//sceneChange needs to be handled through the delegate messaging system
		/*
		if (sceneChange != -1) {
			Application.LoadLevel(sceneChange);
			sceneChange = -1;
		}
		*/
		messageInterestedParties();
	}
	
	void onDisable() {
		oscHandler.Cancel();
		oscHandler = null;
	}
	
	public void SendNoteOn(int noteNum) {
		OscMessage oscM = Osc.StringToOscMessage("/noteon " +  noteNum + " 120");
		oscHandler.Send(oscM);
	}
	
	public void SendNoteOff(int noteNum) {
		OscMessage oscM = Osc.StringToOscMessage("/noteoff " + noteNum);
		oscHandler.Send(oscM);
	}
	
	public void OSCCallback(OscMessage m) {
		if (verbose) {
			string command = (string) m.Values[0];
			string osc_report_string = "";
			//print("OSC command is " + command);
			for (int i = 0; i < m.Values.Count; i++) {
				osc_report_string = osc_report_string + "Values[" + i + "]: " + m.Values[i] + "***";
			}
			//print("osc_report_string: " + osc_report_string + "\n");
		}
		
		oscMessagesToSend.Add(m);
		
		//obsolete code, but we do need to figure out how to better handle MIDI notes,
		//or if we should even handle them at all (and instead only use CC)
		/*
		if(command == "midievent") {
			midiEventReceiver((string)m.Values[1], (int)m.Values[2], (int)m.Values[3]);
		}
		else if (command == "scenechange") {
			if (verbose) {
				Debug.Log("SCENE CHANGE!!!!!!!!!");
			}
			sceneChange = (int) m.Values[1];
		}
		else if (command == "cc") {
			
			//string messageName = "onCC";
			
		}
		*/
	}
	
	//Sends out all messages in the 'oscMessagesToSend' queue and then clears the queue
	//Called once per Update(). Done this way because the OSC callback can't manipulate Unity objects
	private void messageInterestedParties() {
		foreach (OscMessage m in oscMessagesToSend.ToArray()) {
			string command = commandForOSCMessage(m);
			object[] interestedParties;
			if (registeredOSCReceivers.ContainsKey(command)) {
				//print("FOUND INTERESTED PARTIES!!!! :) :)");
				interestedParties = registeredOSCReceivers[command].ToArray();
				foreach (OSCMessageReceiver r in interestedParties) {
					r(m);
				}
			}
		}
		oscMessagesToSend.Clear();
	}
	
	public void registerOSCReceiver(OSCMessageReceiver omr, string command) {
		
		if (verbose) {
			Debug.Log("Registered command " + command);
		}
		
		bool containsKey = registeredOSCReceivers.ContainsKey(command);
		if (!containsKey) {
			registeredOSCReceivers[command] = new ArrayList();
			registeredOSCReceivers[command].Add(omr);
		} else {
			if (!registeredOSCReceivers[command].Contains(omr)) {
				registeredOSCReceivers[command].Add(omr);
			}
		}
	}

	public void unregisterOSCReceiver(OSCMessageReceiver omr) {
		//TODO
		print("UNREGISTER ME DAMMIT!!!");
	}
	
	private string commandForOSCMessage(OscMessage message) {
		string command = (string)message.Values[0];
		if (command == "cc") {
			command = command + message.Values[1];
		}
		return command;
	}
}