signed char m ;
signed char max ( signed char a , signed char b ) ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char max ( signed char a , signed char b )
{
    if ( ( a > b ) )
    {
        return ( a + m ) ;
    }
    else
    {
        return b ;
    }
}
void main ( )
{
    m = max ( max ( 1 , 2 ) , 3 ) ;
}