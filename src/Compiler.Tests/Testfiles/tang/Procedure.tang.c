signed int i ;
void procedure ( ) ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void procedure ( )
{
    i = 10 ;
}
void main ( )
{
    i = 0 ;
    procedure ( ) ;
}