signed char t ( unsigned char h ) ;
unsigned char bob ( ) ;
unsigned char bob2 ( ) ;
void main ( ) ;
signed char t ( unsigned char h )
{
    if ( ( h && bob ( ) ) )
    {
        return 2 ;
    }
}
unsigned char bob ( )
{
    return 1 ;
}
unsigned char bob2 ( )
{
    return 1 ;
}
void main ( )
{
    t ( ( bob ( ) && ( ! bob ( ) ) ) ) ;
}
