unsigned char counter ;
void main ( ) ;
void main ( )
{
    ( * ( volatile unsigned char * ) ( 36 ) ) = ( 1 ? ( ( * ( volatile unsigned char * ) ( 36 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 36 ) ) & ~ ( 1 << ( 5 ) ) ) ) ;
    ( * ( volatile unsigned char * ) ( 37 ) ) = ( 1 ? ( ( * ( volatile unsigned char * ) ( 37 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 37 ) ) & ~ ( 1 << ( 5 ) ) ) ) ;
    counter = 0 ;
    while ( 1 )
    {
        if ( ( counter == 100000 ) )
        {
            counter = 0 ;
            ( * ( volatile unsigned char * ) ( 37 ) ) = ( ( ! ( ( * ( volatile unsigned char * ) ( 37 ) ) & ( 1 << ( 5 ) ) ) ) ? ( ( * ( volatile unsigned char * ) ( 37 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 37 ) ) & ~ ( 1 << ( 5 ) ) ) ) ;
        }
        else
        {
            counter = ( counter + 1 ) ;
        }
    }
}
