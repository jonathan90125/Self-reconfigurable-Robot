# Self-reconfigurable Robot

## PHASE 1

### Background

Modular self-reconfigurable robots (MSRR) are robots that consist of many relatively simple individual robots which can cooperate together by changing their configuration according to different tasks. Many researches as shown below about this topic have been done in recent years, trying to achieve a practical robotic structure.  

<div align=center><img src=".\Pictures\phase_1\0.jpg" alt="0" width="600" /></div>

### Introduction

In my opinion, former MSRR's major problem is the limited number of connectors on each individual robots. In order to solve that problem, I designed my own self-reconfigurable robot which contains two types of modules. The sphere modules can be connected by the stick modules to form various three-dimensional shapes. Sphere module contains ferromagnetic spherical shell and an internal actuating system. The remaining space in the shell can be used for electronic components and power supply (only one of eight sections is illustrated in the graph). An additional passive docking ports is on the shell which are used to cooperate with stick module. The stick module is equipped with two magnets and two active docking ports on both ends. The remaining space in the middle of the module is used for two motors which can actuate the docking ports. The internal  electronic components for each modules are very simple as shown in the graph below.

<div align=center><img src=".\Pictures\phase_1\1.jpg" alt="1" width="500" /> </div>

<div align=center><img src=".\Pictures\phase_1\2.jpg" alt="7" width="500" /> </div>

<div align=center><img src=".\Pictures\phase_1\7.jpg" alt="7" width="500" /></div>

### Actuating System

Figures below show the structure of the actuating system. There are three orthogonal circles inside the shell with 24 electromagnets on each circle, and each circle’s structure is similar to the stator of motor. All the electromagnets inside the sphere module are arranged  to control the magnetic force distribution of the spherical shell, which in turn can drive the magnets  at the end of the stick module to move on the surface of the sphere.

<div align=center><img src=".\Pictures\phase_1\3.jpg" alt="3" width="500" /></div>

### Docking System

There are two types of docking ports, the active docking ports of stick module and passive docking ports of sphere module. The hooks of active connector which is implemented inside the stick module have three states to provide suitable stability for the system. There are two different hooks in the active connector, one is to keep the stick module strongly connected to the surface of the sphere, the other is used to keep the stick locked at a certain position. There are three conditions of the two hooks, both nonactivated, only hook 1 activated, both activated, which means hook 2 can only be activated when 1 is activated. Hence, only one motor is needed to control both hooks since they are not independent.

<div align=center><img src=".\Pictures\phase_1\4.jpg" alt="4" width="500" /></div>

<div align=center><img src=".\Pictures\phase_1\5.jpg" alt="5" width="500" /></div>

### Connection of Individual modules

All the modules are meaningless unless they can cooperate together to form a holistic structure and solve problems cooperatively. So the algorithm to manage all the separate modules together to work together is also an important part of the design. Currently, the proposed strategy of connecting all the modules together can be arranged into 4 phases:

*1)*   *To from the simplest structure that is able to move independently. (a)*

*2)*   *Using these structures to gather more modules to achieve a relatively stable system. (b)*

*3)*   *Using the small systems that have been formed to gather modules. (c)*

*4)*   *Combining all the small systems together to obtain the final structure we desire.* 

<div align=center><img src=".\Pictures\phase_1\6.jpg" alt="6" width="500" /></div>

### Implement

Some basic tests have been implemented to verify the feasibility of the actuating mechanism. Since the whole structure can be considered as three orthogonal stators and the electromagnets on each stator have little influence to other stators, the feasibility can be test on just one stator. A very preliminary experiment's devices are shown in figure below. The iron core of the prototype is using a stator which is made for motor. Its diameter is 40mm, height is 20mm, number of slots is 12. The diameter of varnished wire is 0.21 which could be much smaller to improve the performance significantly. Since the power dissipation can be reduced because no extra resistance is needed to constrain the current any more. On each tooth of the stator, we put an independent coil on it. The electronics in this testing device is very simple, using a STM32F103C8T6 to control all the independent coils, a ZigBee module CC2530 to communicate with upper computer. Some resistance is added to restrain the current inside the coil. A 12v battery is used to provide power for the coils. A voltage stabilization module AMS1117 is used to provide 3.3v power source for controlling circuit. A simple upper computer program has also been written to control each coil. 

<div align=center>
<img src=".\Pictures\phase_1\24.JPG" alt="24" height="300" />
</div>

## PHASE 2

### Modification

<div align=center><img src=".\Pictures\phase_2\11.PNG" alt="11" width="500" /></div>

<div align=center><img src=".\Pictures\phase_2\25.jpg" alt="25" width="500" /></div>

### Implement



<div align=center><img src=".\Pictures\phase_2\1.JPG" alt="1" width="400"/></div>
<div align=center>
<img src=".\Pictures\phase_2\2.JPG" alt="2" width="200" /><img src=".\Pictures\phase_2\3.jpg" alt="3" width="200"/>
</div>
<div align=center>
<img src=".\Pictures\phase_2\4.JPG" alt="4" width="200" /><img src=".\Pictures\phase_2\5.JPG" alt="5" width="200" />
</div>




