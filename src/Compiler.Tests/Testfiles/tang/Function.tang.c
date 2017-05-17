signed char add ( signed char a , signed char b ) ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char add ( signed char a , signed char b )
{
    return ( a + b ) ;
}
void main ( )
{
    add ( 2 , add ( add ( 2 , 3 ) , add ( 2 , Pow ( 3 , 2 ) ) ) ) ;
}