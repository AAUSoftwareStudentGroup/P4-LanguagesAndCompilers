signed char foo ( ) ;
signed char a ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1 , i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char foo ( )
{
    return 8 ;
}
void main ( )
{
    a = foo ( ) ;
}