#include "led.h"
#include "lee.h"
#include "delay.h"
#include "sys.h"
#include "usart.h"
#include "dht11.h" 	
#include "package.h"
#include "DL_LN3X.h"
#include "usart3.h"			 	 
#include "string.h"	  
#include <stdio.h>  

void recievePkg(sPkg* pkg);
void loopReceive(void);
void loopAll(void);
void initAll(void);
extern void uartRevieveByte(u8 data);

	u8 temperature;  	    
	u8 humidity;  

newPkg(3) redPkg={7,0x90,0x32,0x00,0x00,{0,10,20}};

char buf1[7]={0x05,0x90,0x21,0x00,0x00,0x01,0xFF}; 
char buf2[7]={0x05,0x90,0x21,0x00,0x00,0x02,0xFF}; 
char buf3[7]={0x05,0x90,0x21,0x00,0x00,0x03,0xFF}; 
char buf4[7]={0x05,0x90,0x21,0x00,0x00,0x04,0xFF}; 


newPkg(1) THPkg={5,0x90,0x32,0x01,0x00,{0}}; 

void loopAll()
{ 
	u16 i;
	u8 reclen=0;  
	u8 m=0;

	
	
	while (1)
	{
	
		THPkg.dis_port = 0xa0;
		THPkg.data[0] = 30;
		sendPkg((sPkg*)(&THPkg));

		for(i = 0;i<100;i++)
		{
			delay_ms(10);
			loopReceive();
		}		
		THPkg.dis_port = 0xa1;
		THPkg.data[0] = m;
		m++;
		if(m==0xff)m=0;
		sendPkg((sPkg*)(&THPkg));
		
		
			
		if(USART3_RX_STA&0X8000)			 
		 {

		   reclen=USART3_RX_STA&0X7FFF;	 
			 
			 for(i=0;i<reclen;i++)
			 uartRevieveByte(USART3_RX_BUF[i]);

			 USART3_RX_STA=0;	 
		 }

		for(i = 0;i<100;i++)
			{
				delay_ms(10);
				loopReceive();
			}		 
 									
	}
}

void loopReceive(void)
{
	sPkg* pkg;
	pkg = getNextPkg();
	while(pkg != NULL)
	{
		recievePkg(pkg);
		pkg = getNextPkg();
	}
}


void recievePkg(sPkg* pkg)
{
	
	switch(pkg->dis_port)
	{
		case 0xa0:		
		if(pkg->data[0] == 0x01)
		{
			
		LED0=!LED0; 
		}
		break;
		
		case 0xb0:		
		if(pkg->data[0] == 0x01)
		{

		LED1=!LED1; 
		}
		break;
		
		case 0xc0:		
		if(pkg->data[0] == 0x01)
		{
		LED2=!LED2; 
		}
		break;
		
		case 0xd0:		
		if(pkg->data[0] == 0x01)
		{

			GPIO_SetBits(GPIOA,GPIO_Pin_8);
    	GPIO_SetBits(GPIOA,GPIO_Pin_5);
	    GPIO_SetBits(GPIOA,GPIO_Pin_6);
		}
		break;
		
		default:
		break;		
	}
}


void initAll()
{

	delay_init();	    	  
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_2); 
	uart_init(115200);	  
	usart3_init(115200); 
	LED_Init();		  	  
	
	
	
}

 int main(void)
 {	


	initAll();
	loopAll();

}


