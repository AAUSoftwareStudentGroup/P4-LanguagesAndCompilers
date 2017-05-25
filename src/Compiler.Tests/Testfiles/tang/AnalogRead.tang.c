volatile unsigned char * PINB ;
volatile unsigned char * DDRB ;
volatile unsigned char * PORTB ;
volatile unsigned char * PINC ;
volatile unsigned char * DDRC ;
volatile unsigned char * PORTC ;
volatile unsigned char * PIND ;
volatile unsigned char * DDRD ;
volatile unsigned char * PORTD ;
volatile unsigned char * TIFR0 ;
volatile unsigned char * TIFR1 ;
volatile unsigned char * TIFR2 ;
volatile unsigned char * PCIFR ;
volatile unsigned char * EIFR ;
volatile unsigned char * EIMSK ;
volatile unsigned char * GPIOR0 ;
volatile unsigned char * EECR ;
volatile unsigned char * EEDR ;
volatile unsigned char * EEARL ;
volatile unsigned char * EEARH ;
volatile unsigned char * GTCCR ;
volatile unsigned char * TCCR0A ;
volatile unsigned char * TCCR0B ;
volatile unsigned char * TCNT0 ;
volatile unsigned char * OCR0A ;
volatile unsigned char * OCR0B ;
volatile unsigned char * GPIOR1 ;
volatile unsigned char * GPIOR2 ;
volatile unsigned char * SPCR0 ;
volatile unsigned char * SPSR0 ;
volatile unsigned char * SPDR0 ;
volatile unsigned char * ACSR ;
volatile unsigned char * DWDR ;
volatile unsigned char * SMCR ;
volatile unsigned char * MCUSR ;
volatile unsigned char * MCUCR ;
volatile unsigned char * SPMCSR ;
volatile unsigned char * SPL ;
volatile unsigned char * SPH ;
volatile unsigned char * SREG ;
volatile unsigned char * WDTCSR ;
volatile unsigned char * CLKPR ;
volatile unsigned char * PRR ;
volatile unsigned char * OSCCAL ;
volatile unsigned char * PCICR ;
volatile unsigned char * EICRA ;
volatile unsigned char * PCMSK0 ;
volatile unsigned char * PCMSK1 ;
volatile unsigned char * PCMSK2 ;
volatile unsigned char * TIMSK0 ;
volatile unsigned char * TIMSK1 ;
volatile unsigned char * TIMSK2 ;
volatile unsigned char * ADCL ;
volatile unsigned char * ADCH ;
signed int ADC ( ) ;
volatile unsigned char * ADCSRA ;
volatile unsigned char * ADCSRB ;
volatile unsigned char * ADMUX ;
volatile unsigned char * DIDR0 ;
volatile unsigned char * DIDR1 ;
volatile unsigned char * TCCR1A ;
volatile unsigned char * TCCR1B ;
volatile unsigned char * TCCR1C ;
volatile unsigned char * TCNT1L ;
volatile unsigned char * TCNT1H ;
volatile unsigned char * ICR1L ;
volatile unsigned char * ICR1H ;
volatile unsigned char * OCR1AL ;
volatile unsigned char * OCR1AH ;
volatile unsigned char * OCR1BL ;
volatile unsigned char * OCR1BH ;
volatile unsigned char * TCCR2A ;
volatile unsigned char * TCCR2B ;
volatile unsigned char * TCNT2 ;
volatile unsigned char * OCR2A ;
volatile unsigned char * OCR2B ;
volatile unsigned char * ASSR ;
volatile unsigned char * TWBR ;
volatile unsigned char * TWSR ;
volatile unsigned char * TWAR ;
volatile unsigned char * TWDR ;
volatile unsigned char * TWCR ;
volatile unsigned char * TWAMR ;
volatile unsigned char * UCSR0A ;
volatile unsigned char * UCSR0B ;
volatile unsigned char * UCSR0C ;
volatile unsigned char * UBRR0L ;
volatile unsigned char * UBRR0H ;
volatile unsigned char * UDR0 ;
unsigned char INTERRUPT_LOW ;
unsigned char ANY_EDGE ;
unsigned char RISING_EDGE ;
unsigned char FALLING_EDGE ;
unsigned char INDEX_INT0 ;
unsigned char INDEX_INT1 ;
unsigned char INDEX_TIMER2_OCA ;
unsigned char INDEX_TIMER2_OCB ;
unsigned char INDEX_TIMER2_OF ;
unsigned char INDEX_TIMER1_IC ;
unsigned char INDEX_TIMER1_OCA ;
unsigned char INDEX_TIMER1_OCB ;
unsigned char INDEX_TIMER1_OF ;
unsigned char INDEX_TIMER0_OCA ;
unsigned char INDEX_TIMER0_OCB ;
unsigned char INDEX_TIMER0_OF ;
unsigned char INDEX_USART_RXC ;
unsigned char INDEX_USART_DRE ;
unsigned char INDEX_USART_TXC ;
unsigned char INT0_vect ;
unsigned char INT1_vect ;
unsigned char PCINT0_vect ;
unsigned char PCINT1_vect ;
unsigned char PCINT2_vect ;
unsigned char WDT_vect ;
unsigned char TIMER2_COMPA_vect ;
unsigned char TIMER2_COMPB_vect ;
unsigned char TIMER2_OVF_vect ;
unsigned char TIMER1_CAPT_vect ;
unsigned char TIMER1_COMPA_vect ;
unsigned char TIMER1_COMPB_vect ;
unsigned char TIMER1_OVF_vect ;
unsigned char TIMER0_COMPA_vect ;
unsigned char TIMER0_COMPB_vect ;
unsigned char TIMER0_OVF_vect ;
unsigned char SPI_STC_vect ;
unsigned char USART_RX_vect ;
unsigned char USART_UDRE_vect ;
unsigned char USART_TX_vect ;
unsigned char ADC_vect ;
unsigned char EE_READY_vect ;
unsigned char ANALOG_COMP_vect ;
unsigned char TWI_vect ;
unsigned char SPM_READY_vect ;
unsigned char INT0 ;
unsigned char INT1 ;
unsigned char INPUT ;
unsigned char OUTPUT ;
unsigned char PULLUP ;
unsigned char NO_PULLUP ;
unsigned char HIGH ;
unsigned char LOW ;
void INT0_enable ( ) ;
void INT0_init ( unsigned char edge ) ;
void delay ( unsigned long ms ) ;
unsigned char DigitalRead ( signed char pin ) ;
void SetAnalogMode ( unsigned char mode ) ;
void PinModeA ( signed char pin , unsigned char mode ) ;
unsigned int AnalogRead ( signed char pin ) ;
signed char PinModeD ( signed char pin , unsigned char mode ) ;
signed char DigitalWrite ( unsigned char pin , unsigned char value ) ;
signed char DigitalFlip ( unsigned char pin ) ;
void SetFastPWMPin6 ( signed int dutyCycle ) ;
signed int counter ;
signed int limiter ;
unsigned char value ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1, i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed int ADC ( )
{
    signed int result ;
    result = 0 ;
    signed char _i [ ] = { 0 , 7 , 1 } ; _i [ 2 ] = ( _i [ 0 ] < _i [ 1 ] ? 1 : -1 ) ; signed char i = _i [ 0 ] ; do { if ( ( * ADCL & ( 1 << ( i ) ) ) ) {     result = ( result + Pow ( 2 , ( i ) ) ) ; } _i [ 0 ] += _i [ 2 ] ; i = _i [ 0 ] ; } while ( i != _i [ 1 ] + _i [ 2 ] ) ;
    signed char _i [ ] = { 0 , 1 , 1 } ; _i [ 2 ] = ( _i [ 0 ] < _i [ 1 ] ? 1 : -1 ) ; signed char i = _i [ 0 ] ; do { if ( ( * ADCH & ( 1 << ( i ) ) ) ) {     result = ( result + Pow ( 2 , ( ( 8 + i ) ) ) ) ; } _i [ 0 ] += _i [ 2 ] ; i = _i [ 0 ] ; } while ( i != _i [ 1 ] + _i [ 2 ] ) ;
    return result ;
}
void INT0_enable ( )
{
    * EIMSK = ( 1 ? ( ( * EIMSK ) | 1 << ( 0 ) ) : ( ( * EIMSK ) & ~ ( 1 << ( 0 ) ) ) ) ;
}
void INT0_init ( unsigned char edge )
{
    INT0_enable ( ) ;
    if ( ( edge == INTERRUPT_LOW ) )
    {
        * EICRA = ( 0 ? ( ( * EICRA ) | 1 << ( 0 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 0 ) ) ) ) ;
        * EICRA = ( 0 ? ( ( * EICRA ) | 1 << ( 1 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 1 ) ) ) ) ;
    }
    else
    if ( ( edge == ANY_EDGE ) )
    {
        * EICRA = ( 1 ? ( ( * EICRA ) | 1 << ( 0 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 0 ) ) ) ) ;
        * EICRA = ( 0 ? ( ( * EICRA ) | 1 << ( 1 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 1 ) ) ) ) ;
    }
    else
    if ( ( edge == RISING_EDGE ) )
    {
        * EICRA = ( 1 ? ( ( * EICRA ) | 1 << ( 0 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 0 ) ) ) ) ;
        * EICRA = ( 1 ? ( ( * EICRA ) | 1 << ( 1 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 1 ) ) ) ) ;
    }
    else
    if ( ( edge == FALLING_EDGE ) )
    {
        * EICRA = ( 0 ? ( ( * EICRA ) | 1 << ( 0 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 0 ) ) ) ) ;
        * EICRA = ( 1 ? ( ( * EICRA ) | 1 << ( 1 ) ) : ( ( * EICRA ) & ~ ( 1 << ( 1 ) ) ) ) ;
    }
    * DDRD = ( 0 ? ( ( * DDRD ) | 1 << ( INT0 ) ) : ( ( * DDRD ) & ~ ( 1 << ( INT0 ) ) ) ) ;
    __asm__ __volatile__ ("sei" ::: "memory") ;
}
void delay ( unsigned long ms )
{
    ms = ( ( ms * 16000 ) / 33 ) ;
    while ( ( ms > 0 ) )
    {
        ms = ( ms - 1 ) ;
    }
}
unsigned char DigitalRead ( signed char pin )
{
    if ( ( pin < 0 ) )
    {
        return 0 ;
    }
    else
    if ( ( pin <= 7 ) )
    {
        return ( * PIND & ( 1 << ( pin ) ) ) ;
    }
    else
    if ( ( pin <= 13 ) )
    {
        return ( * PINB & ( 1 << ( ( pin - 8 ) ) ) ) ;
    }
    else
    if ( ( pin <= 20 ) )
    {
        return ( * PINC & ( 1 << ( ( pin - 14 ) ) ) ) ;
    }
}
void SetAnalogMode ( unsigned char mode )
{
    * ADCSRA = ( mode ? ( ( * ADCSRA ) | 1 << ( 7 ) ) : ( ( * ADCSRA ) & ~ ( 1 << ( 7 ) ) ) ) ;
    if ( mode )
    {
        * ADCSRA = ( 1 ? ( ( * ADCSRA ) | 1 << ( 0 ) ) : ( ( * ADCSRA ) & ~ ( 1 << ( 0 ) ) ) ) ;
        * ADCSRA = ( 1 ? ( ( * ADCSRA ) | 1 << ( 1 ) ) : ( ( * ADCSRA ) & ~ ( 1 << ( 1 ) ) ) ) ;
        * ADCSRA = ( 1 ? ( ( * ADCSRA ) | 1 << ( 2 ) ) : ( ( * ADCSRA ) & ~ ( 1 << ( 2 ) ) ) ) ;
        * ADCSRA = ( 1 ? ( ( * ADCSRA ) | 1 << ( 5 ) ) : ( ( * ADCSRA ) & ~ ( 1 << ( 5 ) ) ) ) ;
    }
}
void PinModeA ( signed char pin , unsigned char mode )
{
    * ADMUX = ( 0 ? ( ( * ADMUX ) | 1 << ( 5 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 5 ) ) ) ) ;
    * ADMUX = ( 1 ? ( ( * ADMUX ) | 1 << ( 6 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 6 ) ) ) ) ;
    * ADMUX = ( 0 ? ( ( * ADMUX ) | 1 << ( 7 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 7 ) ) ) ) ;
    if ( ( ( pin < 8 ) || ( pin >= 0 ) ) )
    {
        * DDRC = ( mode ? ( ( * DDRC ) | 1 << ( pin ) ) : ( ( * DDRC ) & ~ ( 1 << ( pin ) ) ) ) ;
    }
}
unsigned int AnalogRead ( signed char pin )
{
    if ( ( * ADCSRA & ( 1 << ( 7 ) ) ) )
    {
        if ( ( ( pin % 2 ) == 1 ) )
        {
            * ADMUX = ( 1 ? ( ( * ADMUX ) | 1 << ( 0 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 0 ) ) ) ) ;
        }
        else
        {
            * ADMUX = ( 0 ? ( ( * ADMUX ) | 1 << ( 0 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 0 ) ) ) ) ;
        }
        if ( ( ( pin % 4 ) == 1 ) )
        {
            * ADMUX = ( 1 ? ( ( * ADMUX ) | 1 << ( 1 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 1 ) ) ) ) ;
        }
        else
        {
            * ADMUX = ( 0 ? ( ( * ADMUX ) | 1 << ( 1 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 1 ) ) ) ) ;
        }
        if ( ( ( pin % 8 ) == 1 ) )
        {
            * ADMUX = ( 1 ? ( ( * ADMUX ) | 1 << ( 2 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 2 ) ) ) ) ;
        }
        else
        {
            * ADMUX = ( 0 ? ( ( * ADMUX ) | 1 << ( 2 ) ) : ( ( * ADMUX ) & ~ ( 1 << ( 2 ) ) ) ) ;
        }
        * ADCSRA = ( 1 ? ( ( * ADCSRA ) | 1 << ( 6 ) ) : ( ( * ADCSRA ) & ~ ( 1 << ( 6 ) ) ) ) ;
        while ( ( ( * ADCSRA & ( 1 << ( 4 ) ) ) == 0 ) )
        {
        }
        return ADC ( ) ;
    }
    else
    {
        if ( DigitalRead ( ( pin + 14 ) ) )
        {
            return 1 ;
        }
        return 0 ;
    }
}
signed char PinModeD ( signed char pin , unsigned char mode )
{
    if ( ( pin <= 7 ) )
    {
        * DDRD = ( mode ? ( ( * DDRD ) | 1 << ( pin ) ) : ( ( * DDRD ) & ~ ( 1 << ( pin ) ) ) ) ;
        return 0 ;
    }
    if ( ( pin <= 13 ) )
    {
        * DDRB = ( mode ? ( ( * DDRB ) | 1 << ( ( pin - 8 ) ) ) : ( ( * DDRB ) & ~ ( 1 << ( ( pin - 8 ) ) ) ) ) ;
        return 0 ;
    }
}
signed char DigitalWrite ( unsigned char pin , unsigned char value )
{
    if ( ( pin < 0 ) )
    {
        return 0 ;
    }
    else
    if ( ( pin <= 7 ) )
    {
        * PORTD = ( value ? ( ( * PORTD ) | 1 << ( pin ) ) : ( ( * PORTD ) & ~ ( 1 << ( pin ) ) ) ) ;
    }
    else
    if ( ( pin <= 13 ) )
    {
        * PORTB = ( value ? ( ( * PORTB ) | 1 << ( ( pin - 8 ) ) ) : ( ( * PORTB ) & ~ ( 1 << ( ( pin - 8 ) ) ) ) ) ;
    }
    else
    if ( ( pin <= 20 ) )
    {
        * PORTC = ( value ? ( ( * PORTC ) | 1 << ( ( pin - 14 ) ) ) : ( ( * PORTC ) & ~ ( 1 << ( ( pin - 14 ) ) ) ) ) ;
    }
}
signed char DigitalFlip ( unsigned char pin )
{
    if ( ( pin < 0 ) )
    {
        return 0 ;
    }
    else
    if ( ( pin <= 7 ) )
    {
        * PORTD = ( ( ! ( * PORTD & ( 1 << ( pin ) ) ) ) ? ( ( * PORTD ) | 1 << ( pin ) ) : ( ( * PORTD ) & ~ ( 1 << ( pin ) ) ) ) ;
    }
    else
    if ( ( pin <= 13 ) )
    {
        * PORTB = ( ( ! ( * PORTB & ( 1 << ( ( pin - 8 ) ) ) ) ) ? ( ( * PORTB ) | 1 << ( ( pin - 8 ) ) ) : ( ( * PORTB ) & ~ ( 1 << ( ( pin - 8 ) ) ) ) ) ;
    }
    else
    if ( ( pin <= 20 ) )
    {
        * PORTC = ( ( ! ( * PORTC & ( 1 << ( ( pin - 14 ) ) ) ) ) ? ( ( * PORTC ) | 1 << ( ( pin - 14 ) ) ) : ( ( * PORTC ) & ~ ( 1 << ( ( pin - 14 ) ) ) ) ) ;
    }
}
void SetFastPWMPin6 ( signed int dutyCycle )
{
    signed char bit ;
    * DDRD = ( 1 ? ( ( * DDRD ) | 1 << ( 6 ) ) : ( ( * DDRD ) & ~ ( 1 << ( 6 ) ) ) ) ;
    bit = 2 ;
    signed char _i [ ] = { 0 , 7 , 1 } ; _i [ 2 ] = ( _i [ 0 ] < _i [ 1 ] ? 1 : -1 ) ; signed char i = _i [ 0 ] ; do { if ( ( ( dutyCycle % bit ) > 0 ) ) {     * OCR0A = ( 1 ? ( ( * OCR0A ) | 1 << ( i ) ) : ( ( * OCR0A ) & ~ ( 1 << ( i ) ) ) ) ;     dutyCycle = ( dutyCycle - ( dutyCycle % bit ) ) ; } else {     * OCR0A = ( 0 ? ( ( * OCR0A ) | 1 << ( i ) ) : ( ( * OCR0A ) & ~ ( 1 << ( i ) ) ) ) ; } bit = ( bit * 2 ) ; _i [ 0 ] += _i [ 2 ] ; i = _i [ 0 ] ; } while ( i != _i [ 1 ] + _i [ 2 ] ) ;
    * TCCR0A = ( 1 ? ( ( * TCCR0A ) | 1 << ( 7 ) ) : ( ( * TCCR0A ) & ~ ( 1 << ( 7 ) ) ) ) ;
    * TCCR0A = ( 1 ? ( ( * TCCR0A ) | 1 << ( 0 ) ) : ( ( * TCCR0A ) & ~ ( 1 << ( 0 ) ) ) ) ;
    * TCCR0A = ( 1 ? ( ( * TCCR0A ) | 1 << ( 1 ) ) : ( ( * TCCR0A ) & ~ ( 1 << ( 1 ) ) ) ) ;
    * TCCR0B = ( 1 ? ( ( * TCCR0B ) | 1 << ( 0 ) ) : ( ( * TCCR0B ) & ~ ( 1 << ( 0 ) ) ) ) ;
}
void main ( )
{
    PINB = ( volatile unsigned char * ) ( 35 ) ;
    DDRB = ( volatile unsigned char * ) ( 36 ) ;
    PORTB = ( volatile unsigned char * ) ( 37 ) ;
    PINC = ( volatile unsigned char * ) ( 38 ) ;
    DDRC = ( volatile unsigned char * ) ( 39 ) ;
    PORTC = ( volatile unsigned char * ) ( 40 ) ;
    PIND = ( volatile unsigned char * ) ( 41 ) ;
    DDRD = ( volatile unsigned char * ) ( 42 ) ;
    PORTD = ( volatile unsigned char * ) ( 43 ) ;
    TIFR0 = ( volatile unsigned char * ) ( 53 ) ;
    TIFR1 = ( volatile unsigned char * ) ( 54 ) ;
    TIFR2 = ( volatile unsigned char * ) ( 55 ) ;
    PCIFR = ( volatile unsigned char * ) ( 59 ) ;
    EIFR = ( volatile unsigned char * ) ( 60 ) ;
    EIMSK = ( volatile unsigned char * ) ( 61 ) ;
    GPIOR0 = ( volatile unsigned char * ) ( 62 ) ;
    EECR = ( volatile unsigned char * ) ( 63 ) ;
    EEDR = ( volatile unsigned char * ) ( 64 ) ;
    EEARL = ( volatile unsigned char * ) ( 65 ) ;
    EEARH = ( volatile unsigned char * ) ( 66 ) ;
    GTCCR = ( volatile unsigned char * ) ( 67 ) ;
    TCCR0A = ( volatile unsigned char * ) ( 68 ) ;
    TCCR0B = ( volatile unsigned char * ) ( 69 ) ;
    TCNT0 = ( volatile unsigned char * ) ( 70 ) ;
    OCR0A = ( volatile unsigned char * ) ( 71 ) ;
    OCR0B = ( volatile unsigned char * ) ( 72 ) ;
    GPIOR1 = ( volatile unsigned char * ) ( 74 ) ;
    GPIOR2 = ( volatile unsigned char * ) ( 75 ) ;
    SPCR0 = ( volatile unsigned char * ) ( 76 ) ;
    SPSR0 = ( volatile unsigned char * ) ( 77 ) ;
    SPDR0 = ( volatile unsigned char * ) ( 78 ) ;
    ACSR = ( volatile unsigned char * ) ( 80 ) ;
    DWDR = ( volatile unsigned char * ) ( 81 ) ;
    SMCR = ( volatile unsigned char * ) ( 83 ) ;
    MCUSR = ( volatile unsigned char * ) ( 84 ) ;
    MCUCR = ( volatile unsigned char * ) ( 85 ) ;
    SPMCSR = ( volatile unsigned char * ) ( 87 ) ;
    SPL = ( volatile unsigned char * ) ( 93 ) ;
    SPH = ( volatile unsigned char * ) ( 94 ) ;
    SREG = ( volatile unsigned char * ) ( 95 ) ;
    WDTCSR = ( volatile unsigned char * ) ( 96 ) ;
    CLKPR = ( volatile unsigned char * ) ( 97 ) ;
    PRR = ( volatile unsigned char * ) ( 100 ) ;
    OSCCAL = ( volatile unsigned char * ) ( 102 ) ;
    PCICR = ( volatile unsigned char * ) ( 104 ) ;
    EICRA = ( volatile unsigned char * ) ( 105 ) ;
    PCMSK0 = ( volatile unsigned char * ) ( 107 ) ;
    PCMSK1 = ( volatile unsigned char * ) ( 108 ) ;
    PCMSK2 = ( volatile unsigned char * ) ( 109 ) ;
    TIMSK0 = ( volatile unsigned char * ) ( 110 ) ;
    TIMSK1 = ( volatile unsigned char * ) ( 111 ) ;
    TIMSK2 = ( volatile unsigned char * ) ( 112 ) ;
    ADCL = ( volatile unsigned char * ) ( 120 ) ;
    ADCH = ( volatile unsigned char * ) ( 121 ) ;
    ADCSRA = ( volatile unsigned char * ) ( 122 ) ;
    ADCSRB = ( volatile unsigned char * ) ( 123 ) ;
    ADMUX = ( volatile unsigned char * ) ( 124 ) ;
    DIDR0 = ( volatile unsigned char * ) ( 126 ) ;
    DIDR1 = ( volatile unsigned char * ) ( 127 ) ;
    TCCR1A = ( volatile unsigned char * ) ( 128 ) ;
    TCCR1B = ( volatile unsigned char * ) ( 129 ) ;
    TCCR1C = ( volatile unsigned char * ) ( 130 ) ;
    TCNT1L = ( volatile unsigned char * ) ( 132 ) ;
    TCNT1H = ( volatile unsigned char * ) ( 133 ) ;
    ICR1L = ( volatile unsigned char * ) ( 134 ) ;
    ICR1H = ( volatile unsigned char * ) ( 135 ) ;
    OCR1AL = ( volatile unsigned char * ) ( 136 ) ;
    OCR1AH = ( volatile unsigned char * ) ( 137 ) ;
    OCR1BL = ( volatile unsigned char * ) ( 138 ) ;
    OCR1BH = ( volatile unsigned char * ) ( 139 ) ;
    TCCR2A = ( volatile unsigned char * ) ( 176 ) ;
    TCCR2B = ( volatile unsigned char * ) ( 177 ) ;
    TCNT2 = ( volatile unsigned char * ) ( 178 ) ;
    OCR2A = ( volatile unsigned char * ) ( 179 ) ;
    OCR2B = ( volatile unsigned char * ) ( 180 ) ;
    ASSR = ( volatile unsigned char * ) ( 182 ) ;
    TWBR = ( volatile unsigned char * ) ( 184 ) ;
    TWSR = ( volatile unsigned char * ) ( 185 ) ;
    TWAR = ( volatile unsigned char * ) ( 186 ) ;
    TWDR = ( volatile unsigned char * ) ( 187 ) ;
    TWCR = ( volatile unsigned char * ) ( 188 ) ;
    TWAMR = ( volatile unsigned char * ) ( 189 ) ;
    UCSR0A = ( volatile unsigned char * ) ( 192 ) ;
    UCSR0B = ( volatile unsigned char * ) ( 193 ) ;
    UCSR0C = ( volatile unsigned char * ) ( 194 ) ;
    UBRR0L = ( volatile unsigned char * ) ( 196 ) ;
    UBRR0H = ( volatile unsigned char * ) ( 197 ) ;
    UDR0 = ( volatile unsigned char * ) ( 198 ) ;
    INTERRUPT_LOW = 0 ;
    ANY_EDGE = 1 ;
    RISING_EDGE = 2 ;
    FALLING_EDGE = 3 ;
    INDEX_INT0 = 0 ;
    INDEX_INT1 = 1 ;
    INDEX_TIMER2_OCA = 2 ;
    INDEX_TIMER2_OCB = 3 ;
    INDEX_TIMER2_OF = 4 ;
    INDEX_TIMER1_IC = 5 ;
    INDEX_TIMER1_OCA = 6 ;
    INDEX_TIMER1_OCB = 7 ;
    INDEX_TIMER1_OF = 8 ;
    INDEX_TIMER0_OCA = 9 ;
    INDEX_TIMER0_OCB = 10 ;
    INDEX_TIMER0_OF = 11 ;
    INDEX_USART_RXC = 12 ;
    INDEX_USART_DRE = 13 ;
    INDEX_USART_TXC = 14 ;
    INT0_vect = 2 ;
    INT1_vect = 3 ;
    PCINT0_vect = 4 ;
    PCINT1_vect = 5 ;
    PCINT2_vect = 6 ;
    WDT_vect = 7 ;
    TIMER2_COMPA_vect = 8 ;
    TIMER2_COMPB_vect = 9 ;
    TIMER2_OVF_vect = 10 ;
    TIMER1_CAPT_vect = 11 ;
    TIMER1_COMPA_vect = 12 ;
    TIMER1_COMPB_vect = 13 ;
    TIMER1_OVF_vect = 14 ;
    TIMER0_COMPA_vect = 15 ;
    TIMER0_COMPB_vect = 16 ;
    TIMER0_OVF_vect = 17 ;
    SPI_STC_vect = 18 ;
    USART_RX_vect = 19 ;
    USART_UDRE_vect = 20 ;
    USART_TX_vect = 21 ;
    ADC_vect = 22 ;
    EE_READY_vect = 23 ;
    ANALOG_COMP_vect = 24 ;
    TWI_vect = 25 ;
    SPM_READY_vect = 26 ;
    INT0 = 2 ;
    INT1 = 3 ;
    INPUT = 0 ;
    OUTPUT = 1 ;
    PULLUP = 1 ;
    NO_PULLUP = 0 ;
    HIGH = 1 ;
    LOW = 0 ;
    SetAnalogMode ( 1 ) ;
    PinModeD ( 13 , OUTPUT ) ;
    PinModeA ( 0 , 0 ) ;
    DigitalWrite ( 13 , PULLUP ) ;
    counter = 0 ;
    limiter = 0 ;
    value = 1 ;
    while ( 1 )
    {
        limiter = AnalogRead ( 0 ) ;
        if ( ( counter > limiter ) )
        {
            counter = 0 ;
            value = ( ! value ) ;
            if ( value )
            {
                DigitalWrite ( 13 , 0 ) ;
            }
            else
            {
                DigitalWrite ( 13 , 1 ) ;
            }
        }
        counter = ( counter + 1 ) ;
    }
}