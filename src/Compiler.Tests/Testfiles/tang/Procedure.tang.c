signed int i ;
void procedure ( ) ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1 , i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void procedure ( )
{
    i = 10 ;
}
void main ( )
{
    i = 0 ;
    procedure ( ) ;
}