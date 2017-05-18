unsigned long c ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
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