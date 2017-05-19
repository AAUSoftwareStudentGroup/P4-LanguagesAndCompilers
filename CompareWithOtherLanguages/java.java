package arduino.tutorial;

import static haiku.avr.lib.arduino.WProgram.*;
import static haiku.avr.AVRConstants.*;

public class Blink {

	public static void wait() {
		for(long long i = 0; i < 3200000; i++) {}
	}

	public static void main(String[] args) {
		DDRB |= 1<<5;
		while(true) {
			PORTB |= 1<<5;             // Turn LED on
			wait();                    // waits for a second
			PORTB &= ~(1<<5);          // Turn LED of
			wait();                    // waits for a second
		}
	}
}
