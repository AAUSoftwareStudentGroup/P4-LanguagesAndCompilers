unsigned char a ;
signed char bar ( signed int n ) ;
signed char foo ( ) ;
void main ( ) ;
signed char bar ( signed int n )
{
    a = ( a + 5 ) ;
    return ( foo ( ) + n ) ;
}
signed char foo ( )
{
    return 4 ;
}
void main ( )
{
    a = 4 ;
    bar ( foo ( ) ) ;
}
