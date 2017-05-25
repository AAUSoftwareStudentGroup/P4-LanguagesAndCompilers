unsigned long c ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1, i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    ( * ( volatile unsigned char * ) ( 36 ) ) = ( 1 ? ( ( * ( volatile unsigned char * ) ( 36 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 36 ) ) & ~ ( 1 << ( 5 ) ) ) ) ;
    ( * ( volatile unsigned char * ) ( 37 ) ) = ( 0 ? ( ( * ( volatile unsigned char * ) ( 37 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 37 ) ) & ~ ( 1 << ( 5 ) ) ) ) ;
    c = 0 ;
    while ( 1 )
    {
        if ( ( c == 300000 ) )
        {
            ( * ( volatile unsigned char * ) ( 37 ) ) = ( ( ! ( ( * ( volatile unsigned char * ) ( 37 ) ) & ( 1 << ( 5 ) ) ) ) ? ( ( * ( volatile unsigned char * ) ( 37 ) ) | 1 << ( 5 ) ) : ( ( * ( volatile unsigned char * ) ( 37 ) ) & ~ ( 1 << ( 5 ) ) ) ) ;
            c = 0 ;
        }
        c = ( c + 1 ) ;
    }
}