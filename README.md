# Modificar el proyecto Línea de Visión para que use una máquina de estado finito.
## Autor: Álvaro González Rodríguez
alu0101202556

<p>Modifica el proyecto de Línea de Visión para hacer que el NPC se controle a través de una máquina de estados. Los estados son:</p>

<p>1. Patrol: implementa el método "wander". Si el jugador entra en el campo de visión del agente pasa el estado "Chase"</p>
<p>2. Chase: implementa "Seek" o "Pursue" para seguir al jugador. Si el jugador está dentro de la distancia de tiro pasa al estado "Attack". Si el jugador deja de estar en el campo de visión, pasa al estado "Patrol"</p>
<p>3. Attack: dispara al jugador. Si la distancia con el jugador es superior a la distancia de tiro, pasa al estado "Chase". Si la vida del NPC está por debajo de una cantidad, pasa al estado "Hide".</p>
<p>4. Hide: implementa el método "Hide" o "CleverHide" y regenera la vida del NPC. Si la vida está por encima de un valor, pasa al estado "Patrol"</p>
![Alt Text](GIFs/maquinaEstados.gif)
<p>La maquina de estados tiene implementado los 4 estados de la forma que describe el ejercicio. Patrol sería su estado inicial y base, el cual implementa el método wander</p>
<p>Chase implementa el estado Seek, el cual se trigerea cuando el jugador entra dentro del estado de visión del robot, si el jugador se aleja lo suficiente para volver a salir del rango el robot pasará a patrol otra vez</p>
<p>Con el estado Attack el robot puede disparar al jugador, esto ocurre cuando la distancia entre le robot y el objetivo es suficientemente pequeña. Si la distancia vuelve a ser demaciado grane se pasa al estado chase y si el jugador dispara al robot y su vida pasa por debajo de un umbral el robot pasa a hide</p>
<p>Hide implementa el estado Clever Hide, este busca uno de los tres obstaculos para esconderse y si este no está a la vista del jugador se curará poco a poco parte de su vida. Una vez pase un umbral de cantidad de vida el robot vuelve al estado Patrol</p>
<p>A continuación un breve ejemplo de la ejecución del programa</p>
![Alt Text](GIFs/ejecucion.gif)