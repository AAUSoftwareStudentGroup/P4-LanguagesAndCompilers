signed char a ;
signed char foo ( ) ;
void __vector_1 ( ) __attribute__ ( ( signal , used , externally_visible ) ) ;
signed long Pow ( signed long a , signed long b ) ;
void main ( ) ;
signed long Pow ( signed long a , signed long b ) { signed long r = 1, i ; for ( i = 0 ; i < b ; i ++ ) { r *= a ; } return r ; }
signed char foo ( )
{
    return 5 ;
}
void __vector_1 ( )
{
    signed char i ;
    i = 5 ;
}
void main ( )
{
    a = 2 ;
    __asm__ __volatile__ ("sei" ::: "memory") ;
    __asm__ __volatile__ ("cli" ::: "memory") ;
}