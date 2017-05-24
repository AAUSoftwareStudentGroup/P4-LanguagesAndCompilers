volatile unsigned char * DDRB ;
volatile unsigned char * PORTB ;
void wait ( ) ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void wait ( )
{
    for ( signed long i = 1 ; i <= 3200000 ; i ++ )
    {
    }
}
void main ( )
{
    DDRB = ( volatile unsigned char * ) ( 36 ) ;
    PORTB = ( volatile unsigned char * ) ( 37 ) ;
    * DDRB = ( 1 ? ( ( * DDRB ) | 1 << ( 5 ) ) : ( ( * DDRB ) & ~ ( 1 << ( 5 ) ) ) ) ;
    while ( 1 )
    {
        * PORTB = ( 1 ? ( ( * PORTB ) | 1 << ( 5 ) ) : ( ( * PORTB ) & ~ ( 1 << ( 5 ) ) ) ) ;
        wait ( ) ;
        * PORTB = ( 0 ? ( ( * PORTB ) | 1 << ( 5 ) ) : ( ( * PORTB ) & ~ ( 1 << ( 5 ) ) ) ) ;
        wait ( ) ;
    }
}