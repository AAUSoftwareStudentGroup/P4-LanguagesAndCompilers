long long int c ;
void main ( void )
{
    ( * ( volatile unsigned char * ) ( 36 ) ) = ( 1 ? ( ( * ( volatile unsigned char * ) ( 36 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 36 ) ) & ~ ( 1 << ( 5 ) ) ) );
    ( * ( volatile unsigned char * ) ( 37 ) ) = ( 0 ? ( ( * ( volatile unsigned char * ) ( 37 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 37 ) ) & ~ ( 1 << ( 5 ) ) ) );
    c = 0;
    while(1)
    {
        if(( c == 300000 ))
        {
            ( * ( volatile unsigned char * ) ( 37 ) ) = ( ( ! ( ( * ( volatile unsigned char * ) ( 37 ) ) & ( 1 << ( 5 ) ) ) ) ? ( ( * ( volatile unsigned char * ) ( 37 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 37 ) ) & ~ ( 1 << ( 5 ) ) ) );
            c = 0;
        }
        c = ( c + 1 );
    }
}
