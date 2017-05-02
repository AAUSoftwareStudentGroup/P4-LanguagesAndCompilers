volatile unsigned char * ddrb ;
volatile unsigned char * port ;
unsigned char counter ;
void main ( ) ;
void main ( )
{
    ddrb = ( volatile unsigned char * ) ( 36 ) ;
    port = ( volatile unsigned char * ) ( 37 ) ;
    * ddrb = ( 1 ? ( ( * ddrb ) | 1 << ( 5 ) ) : ( ( * ddrb ) & ~ ( 1 << ( 5 ) ) ) ) ;
    * port = ( 1 ? ( ( * port ) | 1 << ( 5 ) ) : ( ( * port ) & ~ ( 1 << ( 5 ) ) ) ) ;
    counter = 0 ;
    while ( 1 )
    {
        if ( ( counter == 100000 ) )
        {
            unsigned char a ;
            a = 0 ;
            counter = 0 ;
            * port = ( ( ! ( * port & ( 1 << ( 5 ) ) ) ) ? ( ( * port ) | 1 << ( 5 ) ) : ( ( * port ) & ~ ( 1 << ( 5 ) ) ) ) ;
        }
        else
        {
            counter = ( counter + 1 ) ;
        }
    }
}
