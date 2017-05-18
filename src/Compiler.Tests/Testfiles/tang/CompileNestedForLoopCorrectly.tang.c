unsigned long sum ;
int Pow ( signed long a , unsigned long b ) ;
void main ( ) ;
int Pow ( signed long a , unsigned long b ) { signed long r = 1 ; for ( unsigned long i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
void main ( )
{
    sum = 0 ;
    for ( signed char x = 0 ; x <= 10 ; x ++ )
    {
        for ( signed char y = 0 ; y <= x ; y ++ )
        {
            sum = ( sum + ( x * y ) ) ;
        }
    }
}