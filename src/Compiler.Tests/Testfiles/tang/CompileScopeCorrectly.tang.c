signed char foo ( ) ;
signed char a ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char foo ( )
{
    if ( 1 )
    {
        return 2 ;
    }
    return 4 ;
}
void main ( )
{
    a = foo ( ) ;
}