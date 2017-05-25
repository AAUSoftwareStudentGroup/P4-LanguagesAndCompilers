signed char a ;
signed int b ;
signed int c ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1, i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    a = 10 ;
    b = 20 ;
    c = ( a + b ) ;
}