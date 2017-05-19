signed long a ;
signed long b ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    a = 20 ;
    b = 40 ;
    if ( ( a == b ) )
    {
        a = ( a + 1 ) ;
    }
}