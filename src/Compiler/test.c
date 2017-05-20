volatile unsigned char * PORT36 ;
volatile unsigned char * PORT37 ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    PORT36 = ( volatile unsigned char * ) ( 36 ) ;
    PORT37 = ( volatile unsigned char * ) ( 37 ) ;
    * PORT36 = ( 1 ? ( ( * PORT36 ) | 1 << ( 5 ) ) : ( ( * PORT36 ) & ~ ( 1 << ( 5 ) ) ) ) ;
    * PORT37 = ( 1 ? ( ( * PORT37 ) | 1 << ( 5 ) ) : ( ( * PORT37 ) & ~ ( 1 << ( 5 ) ) ) ) ;
}