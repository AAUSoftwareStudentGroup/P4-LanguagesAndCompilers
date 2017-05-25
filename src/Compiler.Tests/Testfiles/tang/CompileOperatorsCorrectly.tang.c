unsigned char off ;
unsigned char on ;
signed int zero ;
signed int hunna ;
unsigned char falseStatements ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1 , i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    off = ( ( ( 1 || 0 ) ) && ( ! 1 ) ) ;
    on = ( ( ( ( 43 - 1 ) ) == 42 ) ) ;
    zero = ( ( ( ( ( 42 + 18 ) ) * ( ( 10 / 2 ) ) ) ) % 5 ) ;
    hunna = Pow ( 10 , 2 ) ;
    falseStatements = ( ( ( hunna <= 101 ) ) && ( ( hunna >= 99 ) ) ) ;
}