compile tang to c from Compiler folder:
dotnet run ../../docs/samples/BasicBlink.tang

compile c to asm
avr-gcc ../../docs/samples/BasicBlink.tang.c -mmcu=atmega328p -o BasicBlink.out

create hex file
avr-objcopy BasicBlink.out -R .eeprom -O ihex BasicBlink.hex

upload to Arduino
avrdude -C "C:\Program Files (x86)\Arduino\hardware\tools\avr/etc/avrdude.conf" -v -p atmega328p -c arduino -P COM3 -b 57600 -D -U flash:w:BasicBlink.hex:i 