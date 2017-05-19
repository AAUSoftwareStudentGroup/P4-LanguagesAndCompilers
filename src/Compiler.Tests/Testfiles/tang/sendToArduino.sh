avr-gcc -mmcu=atmega328p test2.c -std=c99 -o a.out -w
avr-objcopy -Oihex -R.eeprom a.out test2.hex
avrdude -patmega328p -carduino -P/dev/ttyUSB0 -b57600 -D -Uflash:w:test2.hex:i