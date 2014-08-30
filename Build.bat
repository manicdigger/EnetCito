del /q /s Output

mkdir Output
REM mkdir Output\C
REM mkdir Output\C99
mkdir Output\Java
mkdir Output\Cs
mkdir Output\Js
mkdir Output\JsTa
mkdir Output\As
mkdir Output\D
mkdir Output\Pm
mkdir Output\Pm510

REM cito -D CITO -l c -o Output\C\EnetCito.cs EnetCito\Enet.ci.cs
REM cito -D CITO -l c99 -o Output\C99\EnetCito.cs EnetCito\Enet.ci.cs
cito -D CITO -l java -o Output\Java\EnetCito.java -n enetcito.lib  EnetCito\Enet.ci.cs
REM cito -D CITO -l cs -o Output\Cs\EnetCito.cs EnetCito\Enet.ci.cs 
REM cito -D CITO -l js -o Output\Js\EnetCito.cs EnetCito\Enet.ci.cs 
REM cito -D CITO -l js-ta -o Output\JsTa\EnetCito.cs EnetCito\Enet.ci.cs 
REM cito -D CITO -l as -o Output\As\EnetCito.cs EnetCito\Enet.ci.cs 
REM cito -D CITO -l d -o Output\D\EnetCito.cs EnetCito\Enet.ci.cs 
REM cito -D CITO -l pm -o Output\Pm\EnetCito.cs EnetCito\Enet.ci.cs 
REM cito -D CITO -l pm510 -o Output\Pm510\EnetCito.cs EnetCito\Enet.ci.cs 