package arduino.tutorial;

import static haiku.avr.lib.arduino.WProgram.*;
import static haiku.avr.AVRConstants.*;

public class blink {

	public static void _wait() {
		for(long i = 0; i < 3200000; i++) {}
	}

	public static void main(String[] args) {
		DDRB |= 1<<5;
		while(true) {
			PORTB |= 1<<5;             // Turn LED on
			_wait();                    // waits for a second
			PORTB &= ~(1<<5);          // Turn LED of
			_wait();                    // waits for a second
		}
	}
}
