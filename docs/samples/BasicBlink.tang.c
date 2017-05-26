signed char h ( signed char a , signed char b ) ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1 , i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char h ( signed char a , signed char b )
{
    return ( a + b ) ;
}
void main ( )
{
    h ( 100 , h ( 100 , 100 ) ) ;
}