#pragma strict

var pickGameState : boolean;
var repeatGameState : boolean;
var fail : boolean;
var win : boolean;
var colors = new Array("green", "red", "yellow", "blue");
var picks = new Array();
var repeats = new Array();

// add references to relevant GameObjects if necessary

function Start() {
	pickGameState = true;
	repeatGameState = false;
	fail = false;
	win = false;
}

function Update() {
	if (win) {
		// say win
		// pause
		// reset
		//reset();
	}
	else if (pickGameState) {
	
		if (picks.length < 5) {
			getNextPick(); showPickState();
		}
		
		else {
			pickGameState = false;
		}
	}
	else if (!repeatGameState) {
		showPickOrder();
	}
	else if (!fail) {
		repeat();
	}
	else {
		// fail?
		// say fail
		reset();
	}
}

function getNextPick() {
	if (Input.GetKeyUp("1")) {
		pickGreen();
	}
	
	else if (Input.GetKeyUp("2")) {
		pickRed();
	}
	
	else if (Input.GetKeyUp("3")) {
		pickYellow();
	}
	
	else if (Input.GetKeyUp("4")) {
		pickBlue();
	}
}

function getNextRepeat() {
	if (Input.GetKeyUp("1")) {
		repeatGreen();
	}
	
	else if (Input.GetKeyUp("2")) {
		repeatRed();
	}
	
	else if (Input.GetKeyUp("3")) {
		repeatYellow();
	}
	
	else if (Input.GetKeyUp("4")) {
		repeatBlue();
	}
}

function showPickOrder() {
	var t = 0;
	while (t<300) {
		t++;
	} // PAUSE

	for (var i=0; i<picks.length; i++) {
		displayColor(picks[i]);
		t = 0;
		while (t<200) {t++;} // MODIFY FOR DIFFERENT TIME
	}
	repeatGameState = true;
}

function displayColor(color) { // color is a string
	// HOWEVER WE PLAN TO DISPLAY TO THE STUDENT
}

function repeat() {
	var t = 0; // variables are not statically typed. Think Python
	while (t<300) {t++;} // PAUSE
	t = 0;
	// say start
	while (t<500) { // LIMITED TIME TO ANSWER
		t++;
		// showRepeatState();
		if (fail) {
			// say lose
			break;
		}
		else if (repeats.length < 5) {getNextRepeat();}
		
		checkFail();
	}
	checkFail(); // one last time just because
	if (!win) {fail = true;}
}

function checkFail() {
	for (var i=0; i<repeats.length; i++) {
		if (repeats[i] != picks[i]) {fail = true;}
	}
	if (picks.length == repeats.length && !fail) {win = true;}
}

function showPickState() {
	// FUNCTION FOR WHATEVER GRAPHICAL ELEMENTS IN PICK STATE
}

function showRepeatState() {
	// FUNCTION FOR WHATEVER GRAPHICAL ELEMENTS IN REPEAT STATE
}

// PICKING FUNCTIONS
public function pickGreen() {picks.push("green");}
public function pickRed() {picks.push("red");}
public function pickYellow() {picks.push("yellow");}
public function pickBlue() {picks.push("blue");}

public function repeatGreen() {repeats.push("green");}
public function repeatRed() {repeats.push("red");}
public function repeatYellow() {repeats.push("yellow");}
public function repeatBlue() {repeats.push("blue");}

function reset() {
	var t = 0;
	while (t<300) {t++;} // PAUSE
	
	pickGameState = true;
	repeatGameState = false;
	fail = false;
	win = false;
	picks = new Array();
	repeats = new Array();
}
