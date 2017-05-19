    .global main
main:
    sbi     0x04, 5     ; set led pin as output
loop:                   
    sbi     0x05, 5     ; turn led on
    call    delay       ; wait 1 second
    cbi     0x05, 5     ; turn led off
    call    delay       ; wait 1 second
    rjmp    loop        ; loop again
delay:                  
    ldi     r18, 0x00   ; initialise counter to 3.2M
    ldi     r19, 0xD4   
    ldi     r20, 0x30   
    subi    r18, 0x01   ; decrement counter by 1
    sbci    r19, 0x00   
    sbci    r20, 0x00   
    brne    .-8         ; repeat decrement until counter == 0
    ret 
