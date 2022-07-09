#include "lee.h"
#include "led.h"
#include "package.h"
#include "usart.h"
#include "sys.h"
#include "usart3.h"
u8 uartSendNextByte(void);

typedef struct sPkgBase__
{
	u8 length;
	u8 data[63];
}sPkgBase;


 
#define SS_IDLE 0XFF 
#define SS_HEAD 0XA0 
static u8 Send_counter = SS_IDLE;


 
static sPkgBase Send_temp;

 	
u8 sendPkg(sPkg* pkg)
{
	u16 i;
	u8 data;
  sPkgBase* pb = (sPkgBase*)pkg;
	if(Send_counter != SS_IDLE)
	{
		return fail;
	}

	Send_temp.length = pb->length;
	for( i = 0;i<Send_temp.length;i++)
	{
		Send_temp.data[i] = pb->data[i];	
	}
	Send_counter = SS_HEAD;
	 
	
  while((USART3->SR&0X40)==0); 
	USART3->DR=0xfe;
	
	do{
	
	data=uartSendNextByte();
	
  while((USART3->SR&0X40)==0); 
	USART3->DR=data;
		
	}while(data != 0xff);
	
	return done;
}


u8 uartSendNextByte(void)
{
	switch (Send_counter)
	{
	case SS_HEAD:
		Send_counter = 0;
		return Send_temp.length;
	case SS_IDLE:
		return 0xff;
	default:
		if(Send_counter == Send_temp.length)
		{
			Send_counter = SS_IDLE;
			return 0xff;
		}
		else
		{
			if(Send_temp.data[Send_counter] >= 0xfe)
			{
				Send_temp.data[Send_counter]-=2;
				return 0xfe;
			}
			else
			{
				u8 temp = Send_temp.data[Send_counter];
				Send_counter++;
				return temp;
			}
		}
	}
}
