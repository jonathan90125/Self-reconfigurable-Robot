#ifndef __DHT11_H
#define __DHT11_H 
#include "sys.h"   
//////////////////////////////////////////////////////////////////////////////////	 

//DHT11数字温湿度传感器驱动代码	   
//使用PB11端口
//All rights reserved									  
//////////////////////////////////////////////////////////////////////////////////
 
//IO方向设置
#define DHT11_IO_IN()  {GPIOB->CRH&=0XFFFFFFF0;GPIOB->CRH|=8;}
#define DHT11_IO_OUT() {GPIOB->CRH&=0XFFFFFFF0;GPIOB->CRH|=3;}
////IO操作函数											   
#define	DHT11_DQ_OUT PBout(8) //数据端口	PB8
#define	DHT11_DQ_IN  PBin(8)  //数据端口	PB8


u8 DHT11_Init(void);//初始化DHT11
u8 DHT11_Read_Data(u8 *temp,u8 *humi);//读取温湿度
u8 DHT11_Read_Byte(void);//读出一个字节
u8 DHT11_Read_Bit(void);//读出一个位
u8 DHT11_Check(void);//检测是否存在DHT11
void DHT11_Rst(void);//复位DHT11    
#endif















