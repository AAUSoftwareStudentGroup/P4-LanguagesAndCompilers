signed long fac ( signed char n ) ;
void main ( ) ;
signed long fac ( signed char n )
{
    unsigned long res ;
    res = 1 ;
    if ( ( n > 1 ) )
    {
        res = ( n * fac ( ( n - 1 ) ) ) ;
    }
    return res ;
}
void main ( )
{
    fac ( fac ( 3 ) ) ;
}
