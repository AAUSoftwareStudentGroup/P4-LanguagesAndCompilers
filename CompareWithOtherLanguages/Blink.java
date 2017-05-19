package arduino.tutorial;

import static haiku.avr.lib.arduino.WProgram.*;
import static haiku.avr.AVRConstants.*;

public class Blink {

	public static void delayr() {
		for(int i = 0; i < 32000; i++) {
			for(int j = 0; j < 1000; j++) {}
		}
	}

	public static void loop()           // run over and over again
	{
		PORTB |= 1<<5;               // Turn LED on
		delayr();                    // waits for a second
		PORTB &= ~(1<<5);          // Turn LED of
		delayr();                    // waits for a second
	}

	public static void main(String[] args) {
		DDRB |= 1<<5;
		while(true)
			loop();
	}
}
