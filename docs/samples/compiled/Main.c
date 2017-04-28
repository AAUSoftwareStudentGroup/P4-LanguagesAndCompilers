volatile unsigned char * ddrb ;
volatile unsigned char * portb ;
long long int counter ;
void main ( void )
{
    ddrb = ( volatile unsigned char * ) ( 36 );
    portb = ( volatile unsigned char * ) ( 37 );
    * ddrb = ( 1 ? ( ( * ddrb ) | 1 << ( 5 ) ) : ( ( * ddrb ) & ~ ( 1 << ( 5 ) ) ) );
    * portb = ( 1 ? ( ( * portb ) | 1 << ( 5 ) ) : ( ( * portb ) & ~ ( 1 << ( 5 ) ) ) );
    counter = 0;
    while(1)
    {
        if(( counter == 100000 ))
        {
            counter = 0;
            * portb = ( ( ! ( * portb & ( 1 << ( 5 ) ) ) ) ? ( ( * portb ) | 1 << ( 5 ) ) : ( ( * portb ) & ~ ( 1 << ( 5 ) ) ) );
            counter = ( counter + 1 );
        }
    }
}
