
/*
 * uart.h
 *
 * Created: 25.12.2020 21:39:36
 *  Author: Enes
 */ 
#ifndef uart_h
#define uart_h
void init_uart(int baud);
void send_uart(char *mesaj);
unsigned char get_string();
#endif