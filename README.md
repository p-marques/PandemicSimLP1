# Pandemic Simulation

**Project Recurso - Linguagens de Programação I 2019/2020**

**Videojogos - Universidade Lusófona**

## Authors / Responsibilities

**Pedro Dias Marques - 21900800**

- Argument Handling
- Simulation main loop
- UI
- Report

**Pedro Fernandes - 21908084**

- Tile, Agent classes
- Coords and TurnReport structs
- UML Diagram

**Github:** [Link](https://github.com/p-marques/PandemicSimLP1)

## Solution Architecture

### Flow

The program starts by handling any given arguments.
Some are mandatory, being needed to set the parameters for the simulation.
Others are optional, representing extra functionality, not essential to the
simulation.

**Available Commands**

- `-N`: the size of the grid. Actual size will be N x N;
- `-M`: starting number of agents;
- `-L`: lifespan of an infected agent;
- `-Tinf`: turn at which the first infection takes place;
- `-T`: max number of turns;
- `-v`: (Optional) visualize the grid;
- `-o`: (Optional) save file with the per turn stats of the simulation;
- `-h`: (must be the only parameter) displays help message.

If any errors are found, the appropriate error messages are displayed and the
program closes.

Assuming no errors were found, the simulation begins.

If `-v` is passed as an argument the full grid will be shown, and the user will
be prompted to press the Enter key after each turn.

If `-v` is omitted a simple message with the current stats of the simulation
will be printed to the console.

The simulation ends if the max rounds (`-T` argument) have been reached or there
are no agents alive.

### UML Diagram

![uml](images/uml.png "UML Diagram")

**Figura 1** - UML Diagram. Made with [diagrams.net](https://www.diagrams.net/).

`Options` struct not just holds the application settings, but it is also
responsible for interpreting the given arguments into said settings.

`Simulation` is the heart of the application, specially the method `Run()`,
which is responsible for the main loop of the simulation. In the constructor,
`Random` is initialized and saved as a private field. This is the only time it's
initialized to have the same seed be used for every call of `Random.Next()`
during the simulation run. Still in the constructor, the `Grid` and all the
`Agent` instances are created. The Agents are also randomly placed on the
`Grid`.

An `Agent` is never destroyed, being simply ignored after death. It's the
`Agent`'s own responsibility to set it's `IsDead` property, using the round
number at which the infection happened, the lifespan (set with `-L`) and the
current round to determine if it should die. This determination happens when the
`InfectionTick()` method is called.

`TurnReport` is a struct capable of holding the current healthy, infected and
dead agents statistics required to display on the console but also to save to a
file if the `-o` argument is used.

## References

The only thing that deserves a mention is the fact that the design of `Options`
was, initially, heavily inspired by [this][1], which is the professor's own
proposed solution to Project 2 of last year.

[1]: https://github.com/VideojogosLusofona/lp1_2018_p2_solucao