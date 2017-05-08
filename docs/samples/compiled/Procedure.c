void setup ( ) ;
signed int counter ;
void main ( ) ;
void setup ( )
{
    volatile unsigned char * ddrb ;
    volatile unsigned char * portb ;
    ddrb = ( volatile unsigned char * ) ( 36 ) ;
    portb = ( volatile unsigned char * ) ( 37 ) ;
    * ddrb = ( 1 ? ( ( * ddrb ) | 1 << ( 5 ) ) : ( ( * ddrb ) & ~ ( 1 << ( 5 ) ) ) ) ;
    * portb = ( 1 ? ( ( * portb ) | 1 << ( 5 ) ) : ( ( * portb ) & ~ ( 1 << ( 5 ) ) ) ) ;
}
void main ( )
{
    setup ( ) ;
    counter = 0 ;
    while ( 1 )
    {
        if ( ( counter == 100000 ) )
        {
            counter = 0 ;
        }
        if ( ( ! ( ( counter == 100000 ) ) ) )
        {
            counter = ( counter + 1 ) ;
        }
    }
}
