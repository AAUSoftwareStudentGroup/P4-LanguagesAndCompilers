volatile unsigned char * ddrb ;
volatile unsigned char * port ;
signed long counter ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
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
            counter = 0 ;
            * port = ( ( ! ( * port & ( 1 << ( 5 ) ) ) ) ? ( ( * port ) | 1 << ( 5 ) ) : ( ( * port ) & ~ ( 1 << ( 5 ) ) ) ) ;
        }
        else
        {
            counter = ( counter + 1 ) ;
        }
    }
}