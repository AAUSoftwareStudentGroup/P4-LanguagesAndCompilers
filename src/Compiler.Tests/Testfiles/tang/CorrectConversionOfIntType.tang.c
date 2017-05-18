signed char a ;
signed int b ;
signed char c ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    a = 10 ;
    b = 20 ;
    c = ( a + b ) ;
}