avrdude -patmega328p -carduino -P/dev/ttyUSB0 -b57600 -D -Uflash:w:$1.hex:i

