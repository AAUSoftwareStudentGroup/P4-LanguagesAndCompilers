void main ( void ) ;
volatile unsigned short * r16 ;
volatile unsigned char * r8 ;
unsigned char b ;
signed int i32 ;
signed int i16 ;
signed char i8 ;
unsigned long ui32 ;
unsigned int ui16 ;
unsigned char ui8 ;
void main ( void )
{
    ui8 = 8;
    ui16 = 16;
    ui32 = 32;
    i8 = 8;
    i16 = 16;
    i32 = 32;
    b = 1;
    r8 = ( volatile unsigned char * ) ( 8 );
    r16 = ( volatile unsigned short * ) ( 16 );
}
