signed char add ( signed char a , signed char b ) ;
signed char b ;
signed char add2 ( signed char b ) ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char add ( signed char a , signed char b )
{
    return ( a + b ) ;
}
signed char add2 ( signed char b )
{
    return b ;
}
void main ( )
{
}