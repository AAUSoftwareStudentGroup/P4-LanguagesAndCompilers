avr-gcc -mmcu=atmega328p $1 -std=c99 -o $1.out -w
avr-objcopy -Oihex -R.eeprom $1.out $1.hex
avrdude -patmega328p -carduino -P/dev/ttyUSB0 -b57600 -D -Uflash:w:$1.hex:i