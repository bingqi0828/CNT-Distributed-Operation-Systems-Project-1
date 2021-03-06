# CNT-Distributed-Operation-Systems
Project 1 Report

Bing Qi (UFID: 32273501)
Manzhu Wang (UFID:58675398)

1. Size of the work unit
When N=1000000 and K=4, we have tried various different situations to determine the best CPU utilization rate, the results are presented below. 

Work Unit
CPU
REAL
CPU utilization
100
2.543
1.15
2.21
1000
0.092
0.057
1.61
10000
0.020
0.015
1.33
20000
0.057
0.043
1.32
100000
0.021
0.016
1.31

Based on the data above, it is found that the larger the work unit, the less the working CPU time and real-time. However, the larger the work unint, the less the CPU utilization ratio. 

By observing the data above, we determine that work unit is 10000 and thus the actor number is 100. The reasonale is, when work uint is 20000, the CPU time is around 0.02s and the CPU utilization ratio is also relatively high. 


2 Result of runninng the program The result of runnning the program is shown below:

(base) bingqideMacBook-Pro:Project1 qibing$ dotnet fsi Main.fsx 1000000 4
Real: 00:00:00.419, CPU: 00:00:00.328, GC gen0: 1, gen1: 0, gen2: 0

We can find under N=1000000, K=4, there is no perfect square numbers


3. The running time for the program
N=1000000, k=4, work unit=20000

(base) bingqideMacBook-Pro:Project1 qibing$ time dotnet fsi Main.fsx 1000000 4
Real: 00:00:00.879, CPU: 00:00:01.884, GC gen0: 35, gen1: 2, gen2: 0

real	0m3.666s
user	0m3.587s
sys	0m0.777s

We can find that the CPU time(5.445+0.921) vs. real-time ratio is around 1.85, which is acceptable

4. The largest problem we managed to solve

The largest problem we have solved is N=100000000, k=24

It generates numerous results.

Part of the results is presented below.


99858737 

99863521 

99897293 

99897412 

99936012 

99990488 

99991397 

Real: 00:06:19.184, CPU: 00:21:37.104, GC gen0: 5793, gen1: 40, gen2: 3

real	6m24.942s
user	17m40.092s
sys	4m1.705s

