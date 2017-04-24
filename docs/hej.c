int main ( void ) { volatile unsigned char * ddrb ;
 volatile unsigned char * portb ;
 ddrb = ( volatile unsigned char * ) ( 36 ) ;
 portb = ( volatile unsigned char * ) ( 37 ) ;
 * ddrb = ( 1 ? ( ( * ddrb ) | 1 << ( 5 ) ) : ( ( * ddrb ) & ! ( 1 << ( 5 ) ) ) ) ;
 * portb = ( 0 ? ( ( * portb ) | 1 << ( 5 ) ) : ( ( * portb ) & ! ( 1 << ( 5 ) ) ) ) ;
 long long int c ;
 c = 0 ;
 while ( 1 ) { if ( ( c == 100000 ) ) { * portb = ( ( ! ( * portb & ( 1 << ( 5 ) ) ) ) ? ( ( * portb ) | 1 << ( 5 ) ) : ( ( * portb ) & ! ( 1 << ( 5 ) ) ) ) ;
 c = 0 ;
 } c = ( c + 1 ) ;
 } }