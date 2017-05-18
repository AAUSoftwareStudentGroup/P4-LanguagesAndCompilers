unsigned char off ;
unsigned char on ;
signed int zero ;
signed int hunna ;
unsigned char falseStatements ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    off = ( ( ( 1 || 0 ) ) && ( ! 1 ) ) ;
    on = ( ( ( ( 43 - 1 ) ) == 42 ) ) ;
    zero = ( ( ( ( ( 42 + 18 ) ) * ( ( 10 / 2 ) ) ) ) % 5 ) ;
    hunna = Pow ( 10 , 2 ) ;
    falseStatements = ( ( ( hunna <= 101 ) ) && ( ( hunna >= 99 ) ) ) ;
}